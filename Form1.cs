using MyMineSweeper.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MyMineSweeper
{
    public partial class Board : Form
    {
        private Configuration configForm;
        private BoardMap boardMap;
        private Timer timer;
        private Stopwatch clock;
        private int minesQty = 0;
        private int numRows = 0;
        private int numCols = 0;
        private int cellSize = 0;
        private int coinsTip = 0;
        private int successfulGuesses = 0;
        private int goldCoins = 0;
        private int remainingMines = 0;

        private static bool gameOver = true;
        private static bool gameStarted = false;
        private bool firstClick;

        public int MinesQty { get => minesQty; set => minesQty = value; }
        public int RemainingMines { get => remainingMines; set => remainingMines = value; }
        public int NumRows { get => numRows; set => numRows = value; }
        public int NumCols { get => numCols; set => numCols = value; }
        public int CellSize { get => cellSize; set => cellSize = value; }
        public int CoinsTip { get => coinsTip; set => coinsTip = value; }
        public int SuccessfulGuesses { get => successfulGuesses; set => successfulGuesses = value; }
        public int GoldCoins { get => goldCoins; set => goldCoins = value;  }
        public static bool GameOver { get => gameOver; set => gameOver = value; }
        public static bool GameStarted { get => gameStarted; set => gameStarted = value; }
        public bool FirstClick { get => firstClick; set => firstClick = value; }

        public void AddSuccessfulGuess(int val)
        {
            if (SuccessfulGuesses + val == 10)
            {
                AddGoldCoins(1);
                SuccessfulGuesses = 0;
            } 
            else
            {
                SuccessfulGuesses += val;
            }
        }

        public void AddGoldCoins(int val)
        {
            GoldCoins += val;
            ShowGoldCoins();
        }


        private void ShowGoldCoins()
        {
            lblCoins.Text = "Moedas = " + GoldCoins.ToString();
        }

        private void RestartGoldCoins()
        {
            GoldCoins = 0;
            SuccessfulGuesses = 0;
            ShowGoldCoins();
        }

        public void SetRemainingMines(bool reduce)
        {
            if (reduce) --remainingMines; else ++remainingMines;
            lblMines.Text = "Minas = " + RemainingMines.ToString();
        }

        private void RestartMines()
        {
            RemainingMines = MinesQty;
            lblMines.Text = "Minas = " + RemainingMines.ToString();
        }

        public void SetGameOver(bool val)
        {
            GameOver = val;
            if (val) StopTimer();
        }

        public bool IsGameOn()
        {
            return !GameOver && GameStarted;
        }

        public Board()
        {
            InitializeComponent();
            configForm = new Configuration();
            InitPreferences();
            FirstClick = true;
            SetClock();
        }

        public void NovoJogo()
        {
            ClearBoard();
            if (GameStarted)
            {
                FirstClick = true;
                GameStarted = false;
                RestartGoldCoins();
            }
            IniciarJogo();
            ResetTimer();
            RestartMines();
        }

        private void IniciarJogo()
        {
            GameOver = false;
            InitBoard();

            foreach(KeyValuePair<Point, Cell> kvp in boardMap)
            {
                SetCellInitialAttributes(kvp.Value);
                pnlBoard.Controls.Add(kvp.Value);
            }

            //pnlBoard.Refresh();
        }

        private void SetCellInitialAttributes(Cell c)
        {
            c.Size = new Size(CellSize, CellSize);
            c.TabStop = false;
            c.Location = new Point(c.GetY() * (CellSize - 1), c.GetX() * (CellSize - 1));
            c.MouseUp += CellClicked;
        }

        private void SetClock()
        {
            timer = new Timer { Interval = 1000, Enabled = false };
            timer.Tick += new EventHandler(TimerTick);
            clock = new Stopwatch();
        }

        private void TimerTick(object Sender, EventArgs e)
        {
            lblTime.Text = clock.Elapsed.ToString(@"mm\:ss");
        }

        private void ResetTimer()
        {
            clock.Reset();
        }

        private void StopTimer()
        {
            timer.Stop();
            clock.Stop();
        }

        private void StartTimer()
        {
            timer.Start();
            clock.Start();
        }

        private void ClearBoard()
        {
            pnlBoard.Controls.Clear();
        }

        private void menuItemSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItemConfig_Click(object sender, EventArgs e)
        {
            configForm.ShowDialog();
        }

        private void InitPreferences()
        {
            MinesQty = int.Parse(configForm.GetSetting(SettingsName.MINESQTY));
            NumRows  = int.Parse(configForm.GetSetting(SettingsName.ROWS));
            NumCols  = int.Parse(configForm.GetSetting(SettingsName.COLS));
            CellSize = int.Parse(configForm.GetSetting(SettingsName.CELLSIZE));
            CoinsTip = int.Parse(configForm.GetSetting(SettingsName.COINSTIP));
        }

        private void InitBoard()
        {
            // Criação do BoardMap
            boardMap = new BoardMap();
            Cell auxCell;
            for (int i = 0; i < NumRows; i++)
            {
                for (int j = 0; j < NumCols; j++)
                {
                    auxCell = new Cell(new Point(i, j));
                    auxCell.SetMyBoard(this);
                    boardMap.Add(auxCell.GetPosition(), auxCell);
                }
            }

            // BoardMap
            // Conectando as células entre si pelo perímetro
            Point point = new Point(); 
            foreach(KeyValuePair<Point, Cell> kvp in boardMap)
            {
                // Superior Esquerda
                point.X = kvp.Key.X - 1;
                point.Y = kvp.Key.Y - 1;
                if (boardMap.ContainsKey(point)) kvp.Value.Perimeter.AddCell(boardMap[point]);

                // Superior
                point.X = kvp.Key.X - 1;
                point.Y = kvp.Key.Y;
                if (boardMap.ContainsKey(point)) kvp.Value.Perimeter.AddCell(boardMap[point]);

                // Superior Direita
                point.X = kvp.Key.X - 1;
                point.Y = kvp.Key.Y + 1;
                if (boardMap.ContainsKey(point)) kvp.Value.Perimeter.AddCell(boardMap[point]);

                // Direita
                point.X = kvp.Key.X;
                point.Y = kvp.Key.Y + 1;
                if (boardMap.ContainsKey(point)) kvp.Value.Perimeter.AddCell(boardMap[point]);

                // Inferior Direita
                point.X = kvp.Key.X + 1;
                point.Y = kvp.Key.Y + 1;
                if (boardMap.ContainsKey(point)) kvp.Value.Perimeter.AddCell(boardMap[point]);

                // Inferior
                point.X = kvp.Key.X + 1;
                point.Y = kvp.Key.Y;
                if (boardMap.ContainsKey(point)) kvp.Value.Perimeter.AddCell(boardMap[point]);

                // Inferior Esquerda
                point.X = kvp.Key.X + 1;
                point.Y = kvp.Key.Y - 1;
                if (boardMap.ContainsKey(point)) kvp.Value.Perimeter.AddCell(boardMap[point]);

                // Esquerda
                point.X = kvp.Key.X;
                point.Y = kvp.Key.Y - 1;
                if (boardMap.ContainsKey(point)) kvp.Value.Perimeter.AddCell(boardMap[point]);
            }
        }

        /// <summary>
        /// Após o primeiro clique do jogador numa célula, sua posição é tomada e carregamos todas
        /// as minas excluindo as nove possiveis células (célula clicada e seu perímetro)
        /// </summary>
        /// <param name="X">Posição vertical ou linha</param>
        /// <param name="Y">Posição horizontal ou coluna</param>
        private void LoadMines(int X, int Y)
        {
            // Colocando as minas, sempre testando que todas tenham suas células
            int minesLeft = MinesQty;
            Point auxPoint = new Point();
            Random rand = new Random();
            List<Point> positions = boardMap[new Point(X, Y)].Perimeter.GetPositions();
            positions.Add(new Point(X, Y)); // Adicionando a posição da própria célula clicada
            for(; minesLeft > 0;)
            {
                do
                {
                    auxPoint.X = rand.Next(0, NumRows - 1);
                    auxPoint.Y = rand.Next(0, NumCols - 1);
                } while (positions.Contains(auxPoint));
                if (!boardMap[auxPoint].IsMine())
                {
                    boardMap[auxPoint].Mine = true;
                    boardMap[auxPoint].Perimeter.IncreaseNumbers();
                    minesLeft--;
                }
            }
        }
        
        public void CellClicked(object Sender, MouseEventArgs me)
        {
            if (!GameOver)
            {
                Cell cell = Sender as Cell;

                switch (me.Button)
                {

                    // Esquerdo
                    case MouseButtons.Left:
                        
                        if (FirstClick)
                        {
                            LoadMines(cell.GetX(), cell.GetY());
                            StartTimer();
                            FirstClick = false;
                            GameStarted = true;
                        }

                        if (cell.IsUncovered() && cell.IsNumbered())
                        {
                            if (!cell.RevealPerimeter())
                            {
                                SetGameOver(true);
                                FirstClick = true;
                                ShowAllMines();
                            }
                        }
                        else if (!cell.Reveal())
                        {
                            SetGameOver(true);
                            FirstClick = true;
                            ShowAllMines();
                        }
                        
                        // Checagem de vitória
                        if (RemainingMines == boardMap.RemainingCoveredCells)
                        {
                            boardMap.FlagRemainingMines();
                            SetGameOver(true);
                            FirstClick = true;
                            if (MessageBox.Show(this, "Deseja iniciar novo jogo?", "Você encontrou todas as minas!", MessageBoxButtons.YesNo, MessageBoxIcon.Information).Equals(DialogResult.Yes))
                                NovoJogo();
                        }

                        break;

                    // Direito
                    case MouseButtons.Right:
                            
                        Marks lastMark = cell.ToggleMark();
                        if (!cell.IsUncovered() && lastMark.Equals(Marks.COVERED) && cell.IsFlagMarked())
                        {
                            SetRemainingMines(true);
                            if (cell.IsMine()) AddSuccessfulGuess(1);
                        }
                        else if (!cell.IsUncovered() && lastMark.Equals(Marks.MINEFLAG))
                        {
                            SetRemainingMines(false);
                            if (cell.IsMine()) AddSuccessfulGuess(-1);
                        }
                        
                        // Checagem da vitória
                        if (boardMap.RemainingCoveredCells == 0 && boardMap.AreAllMinesFlagged && RemainingMines == 0)
                        {
                            SetGameOver(true);
                            FirstClick = true;
                            if (MessageBox.Show(this, "Deseja iniciar novo jogo?", "Você encontrou todas as minas!", MessageBoxButtons.YesNo, MessageBoxIcon.Information).Equals(DialogResult.Yes))
                                NovoJogo();
                        }

                        break;

                    // Meio
                    case MouseButtons.Middle:
                        
                        if (cell.IsUncovered() && cell.IsNumbered())
                        {
                            if (GoldCoins >= CoinsTip && 
                                MessageBox.Show("Deseja revelar uma mina?", String.Format("Custa {0} moedas", CoinsTip), 
                                MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                            {
                                cell.PointMine();
                                SetRemainingMines(true);
                                AddGoldCoins(-CoinsTip);
                            }
                        }
                        

                        //MessageBox.Show(cell.ToString());
                        break;
                }

            }
        }

        public void ShowAllMines()
        {
            boardMap.ShowAllMines();
            if (MessageBox.Show(this, "Deseja iniciar novo jogo?", "Você pisou numa mina!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).Equals(DialogResult.Yes))
            {
                NovoJogo();
            }
        }

        private void menuItemNovo_Click(object sender, EventArgs e)
        {
            NovoJogo();
        }

        private void menuItemConfig_Click_1(object sender, EventArgs e)
        {
            configForm.Visible = true;
        }
    }

    public class BoardMap : Dictionary<Point, Cell>
    {
        public bool AreAllMinesFlagged
        {
            get
            {
                IEnumerable<Cell> cells = Values.ToList().FindAll(cell => cell.IsMine());

                foreach (Cell cell in cells)
                {
                    if (!cell.IsMineFlagged())
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public int RemainingCoveredCells
        {
            get
            {
                return Values.ToList().FindAll(cell => cell.IsCovered()).Count();
            }
        }

        public void FlagRemainingMines()
        {
            IEnumerable<Cell> mines = Values.ToList().FindAll(cell => cell.IsMine() && !cell.IsFlagMarked());

            foreach(Cell cell in mines)
            {
                cell.SetMark(Marks.MINEFLAG);
            }
        }

        public void ShowAllMines()
        {

            foreach (Cell cell in Values.ToList().FindAll(cell => cell.IsMine() || cell.IsFlagMarked()))
            {
                cell.ShowMine();
            }
        }

        public void RevealAllCells() 
        {
            foreach (Cell cell in Values.ToList().FindAll(cell => !cell.IsMine() && !cell.IsUncovered()))
            {
                cell.Reveal();
            }
        }

    }
}
