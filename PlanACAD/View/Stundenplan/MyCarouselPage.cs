using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PlanACAD
{
	public class MyCarouselPage : CarouselPage
	{

		/*Day d1 = new Day { DayDate = DateTime.Now };
		Day d2 = new Day { DayDate = DateTime.Now.AddDays (1) };
		ObservableCollection<Day> source; */
		bool hasAppeared;

		StundenplanViewModel VM;

		public MyCarouselPage (StundenplanViewModel VM)
		{
			//source = new ObservableCollection<Day>();

			this.VM = VM;

			//source.Add(d1);
			//source.Add (d2);


			ItemTemplate = new DataTemplate (() => {
				return new DayPage(new DayViewModel(VM, new Day()));
			});

			ItemsSource = VM.DayPages;
			CurrentPage = Children [1];
		}
		bool first = true;

		int previousIndex;
		int leftswipes = 0;




		protected override void OnCurrentPageChanged () {




			base.OnCurrentPageChanged();



			int newIndex = this.Children.IndexOf(CurrentPage);

			Debug.WriteLine ("Prev: " + previousIndex + " New: " + newIndex);
			if (previousIndex ==  0 && newIndex == 0)
				
				return;

			if (newIndex == 0 && previousIndex == 1) {
				Debug.WriteLine ("Anfang erreicht");
				Debug.WriteLine (leftswipes);

				leftswipes--;
				//DayPage left = new DayPage(new DayViewModel(VM, new Day {DayDate = DateTime.Now.AddDays (leftswipes)}));
				//left.Today = DateTime.Now.AddDays (leftswipes);
				VM.DayPages.Insert (0, new Day { DayDate = DateTime.Now.AddDays (leftswipes) });

				newIndex = 1;
			} 

			if (newIndex == Children.Count-1) {
				
				Debug.WriteLine ("Ende erreicht");


				VM.DayPages.Add( new Day { DayDate = DateTime.Now.AddDays (newIndex + 1) });

				CurrentPage = Children [newIndex-1];
				CurrentPage = Children [newIndex];
				previousIndex = newIndex;
			}
			previousIndex = newIndex;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			hasAppeared = true;
			CurrentPage = Children [1];

		}


	}
}


