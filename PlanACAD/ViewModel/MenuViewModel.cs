using System;
using System.Collections.ObjectModel;

namespace PlanACAD
{

	/// <summary>
	/// Menu view model.
	/// </summary>
	public class MenuViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or sets the menu items.
		/// </summary>
		/// <value>The menu items.</value>
		public ObservableCollection<MenuItem> MenuItems { get; set; }

		public MenuViewModel ()
		{

			Title = "planACAD mobile";
			MenuItems = new ObservableCollection<MenuItem> ();
			MenuItems.Add (new MenuItem {
				Id = 0, Title = "Stundenplan", MenuType = MenuType.Stundenplan, Icon="home.png"
			});
			MenuItems.Add (new MenuItem {
				Id = 1, Title = "Kalender", MenuType = MenuType.Kalender, Icon="calendar.png"
			});
			MenuItems.Add (new MenuItem {
				Id = 2, Title = "News", MenuType = MenuType.News, Icon="news.png"
			});
			MenuItems.Add (new MenuItem {
				Id = 3, Title = "Einstellungen", MenuType = MenuType.Einstellungen, Icon="settings.png"
			});
		}
	}
}

