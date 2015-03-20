using System;
using Xamarin.Forms;

namespace PlanACAD
{
	/// <summary>
	/// Menu view.
	/// </summary>
	public class MenuView : ContentPage
	{

		public ListView Menu { get; private set; }
		private MenuViewModel viewModel;

		public MenuView ()
		{

			this.Title = "Menü";

			BindingContext = viewModel = new MenuViewModel();

			var label = new ContentView {
				Padding = new Thickness (10, 36, 0, 5),
				Content = new Label {
					Text = "Menü"
				}
			};


			Menu = new ListView {
				ItemsSource = viewModel.MenuItems, 
				HasUnevenRows = true,
				RowHeight = 50,
				VerticalOptions = LayoutOptions.FillAndExpand, 
				BackgroundColor = Color.FromHex("#009bff"),
			};

			var cell = new DataTemplate (typeof(MenuCell));
			cell.SetBinding(TextCell.TextProperty, BaseViewModel.TitlePropertyName);
			cell.SetBinding(ImageCell.ImageSourceProperty, BaseViewModel.IconPropertyName);


			Menu.ItemTemplate = cell;

			Content = new StackLayout
			{
				Spacing = 10,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { label, Menu}
			};
		}
	}
}

