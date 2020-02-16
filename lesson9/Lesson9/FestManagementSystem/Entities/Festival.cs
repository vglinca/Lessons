using System;
using System.Collections.Generic;
using System.Text;

namespace FestManagementSystem.Entities
{
	class Festival
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string County { get; set; }
		public DateTimeOffset StartDate { get; set; }
		public DateTimeOffset EndDate { get; set; }
		public ICollection<MusicalBand> Bands { get; set; }
	}
}
