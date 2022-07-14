using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HomeworkImplementations.lesson7
{
    public class QueenProblem
    {
        public void Test()
        {
            var initialBoard = Board.GetEmptyBoard();
            var timer = new Stopwatch();
            timer.Start();
            var solutions = GetSolutions(initialBoard)
                .Take(100)
                .ToArray();
            timer.Stop();
            Console.WriteLine($"{solutions.Count()} solutions found in {timer.Elapsed.TotalSeconds} seconds");
            Console.WriteLine($"{Environment.NewLine}");
            foreach (var solution in solutions)
            {
                Console.WriteLine(solution);
                Console.WriteLine($"{Environment.NewLine}");
            }
        }

        public IEnumerable<Board> GetSolutions(Board board)
        {
            if (board.isFinished)
            {
                return new[] {board};
            }

            var nextBoards = FindSafePlaces(board)
                .Select(safeCoordinate =>
                {
                    var nextBoard = board.Copy();
                    nextBoard.PlaceQueen(safeCoordinate);
                    return nextBoard;
                });

            return nextBoards.SelectMany(nextBoard => GetSolutions(nextBoard));
        }



        private static bool IsSafeHorizontally(Board board, Coordinate placeForQueen)
        {
            var horizontalCells = board.Cells.Where(cell => cell.Coordinate.X == placeForQueen.X);
            return !horizontalCells.Any(cell => cell.OccupiedByQueen);
        }

        private static bool IsSafeVertically(Board board, Coordinate placeForQueen)
        {
            var vertiicalCells = board.Cells.Where(cell => cell.Coordinate.Y == placeForQueen.Y);
            return !vertiicalCells.Any(cell => cell.OccupiedByQueen);
        }

        private static bool IsSafeDiagonally(Board board, Coordinate placeForQueen)
        {
            var diagonalCells = board.Cells
                .Where(cellInfo =>
                {
                    var dx = cellInfo.Coordinate.X - placeForQueen.X;
                    var dy = cellInfo.Coordinate.Y - placeForQueen.Y;
                    return Math.Abs(dx) == Math.Abs(dy);
                });
            return !diagonalCells.Any(cell => cell.OccupiedByQueen);
        }

        private static bool IsSafeToPlace(Board board, Coordinate placeForQueen)
        {
            return IsSafeVertically(board, placeForQueen)
                && IsSafeHorizontally(board, placeForQueen)
                && IsSafeDiagonally(board, placeForQueen);
        }

        private static IEnumerable<Coordinate> FindSafePlaces(Board board)
        {
            return
                board.Cells
                .Where(cellInfo =>
                    !cellInfo.OccupiedByQueen
                    && IsSafeToPlace(board, cellInfo.Coordinate))
                .Select(cellInfo=>cellInfo.Coordinate);
        }
    }
}
