using System;
using System.Collections.Generic;
using System.Text;

namespace SCS.Repository
{
	class PuzzleRepository : Repository<Puzzle, int>, IPuzzleRepository
	{
		public override void Delete(Puzzle entity)
		{
			base.Delete(entity);
		}

		public override IEnumerable<Puzzle> GetAll()
		{
			return base.GetAll();
		}
	}
}
