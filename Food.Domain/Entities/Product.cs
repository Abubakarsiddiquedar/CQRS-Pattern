﻿using Food.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Domain.Entities
{
	public class Product : BaseEntity
	{
		public string? Name { get; set; }
		public string? Description { get; set; }

		public decimal Rate { get; set; }
	}
}
