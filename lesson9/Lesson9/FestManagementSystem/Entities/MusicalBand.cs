using System;
using System.Collections.Generic;
using System.Text;

namespace FestManagementSystem.Entities
{
	class MusicalBand
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
		public string Country { get; set; }
		public int GenreId { get; set; }
		public Genre Genre { get; set; }
		public int FestId { get; set; }
		public Festival Fest { get; set; }
	}
}
