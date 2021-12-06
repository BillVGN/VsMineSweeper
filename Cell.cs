using MyMineSweeper.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMineSweeper
{
    public class Cell : Button
    {

        /// <summary>
        /// Lista com referências as outras 8 células a qual esta tem como "vizinhas".
        /// </summary>
        private Perimeter perimeter;

        private Board currentBoard;

        /// <summary>
        /// True se a célula contém uma bomba; false caso contrário.
        /// </summary>
        private bool mine;

        /// <summary>
        /// Número de células ao redor que contém bombas. Vai de 0 até 8.
        /// </summary>
        private int number;

        /// <summary>
        /// Posição da célula dentro da matriz de células. É usado 0 (zero) para a
        /// posição inicial, tanto na vertical quanto na horizontal. Até o limite
        /// de linhas/colunas - 1.
        /// </summary>
        private Point position;

        /// <summary>
        /// Marcação atual da célula. Padrão é Marks.COVERED <see cref="Marks"/> .
        /// </summary>
        private Marks mark;

        public Cell()
        {
            Perimeter = new Perimeter();
            Mine = false;
            Number = 0;
            Position = new Point(0, 0);
            Mark = Marks.COVERED;
            SetCellVisualStyle();
        }

        public Cell(Point p)
        {
            Perimeter = new Perimeter();
            Mine = false;
            Number = 0;
            Position = p;
            Mark = Marks.COVERED;
            SetCellVisualStyle();
        }

        public Cell(bool mine, int number, Point position, Marks mark)
        {
            Perimeter = new Perimeter();
            Mine = mine;
            Number = number;
            Position = position;
            Mark = mark;
            SetCellVisualStyle();
        }

        public Perimeter Perimeter { get => perimeter; set => perimeter = value; }
        public bool Mine { get => mine; set => mine = value; }
        public int Number { get => number; set => number = value; }
        public Point Position { get => position; set => position = value; }
        public Marks Mark { get => mark; set => mark = value; }


        public Point GetPosition()
        {
            return Position;
        }

        public void SetMark(Marks mark)
        {
            Mark = mark;
            if (mark.Equals(Marks.UNCOVERED)) 
            {
                UncoverCell();
            }
            else
            {
                ShowMark(false);
            }
        }

        private void SetCellVisualStyle()
        {
            BackColor = Color.Transparent;
            FlatAppearance.BorderColor = SystemColors.ActiveBorder;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            ForeColor = Color.Transparent;
            UseVisualStyleBackColor = false;
            TabStop = false;
        }

        private void UncoverCell()
        {
            FlatStyle = FlatStyle.Flat;
        }

        public bool IsMine()
        {
            return Mine;
        }

        /// <summary>
        /// Aumenta o número da célula relativo à quantidade de minas ao seu redor.
        /// </summary>
        /// <returns>Retorna o novo número. Se for ultrapassar 8 (máximo), não incrementa e retorna -1</returns>
        public int IncreaseNumber()
        {
            return (Number < 8 && !IsMine()) ? ++Number : -1;
        }

        /// <summary>
        /// Diminui o número da célula relativo à quantidade de minas ao seu redor.
        /// </summary>
        /// <returns>Retorna o novo número. Se for ultrapassar 0 (mínimo), não decrementa e retorna -1</returns>
        public int DecreaseNumber()
        {
            return (Number > 0 && !IsMine()) ? --Number : -1;
        }

        public int GetY()
        {
            return Position.Y;
        }

        public int GetX()
        {
            return Position.X;
        }

        public bool IsCovered()
        {
            return Mark.Equals(Marks.COVERED);
        }

        public bool IsDoubtFlagged()
        {
            return Mark.Equals(Marks.DOUBTFLAG);
        }

        public bool IsMineFlagged()
        {
            return Mark.Equals(Marks.MINEFLAG);
        }

        public bool IsEmpty()
        {
            return (Number == 0) && !Mine;
        }

        public bool IsNumbered()
        {
            return Number > 0;
        }

        public bool IsUncovered()
        {
            return Mark.Equals(Marks.UNCOVERED);
        }

        public bool IsFlagMarked()
        {
            return Mark.Equals(Marks.MINEFLAG);
        }


        public Marks ToggleMark()
        {
            switch(Mark)
            {
                case Marks.COVERED:
                    SetMark(Marks.MINEFLAG);
                    ShowMark(false);
                    return Marks.COVERED;
                case Marks.MINEFLAG:
                    SetMark(Marks.DOUBTFLAG);
                    ShowMark(false);
                    return Marks.MINEFLAG;
                case Marks.DOUBTFLAG:
                    SetMark(Marks.COVERED);
                    ShowMark(true);
                    return Marks.DOUBTFLAG;
                default:
                    return Marks.COVERED;
            }
        }


        private void ShowNumber()
        {
            Image = ResourcesManager.GetNumberBitmap(Number);
        }

        private void ShowMark(bool remove)
        {
            if (remove)
            {
                Image = null;
            }
            else
            {
                Image = ResourcesManager.GetMarkBitmap(mark);
            }
        }


        public void ShowMine()
        {
            if (!IsFlagMarked() && IsMine())
            {
                Image = ResourcesManager.GetMineBitmap();
            } 
            else if (IsFlagMarked() && !IsMine())
            {
                Image = ResourcesManager.GetMarkBitmap(Marks.WRONGFLAG);
            }
        }


        public bool Reveal()
        {
            if (IsFlagMarked()) return true;

            if (IsMine()) return false;

            if (IsNumbered())
            {
                SetMark(Marks.UNCOVERED);
                ShowNumber();
            }
            else if (IsEmpty())
            {
                SetMark(Marks.UNCOVERED);
                RevealBlanksAndNumbers();
            }

            return true;
        }


        public void RevealBlanksAndNumbers() 
        {
            List<Cell> perim = Perimeter.ClearNulls().FindAll(cell => cell.IsCovered()).ToList();

            foreach (Cell neighbor in perim)
            {
                if (neighbor.IsEmpty() || neighbor.IsNumbered())
                    neighbor.Reveal();
            }
        }

        public void PointMine()
        {
            List<Cell> unflagged = Perimeter.GetUnflaggedMines();
            int flagged = Perimeter.CountFlagged();
            if (Number - flagged > 0) unflagged[0].ToggleMark();
        }


        public bool RevealPerimeter() => Number != Perimeter.CountFlagged() || !Perimeter.ClearNulls().Exists(cell => !cell.Reveal());

        public void SetMyBoard(Board board)
        {
            currentBoard = board;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Mina? " + Mine.ToString());
            sb.AppendLine("Número: " + Number.ToString());
            sb.AppendLine("Position: " + Position.ToString());
            sb.AppendLine("Mark: " + Mark.ToString());
            sb.AppendLine("Perímetro:");
            foreach (Cell neighbor in Perimeter.ClearNulls())
            {
                sb.AppendLine(string.Format("Vizinho({0},{1}): N={2},Mi={3},Ma={4}", 
                    neighbor.GetX(), neighbor.GetY(), neighbor.Number, neighbor.Mine, neighbor.Mark));
            }

            return sb.ToString();
        }
    }

    public static class ResourcesManager 
    {
        public static Bitmap GetNumberBitmap(int num)
        {
            switch (num)
            {
                case 1: return Resources._1raw75;
                case 2: return Resources._2raw75;
                case 3: return Resources._3raw75;
                case 4: return Resources._4raw75;
                case 5: return Resources._5raw75;
                case 6: return Resources._6raw75;
                case 7: return Resources._7raw75;
                case 8: return Resources._8raw75;
                default: return Resources.transparencia;
            }
        }


        public static Bitmap GetMarkBitmap(Marks mark)
        {
            switch (mark)
            {
                case Marks.MINEFLAG: return Resources.mineflag;
                case Marks.DOUBTFLAG: return Resources.doubtflag;
                case Marks.WRONGFLAG: return Resources.wrongflag;
                default: return Resources.transparencia;
            }
        }


        public static Bitmap GetMineBitmap() => Resources.mine;
    }

    public enum Marks
    {
        WRONGFLAG = -1,
        UNCOVERED = 0,
        COVERED = 1,
        MINEFLAG = 2,
        DOUBTFLAG = 3
    }

    public class Perimeter : IEnumerable, IEnumerator
    {
        private List<Cell> cells = new List<Cell>();
        
        public void AddCell(Cell c) { cells.Add(c); }

        public void AddRangeOfCells(IEnumerable<Cell> range) { cells.AddRange(range); }

        public Cell GetCellAt(int index) => cells[index];

        public void RemoveCellAt(int index) => cells.RemoveAt(index);

        public int position = -1;
        
        public Perimeter() { }

        public object Current { get { return cells[position]; } }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            position++;
            return (position < cells.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        public List<Cell> ClearNulls() => new List<Cell>(this.cells.FindAll(cell => cell != null));


        public List<Point> GetPositions()
        {
            List<Point> positions = new List<Point>();
            ClearNulls().ForEach(cell => positions.Add(cell.GetPosition()));
            return positions;
        }

        public List<Cell> GetBlanks() => new List<Cell>(ClearNulls().FindAll(cell => cell.Number == 0));

        public int CountFlagged() => ClearNulls().Sum(cell => (cell.IsFlagMarked()) ? 1 : 0);


        public int CountMarkedBy(Marks m) => ClearNulls().Sum(cell => (cell.Mark.Equals(m)) ? 1 : 0);


        public List<Cell> GetUnflaggedMines() => new List<Cell>(ClearNulls().FindAll(cell => !cell.IsFlagMarked() && cell.IsMine()));

        public void IncreaseNumbers() 
        {
            ClearNulls().ForEach(cell => cell.IncreaseNumber()); 
        }
    }

}
