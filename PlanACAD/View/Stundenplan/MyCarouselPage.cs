using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PlanACAD
{
	public class MyCarouselPage : CarouselPage
	{

		StundenplanViewModel VM;
		int previousIndex;
		int leftswipes = -1;


		public MyCarouselPage (StundenplanViewModel VM)
		{
			//source = new ObservableCollection<Day>();

			this.VM = VM;

			//source.Add(d1);
			//source.Add (d2);
			Title="Stundenplan";

			ItemTemplate = new DataTemplate (() => {
				return new DayPage(new DayViewModel(VM, new Day()));
			});

			ItemsSource = VM.DayPages;
			CurrentPage = Children [1];
		}


		protected override void OnCurrentPageChanged () {

			base.OnCurrentPageChanged();

			int newIndex = this.Children.IndexOf(CurrentPage);

			//Debug.WriteLine ("Prev: " + previousIndex + " New: " + newIndex);
			if (previousIndex ==  0 && newIndex == 0)
				return;

			if (newIndex == 0 && previousIndex == 1) {
				Debug.WriteLine ("Anfang erreicht");
				leftswipes--;
				VM.DayPages.Insert (0, new Day { DayDate = DateTime.Now.AddDays (leftswipes) });
				newIndex = 1;
			} 

			if (newIndex == Children.Count-1) {
				
				Debug.WriteLine ("Ende erreicht");
				VM.DayPages.Add( new Day { DayDate = DateTime.Now.AddDays (newIndex) });
			}
			previousIndex = newIndex;
		}

	}
}


