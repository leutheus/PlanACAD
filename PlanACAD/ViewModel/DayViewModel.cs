using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace PlanACAD
{
	public class DayViewModel : BaseViewModel
	{

		StundenplanViewModel StundenPlanVM;
		IDataManager DataManager;

		public Day myDay {get; set;}
	
		public ObservableCollection<Lesson> Lessons { get; set; }


		public DayViewModel (StundenplanViewModel StundenPlanViewModel, Day MyDate)
		{
			this.myDay = MyDate;

			DataManager = DependencyService.Get<IDataManager> ();
			StundenPlanVM = StundenPlanViewModel;
			Lessons = new ObservableCollection<Lesson> ();
		}


		private Command loadDay;
		public Command LoadDay {
			get {
				return loadDay ?? (loadDay = new Command (async () => await ExecuteLoadDayCommand ()));
			}
		}

		public async Task ExecuteLoadDayCommand() {
			if (IsBusy)
				return;
			IsBusy = true;
			Lessons.Clear ();
			Console.WriteLine ("DayViewModel:/t Loading Lessons for " + myDay.DayDate.ToShortDateString());
			List<Lesson> result = await DataManager.GetDayAsync (myDay.DayDate);

			foreach (Lesson l  in result) {
				//Console.WriteLine ("DayViewModel: " + l.Faecher[0].Bezeichnung);
				Lessons.Add (l);
			}
			myDay.Schedule = result;
			IsBusy = false;
			//myDay.Schedule = result;
		}



		//public async void  GetDay(Day d) {
			

			//Lessons = await StundenPlanVM.GetScheduleForDay (d);
		//}

		/*public async Task<List<Lesson>> GetSchedule() {
			List<Lesson> result = new List<Lesson>();
			try {
				//result = await DataManager.GetDayAsync (MyDay);
			} catch (Exception e) {
				Debug.WriteLine (e.Message);
			}
			return result; 
		} */
	}
}

