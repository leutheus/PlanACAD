using System;
using System.Collections.Generic;

namespace PlanACAD
{
	/// <summary>
	/// Lesson
	/// </summary>
	public class Lesson
	{


		public Lesson() : base () {
			
		}

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>The date.</value>
		public String Datum { get; set; }

		/// <summary>
		/// Gets or sets the date string.
		/// </summary>
		/// <value>The date string.</value>
		public string DateString { get; set; }

		/// <summary>
		/// Gets or sets the hour.
		/// </summary>
		/// <value>The hour.</value>
		public int Stunde { get; set; }

		/// <summary>
		/// Gets or sets the start.
		/// </summary>
		/// <value>The start.</value>
		public String Beginn { get; set; }

		/// <summary>
		/// Gets or sets the start string.
		/// </summary>
		/// <value>The start string.</value>
		public string StartString { get; set; }

		/// <summary>
		/// Gets or sets the end.
		/// </summary>
		/// <value>The end.</value>
		public String Ende { get; set; }

		/// <summary>
		/// Gets or sets the end string.
		/// </summary>
		/// <value>The end string.</value>
		public string EndString { get; set; }

		/// <summary>
		/// Gets or sets the lesson units.
		/// </summary>
		/// <value>The lesson units.</value>
		public List<LessonDescription> Faecher { get; set; }

		/// <summary>
		/// Gets or sets the teacher.
		/// </summary>
		/// <value>The teacher.</value>
		public string Dozent { get; set; }

		/// <summary>
		/// Gets or sets the room.
		/// </summary>
		/// <value>The room.</value>
		public string Raum { get; set; }

	}
}

