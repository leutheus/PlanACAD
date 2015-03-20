using System;
using Xamarin.Forms;

namespace PlanACAD
{
	/// <summary>
	/// Start view. Entry Point of the Application
	/// </summary>
	public class StartView : MasterDetailPage
	{
		/// <summary>
		/// The previous selected menu item.
		/// </summary>
		private MenuType previousItem;

		/// <summary>
		/// Navigation Pages.
		/// </summary>
		NavigationPage Stundenplan, calendar, news, settings, unterricht;

		public StartView ()
		{

			var optionsPage = new MenuView();

			optionsPage.Menu.ItemSelected += (sender, e) =>
			{

				var item = e.SelectedItem as MenuItem;
				if (item == null)
					return;

				NavigateTo(item.MenuType);
				optionsPage.Menu.SelectedItem = null;
			};
			Master = optionsPage;
			previousItem = MenuType.Kalender;
			//vm = new StartViewModel {Navigation=Navigation};
			NavigateTo (MenuType.Stundenplan);

		}

		/// <summary>
		/// Sets the display page to the selected menu item.
		/// </summary>
		/// <param name="option">Option.</param>
		void NavigateTo(MenuType option)
		{
			if (previousItem == option)
				return;

			previousItem = option;
			var displayPage = PageForOption (option);
			Detail = displayPage;
			IsPresented = false;
		}

		/// <summary>
		/// Returns the Navigation Pages for selected menu option.
		/// </summary>
		/// <returns>The for option.</returns>
		/// <param name="option">Option.</param>
		NavigationPage PageForOption (MenuType option)
		{
			switch (option) {
			case MenuType.Stundenplan:
				{
					if (Stundenplan != null)
						return Stundenplan;

					Stundenplan = new NavigationPage (new StundenplanPage (new StundenplanViewModel()));
					return Stundenplan;
				}
			case MenuType.Kalender:
				{
					if (calendar != null)
						return calendar;

					//calendar = new NavigationPage(new CalendarPage (new CalendarViewModel(), new CalendarDayViewModel()));

					return calendar;
				}
			case MenuType.News:
				{
					if (news != null)
						return news;

					//news = new NavigationPage(new newsView (vm));
					return news;
				}
			case MenuType.Einstellungen: 
				{
					if (settings != null)
						return settings;
					//SettingsViewModel settingsVM = new SettingsViewModel ();
					//settings = new NavigationPage(new SettingsView(settingsVM));
					return settings;
				}

			}
			throw new NotImplementedException("Unknown menu option: " + option.ToString());
		}

	}
}

