using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Main : Form
    {
        private Bitmap surface;
        private Graphics device;
        private Game game;

        private int[] BOARD_SIZE = { 9, 16, 24 };
        private int[] MINE_COUNT = { 10, 44, 99 };

        private int[,] cells;
        /*
           -7  - Question mark (Mine)
           -6  - Flag (Mine)
           -5  - Question mark (Land)
           -4  - Flag (Land)
           -3  - Clicked mine
           -2  - Revealed mine
           -1  - Mine
            0  - Land
           1-8 - Pits surrounded by mines
            9  - Pit
        */
        private int level;
        private int time;

        public Main()
        {
            InitializeComponent();
            cmbxLevel.SelectedIndex = 0;
            Initialize();
        }

        private void Initialize()
        {
            timer.Stop();
            time = 0;

            level = cmbxLevel.SelectedIndex + 1;

            lblMines.Text = MINE_COUNT[level - 1].ToString().PadLeft(4, '0');
            lblTime.Text = time.ToString().PadLeft(4, '0');

            btnPlay.BackgroundImage = Properties.Resources.happy;

            cells = new int[BOARD_SIZE[level - 1], BOARD_SIZE[level - 1]];

            surface = new Bitmap(this.canvas.Width, this.canvas.Height);

            device = Graphics.FromImage(surface);
            device.SmoothingMode = SmoothingMode.AntiAlias;

            game = new Game(MINE_COUNT[level - 1]);
            game.fillBoard(cells);
            draw();
        }

        private void Event_MouseClick(object sender, MouseEventArgs e)
        {
            if (time == 0) timer.Start();

            if (game.getGameState() == 0)
            {
                game.check(e.Y / (canvas.Width / BOARD_SIZE[level - 1]), e.X / (canvas.Height / BOARD_SIZE[level - 1]), cells, e.Button);
                draw();
                int mines = MINE_COUNT[level - 1] - game.getFlags();
                lblMines.Text = (mines < 0 ? 0 : mines).ToString().PadLeft(4, '0');

                if (game.getGameState() == -1)
                {
                    timer.Stop();
                    btnPlay.BackgroundImage = Properties.Resources.sad;
                    MessageBox.Show("You Lost !", "Minesweeper");
                }
                else if (game.getGameState() == 1)
                {
                    timer.Stop();
                    MessageBox.Show("You Win !", "Minesweeper");
                }
            }
        }

        private void draw()
        {
            Board.drawBoard(device, canvas.Width / BOARD_SIZE[level - 1], cells);
            canvas.Image = surface;
        }

        private void Play(object sender, System.EventArgs e)
        {
            Initialize();
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            time++;
            lblTime.Text = time.ToString().PadLeft(4, '0');
        }
    }
}
