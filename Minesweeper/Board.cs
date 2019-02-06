using System.Drawing;

namespace Minesweeper
{
    abstract class Board
    {
        public static Graphics drawBoard(Graphics g, int length, int[,] cells)
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    g.FillRectangle(groundBrush(i, j, cells), new Rectangle(j * length, i * length, length, length));

                    Font font = new Font("Segoe UI", length / 3);
                    SolidBrush brush = new SolidBrush(Color.FromArgb(90, Color.Black));
                    SizeF stringSize = g.MeasureString("0", font);
                    int x = j * length;
                    int y = i * length;

                    if (cells[i, j] == -2 || cells[i, j] == -3)
                        g.FillEllipse(brush, new Rectangle(x + (length / 4), y + (length / 4), length / 2, length / 2));
                    else if (cells[i, j] > 0 && cells[i, j] < 9)
                        g.DrawString(cells[i, j].ToString(), font, brush, x + (length - stringSize.Width) / 2, y + (length - stringSize.Height) / 2);
                    if (cells[i, j] == -4 || cells[i, j] == -6)
                        g.DrawString("F", font, brush, x + (length - stringSize.Width) / 2, y + (length - stringSize.Height) / 2);
                    else if (cells[i, j] == -5 || cells[i, j] == -7)
                        g.DrawString("?", font, brush, x + (length - stringSize.Width) / 2, y + (length - stringSize.Height) / 2);
                }
            }
            return g;
        }

        public static SolidBrush groundBrush(int i, int j, int[,] cells)
        {
            SolidBrush brush;
            if (cells[i, j] == -3)
            {
                brush = new SolidBrush(Color.FromArgb(250, 30, 30));
            }
            else if (cells[i, j] == -4 || cells[i, j] == -6 || cells[i, j] == -5 || cells[i, j] == -7)
            {
                if ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                    brush = new SolidBrush(Color.FromArgb(114, 90, 193));
                else
                    brush = new SolidBrush(Color.FromArgb(141, 134, 201));
            }
            else if (cells[i, j] <= 0)
            {
                if ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                    brush = new SolidBrush(Color.FromArgb(114, 90, 193));
                else
                    brush = new SolidBrush(Color.FromArgb(141, 134, 201));
            }
            else
            {
                if ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                    brush = new SolidBrush(Color.FromArgb(202, 196, 206));
                else
                    brush = new SolidBrush(Color.FromArgb(247, 236, 225));
            }
            return brush;
        }

    }
}
