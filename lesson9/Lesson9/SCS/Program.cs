using SCS.Repository;
using System;

namespace SCS
{
	class Program
	{
		static void Main(string[] args)
		{
			var handler = new RepositoryHandler();
			IRepository<Brand> brandRepository = handler.GetRepository<Brand>();

			brandRepository.Insert(new Brand { Id = 1, Name = "Gan", Description = "" });
			brandRepository.Insert(new Brand { Id = 2, Name = "MoYu", Description = "" });
			brandRepository.Insert(new Brand { Id = 3, Name = "Qiyi", Description = "" });
			brandRepository.Insert(new Brand { Id = 4, Name = "YuXin", Description = "" });

			foreach (var brand in brandRepository.GetAll())
			{
				Console.WriteLine($"Id = {brand.Id} | Name = {brand.Name}");
			}

			var brandById = brandRepository.GetById(2);
			Console.WriteLine($"\nId = {brandById.Id} | Name = {brandById.Name}\n");

			//brandRepository.Delete(brandRepository.GetById(4));

			foreach (var brand in brandRepository.GetAll())
			{
				Console.WriteLine($"Id = {brand.Id} | Name = {brand.Name}");
			}

			IRepository<Puzzle> puzzleRepository = handler.GetRepository<Puzzle>();

			puzzleRepository.Insert(new Puzzle
			{
				Id = 1,
				Name = "Gan 356 X Ipg v5",
				Brand = brandRepository.GetById(1),
				PuzzleType = PuzzleType.RubicsCube,
				Layers = 3,
				IsMagnetic = true,
				PlasticType = PuzzlePlasticType.Stickerless,
				DifficultyType = PuzzleDifficultyType.Medium,
				IsWca = true,
				Price = 60,
				Rating = 10
			});

			puzzleRepository.Insert(new Puzzle
			{
				Id = 2,
				Name = "Gan 356 XS",
				Brand = brandRepository?.GetById(1),
				PuzzleType = PuzzleType.RubicsCube,
				Layers = 3,
				IsMagnetic = true,
				PlasticType = PuzzlePlasticType.Stickered,
				DifficultyType = PuzzleDifficultyType.Medium,
				IsWca = true,
				Price = 67,
				Rating = 8
			});

			puzzleRepository.Insert(new Puzzle
			{
				Id = 3,
				Name = "MoYu GTS V3",
				Brand = brandRepository?.GetById(2),
				PuzzleType = PuzzleType.RubicsCube,
				Layers = 3,
				IsMagnetic = true,
				PlasticType = PuzzlePlasticType.Stickerless,
				DifficultyType = PuzzleDifficultyType.Medium,
				IsWca = true,
				Price = 31,
				Rating = 9
			});

			puzzleRepository.Insert(new Puzzle
			{
				Id = 4,
				Name = "Gan Megaminx",
				Brand = brandRepository?.GetById(1),
				PuzzleType = PuzzleType.Megaminx,
				IsMagnetic = true,
				PlasticType = PuzzlePlasticType.Stickerless,
				DifficultyType = PuzzleDifficultyType.Medium,
				IsWca = true,
				Price = 45,
				Rating = 7
			});
			Console.WriteLine();
			foreach (var puzzle in puzzleRepository.GetAll())
			{
				Console.WriteLine($"Id: {puzzle.Id} | Name: {puzzle.Name}" +
					$"\t| Brand: {puzzle?.Brand.Name}");
			}
		}
	}
}
