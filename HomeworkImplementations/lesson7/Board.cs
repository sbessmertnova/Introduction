using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeworkImplementations.lesson7
{
    public class Board
    {
        public List<CellInfo> Cells { get; set; }
        public bool isFinished => QueensAmount == 8;
        public int RowSize { get; set; }
        public int ColumnSize { get; set; }

        public int QueensAmount { get; set; }

        public void PlaceQueen(Coordinate coordinate)
        {
            Cells
                .Single(cell => cell.Coordinate.X == coordinate.X && cell.Coordinate.Y == coordinate.Y)
                .OccupiedByQueen = true;
            QueensAmount++;
        }

        public override string ToString()
        {
            var rows = Cells.GroupBy(cellInfo => cellInfo.Coordinate.Y);
            var rowTextValues = rows.Select(row =>
                row.Key + ":"
                + string.Join(" ", row.ToList().Select(cell => cell.OccupiedByQueen ? "[Q]" : "[ ]")));
            return string.Join(Environment.NewLine, rowTextValues);
        }

        public Board Copy()
        {
            return new Board()
            {
                Cells =
                    this.Cells.Select(sourceCell =>
                        new CellInfo()
                        {
                            OccupiedByQueen = sourceCell.OccupiedByQueen,
                            Coordinate = new Coordinate()
                            {
                                X = sourceCell.Coordinate.X,
                                Y = sourceCell.Coordinate.Y
                            }
                        })
                .ToList(),
                QueensAmount = this.QueensAmount
            };
        }
        public static Board GetEmptyBoard()
        {
            var cells = 
                Enumerable.Range(0, 8)
                .SelectMany(rowNo => Enumerable.Range(0, 8)
                    .Select(columnNo => new CellInfo
                    {
                        Coordinate = new Coordinate
                        {
                            X = rowNo,
                            Y = columnNo
                        }
                    }))
                .ToList();
            return new Board()            
            {
                Cells = cells,
                RowSize = 8,
                ColumnSize = 8
            };
        }
    }
    public class CellInfo
    {
        public Coordinate Coordinate { get; set; }
        public bool OccupiedByQueen { get; set; }
    }
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

}
