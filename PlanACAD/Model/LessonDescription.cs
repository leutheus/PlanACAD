using System;

namespace PlanACAD
{
	/// <summary>
	/// Lesson description. Lesson Number and Lesson Level 
	/// </summary>
	public class LessonDescription
	{
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public string Bezeichnung { get; set; }

		/// <summary>
		/// Gets or sets the lesson number.
		/// </summary>
		/// <value>The lesson number.</value>
		public string FachNr { get; set; }

		/// <summary>
		/// Gets or sets the level.
		/// </summary>
		/// <value>The level.</value>
		public int Level { get; set; }
	}
}

