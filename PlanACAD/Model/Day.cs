using System;
using System.Collections.Generic;

namespace PlanACAD
{
	public class Day
	{
		public Boolean IsBusy { get ; set; }
		public DateTime DayDate { get ; set; }
		public List<Lesson> Schedule { get; set; }
	}
}

