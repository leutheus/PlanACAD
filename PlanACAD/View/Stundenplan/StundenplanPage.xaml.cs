using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace PlanACAD
{
	public partial class StundenplanPage : ContentPage
	{

		StundenplanViewModel ViewModel;



		public StundenplanPage (StundenplanViewModel ViewModel)
		{
			InitializeComponent ();
			this.ViewModel = ViewModel;
			this.BindingContext = ViewModel;

		}


		protected override void OnAppearing ()
		{
			if (ViewModel.IsInitialized)
				return; 
			ViewModel.LoadWeeklySchedule.Execute (null);
		}

	
	}
}

