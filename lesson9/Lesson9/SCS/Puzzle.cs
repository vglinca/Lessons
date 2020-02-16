using System;
using System.Collections.Generic;
using System.Text;

namespace SCS
{
	public enum PuzzlePlasticType
	{
		Stickered, Stickerless
	}

	public enum PuzzleDifficultyType
	{
		Low, Medium, High, ExtraHigh
	}
	public enum PuzzleType
	{
		RubicsCube, Megaminx, Skewb, SquareOne, Cuboid, ChangingShape
	}

	class Puzzle
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int BrandId { get; set; }
		public Brand Brand { get; set; }
		public PuzzleType PuzzleType { get; set; }
		public PuzzlePlasticType PlasticType { get; set; }
		public PuzzleDifficultyType DifficultyType { get; set; }
		public int? Layers { get; set; }
		public double Rating { get; set; }
		public double Price { get; set; }
		public bool IsMagnetic { get; set; }
		public bool IsWca { get; set; }
		public int ItemsExist { get; set; }
		public string? Description { get; set; }
	}
}
