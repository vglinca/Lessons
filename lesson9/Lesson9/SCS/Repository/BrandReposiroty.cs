using System;
using System.Collections.Generic;
using System.Text;

namespace SCS.Repository
{
	class BrandReposiroty : Repository<Brand, int>, IBrandRepository
	{
		public override void Update(Brand newEntity, int id)
		{
			base.Update(newEntity, id);
		}
	}
}
