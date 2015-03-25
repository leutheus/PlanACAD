using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace PlanACAD
{
	public partial class DayPage : ContentPage
	{
		

		public Boolean IsInitialized;

		public DayViewModel ViewModel;



		public DayPage (DayViewModel vm)
		{
			InitializeComponent ();

			this.BindingContext = vm;
			this.ViewModel = vm;
			//M.GetScheduleForDay (Today);

		}

	protected override void OnAppearing() {
			base.OnAppearing ();

			if (!IsInitialized) {
				
			

			Day d = (Day)BindingContext;
		
			
			Device.BeginInvokeOnMainThread (() => {
				Circle.IsVisible = true;
				Circle.IsRunning = true;
				DateLabel.Text = d.DayDate.ToShortDateString ();
				

			});

			Console.WriteLine ("DEBUG \t "  + d.DayDate.ToShortDateString());
			ViewModel.myDay = d;

				
			if (ViewModel != null) {
				ViewModel.LoadDay.Execute (null);
			}
			

			Device.BeginInvokeOnMainThread (() => {
				ScheduleView.ItemsSource = ViewModel.Lessons;
				Circle.IsVisible = false;
				Circle.IsRunning = false;
			});
				IsInitialized = true;
			}

		}

		public void OnItemSelected (object sender, ItemTappedEventArgs e) {
			if (e.Item == null)
				return;
			Navigation.PushAsync (new LessonDetailView (e.Item as Lesson));
		}
	}
}

 