using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SCS
{
	class Brand : Entity<int>, IEqualityComparer<Brand>
	{
		public string Name { get; set; }
		public string? Description { get; set; }

		public bool Equals([AllowNull] Brand x, [AllowNull] Brand y)
		{
			return x.Id.Equals(y.Id);
		}

		public int GetHashCode([DisallowNull] Brand obj)
		{
			return $"{Id}{Name}".GetHashCode();
		}
	}
}
