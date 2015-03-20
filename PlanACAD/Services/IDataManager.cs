using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanACAD
{
	public interface IDataManager
	{

		/// <summary>
		/// Gets the day async.
		/// </summary>
		/// <returns>The day async.</returns>
		/// <param name="Day">Day.</param>
		Task<List<Lesson>> GetDayAsync(DateTime Day); 
	}
}

