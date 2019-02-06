using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    class Game
    {
        private int flagged;
        private int mineCount;
        private int gameState;

        public Game(int mineCount)
        {
            this.mineCount = mineCount;
            this.flagged = 0;
            this.gameState = 0;
        }

        public int getGameState()
        {
            return gameState;
        }

        public int getFlags()
        {
            return flagged;
        }

        public void fillBoard(int[,] cells)
        {
            for (int i = 0; i < cells.GetLength(0); i++)
                for (int j = 0; j < cells.GetLength(1); j++)
                    cells[i, j] = 0;

            addMines(cells);
        }

        public void check(int i, int j, int[,] cells, MouseButtons b)
        {

            if (b == MouseButtons.Left)
            {
                if (cells[i, j] == 0)
                {
                    countMines(i, j, cells);
                }
                else if (cells[i, j] == -1)
                {
                    revealMines(i, j, cells);
                    this.gameState = -1;
                }
            }
            else if (b == MouseButtons.Right)
            {
                if (cells[i, j] == 0)
                {
                    cells[i, j] = -4;
                    flagged++;
                }
                else if (cells[i, j] == -1)
                {
                    cells[i, j] = -6;
                    flagged++;
                }
                else if (cells[i, j] == -4)
                {
                    cells[i, j] = -5;
                    flagged--;
                }
                else if (cells[i, j] == -5)
                    cells[i, j] = 0;
                else if (cells[i, j] == -6)
                {
                    cells[i, j] = -7;
                    flagged--;
                }
                else if (cells[i, j] == -7)
                    cells[i, j] = -1;
            }

            if (checkWin(cells))
                this.gameState = 1;

        }

        private void addMines(int[,] cells)
        {
            int n = cells.GetLength(0) * cells.GetLength(1);
            int minesToBePlaced = mineCount;
            Random r = new Random();
            while (minesToBePlaced > 0)
            {
                int t = r.Next(1, n);
                if (cells[(t - 1) / cells.GetLength(1), (t - 1) % cells.GetLength(0)] == 0)
                {
                    cells[(t - 1) / cells.GetLength(1), (t - 1) % cells.GetLength(0)] = -1;
                    minesToBePlaced--;
                }
            }
        }

        private void revealMines(int i, int j, int[,] cells)
        {
            cells[i, j] = -3;
            for (int p = 0; p < cells.GetLength(0); p++)
            {
                for (int q = 0; q < cells.GetLength(1); q++)
                {
                    if (cells[p, q] == -1)
                        cells[p, q] = -2;
                }
            }
        }

        private Queue<Point> getNeighbouringCells(Point p, int[,] cells)
        {
            int i = p.X;
            int j = p.Y;
            Queue<Point> lst = new Queue<Point>();
            int count = 0;

            if (i + 1 < cells.GetLength(0) && (cells[i + 1, j] == -1 || cells[i + 1, j] == -6 || cells[i + 1, j] == -7))
                count++;
            else if (i + 1 < cells.GetLength(0) && cells[i + 1, j] == 0)
                lst.Enqueue(new Point(i + 1, j));

            if (i - 1 > -1 && (cells[i - 1, j] == -1 || cells[i - 1, j] == -6 || cells[i - 1, j] == -7))
                count++;
            else if (i - 1 > -1 && cells[i - 1, j] == 0)
                lst.Enqueue(new Point(i - 1, j));

            if (j + 1 < cells.GetLength(1) && (cells[i, j + 1] == -1 || cells[i, j + 1] == -6 || cells[i, j + 1] == -7))
                count++;
            else if (j + 1 < cells.GetLength(1) && cells[i, j + 1] == 0)
                lst.Enqueue(new Point(i, j + 1));

            if (j - 1 > -1 && (cells[i, j - 1] == -1 || cells[i, j - 1] == -6 || cells[i, j - 1] == -7))
                count++;
            else if (j - 1 > -1 && cells[i, j - 1] == 0)
                lst.Enqueue(new Point(i, j - 1));

            if (i + 1 < cells.GetLength(0) && j + 1 < cells.GetLength(1) && (cells[i + 1, j + 1] == -1 || cells[i + 1, j + 1] == -6 || cells[i + 1, j + 1] == -7))
                count++;
            else if (i + 1 < cells.GetLength(0) && j + 1 < cells.GetLength(1) && cells[i + 1, j + 1] == 0)
                lst.Enqueue(new Point(i + 1, j + 1));

            if (i - 1 > -1 && j + 1 < cells.GetLength(1) && (cells[i - 1, j + 1] == -1 || cells[i - 1, j + 1] == -6 || cells[i - 1, j + 1] == -7))
                count++;
            else if (i - 1 > -1 && j + 1 < cells.GetLength(1) && cells[i - 1, j + 1] == 0)
                lst.Enqueue(new Point(i - 1, j + 1));

            if (i + 1 < cells.GetLength(0) && j - 1 > -1 && (cells[i + 1, j - 1] == -1 || cells[i + 1, j - 1] == -6 || cells[i + 1, j - 1] == -7))
                count++;
            else if (i + 1 < cells.GetLength(0) && j - 1 > -1 && cells[i + 1, j - 1] == 0)
                lst.Enqueue(new Point(i + 1, j - 1));

            if (i - 1 > -1 && j - 1 > -1 && (cells[i - 1, j - 1] == -1 || cells[i - 1, j - 1] == -6 || cells[i - 1, j - 1] == -7))
                count++;
            else if (i - 1 > -1 && j - 1 > -1 && cells[i - 1, j - 1] == 0)
                lst.Enqueue(new Point(i - 1, j - 1));

            cells[i, j] = (count == 0) ? 9 : count;
            if (count > 0)
                return null;
            return lst;
        }

        private void countMines(int i, int j, int[,] cells)
        {
            Queue<Point> lst = new Queue<Point>();
            lst.Enqueue(new Point(i, j));
            while (lst.Count > 0)
            {
                Queue<Point> p = getNeighbouringCells(lst.Dequeue(), cells);

                if (p != null)
                    foreach (Point pt in p)
                        if (!lst.Contains(pt)) lst.Enqueue(pt);
            }
        }

        private bool checkWin(int[,] cells)
        {
            if (flagged != mineCount)
                return false;
            for (int i = 0; i < cells.GetLength(0); i++)
                for (int j = 0; j < cells.GetLength(1); j++)
                    if (cells[i, j] != -6 && cells[i, j] < 1)
                        return false;

            return true;
        }

    }
}
