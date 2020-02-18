using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

	class Puzzle : Entity<int>, IEqualityComparer<Puzzle>
	{
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

		public bool Equals([AllowNull] Puzzle x, [AllowNull] Puzzle y)
		{
			return x.Id.Equals(y.Id) && x.BrandId.Equals(y.BrandId);
		}

		public int GetHashCode([DisallowNull] Puzzle obj)
		{
			return $"{Id}{BrandId}".GetHashCode();
		}
	}
}
