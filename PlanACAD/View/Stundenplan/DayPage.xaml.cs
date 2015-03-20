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
		public StundenplanViewModel VM;
		public DateTime Today;
		public Boolean IsInitialized;
		public DayPage (StundenplanViewModel VM)
		{
			InitializeComponent ();
			this.VM = VM;

			Debug.WriteLine ("day created");

			//M.GetScheduleForDay (Today);

		}

		async protected override void OnAppearing() {
			base.OnAppearing ();
			//DateTime today = DateTime.Parse (DateLabel.Text);
			Console.WriteLine (DateLabel.Text);

			if (!IsInitialized) {
				DateTime today = DateTime.ParseExact(DateLabel.Text, "MM/dd/yyyy HH:mm:ss", null);
				List<Lesson> lessons = await VM.GetScheduleForDay (today);
				Device.BeginInvokeOnMainThread (() => {
					LessonLabel.Text = lessons[0].Faecher[1].Bezeichnung;
					LessonLabel.Text = lessons[0].Beginn;
				});
				IsInitialized = true;
			}
		}
	}
}

 