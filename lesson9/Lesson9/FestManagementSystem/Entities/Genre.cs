﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FestManagementSystem.Entities
{
	class Genre
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<MusicalBand> Bands { get; set; }
	}
}
