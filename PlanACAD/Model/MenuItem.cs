using System;

namespace PlanACAD
{
	/// <summary>
	/// Menu item.
	/// </summary>
	public class MenuItem : BaseModel
	{
		/// <summary>
		/// Gets or sets the icon.
		/// </summary>
		/// <value>The icon.</value>
		public string Icon { get; set;}

		/// <summary>
		/// Gets or sets the type of the menu.
		/// </summary>
		/// <value>The type of the menu.</value>
		public MenuType MenuType { get; set;} 


		/// <summary>
		/// Initializes a new instance of the <see cref="PlanACAD.MenuItem"/> class.
		/// </summary>
		public MenuItem ()
		{
			MenuType = MenuType.Stundenplan;
		}
	}


	/// <summary>
	/// Menu type.
	/// </summary>
	public enum MenuType {
		Stundenplan, 
		Kalender,
		News,
		Einstellungen
	}
}

