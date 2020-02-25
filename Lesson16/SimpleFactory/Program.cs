using System;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var puzzle = RubicsCubePuzzleFactory.CreatePuzzle("4x4x4 cube", 4, PlasticColor.STICKERLESS, true, 55.2, false);
            Console.WriteLine(puzzle.ToString());

            var puzzle1 = RubicsCubePuzzleFactory.CreatePuzzle("3x3x3 cube", 3, PlasticColor.GREEN, true, 55.6, true);
            Console.WriteLine(puzzle1.ToString());
        }
    }
}
