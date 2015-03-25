using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PlanACAD
{
	public class StundenplanViewModel : BaseViewModel
	{

		public ObservableCollection<Day> DayPages;


		IDataManager DataManager;

		private ObservableCollection<Week> weeklySchedules;
		public ObservableCollection<Week> weeklySchedule {
			get { 
				return weeklySchedule;
			}
			set { 
				weeklySchedules = value;
				OnPropertyChanged ("WeeklySchedule");
			}
		}



		public StundenplanViewModel ()
		{
			weeklySchedule = new ObservableCollection<Week> ();
			DataManager = DependencyService.Get<IDataManager> ();
		
			DayPages = new ObservableCollection<Day> ();
			DayPages.Add (new Day { DayDate = DateTime.Now.AddDays(-1)});
			DayPages.Add (new Day { DayDate = DateTime.Now });
			DayPages.Add (new Day { DayDate = DateTime.Now.AddDays(1)});

		}

		private Command loadWeeklySchedule;
		public Command LoadWeeklySchedule {
			get {
				return loadWeeklySchedule ?? (loadWeeklySchedule = new Command (async () => await ExecuteLoadWeeklyScheduleCommand ()));
			}
		}

		public async Task ExecuteLoadWeeklyScheduleCommand() {
			if (IsBusy)
				return;

			//TODO
			IsBusy = true;
			var day = await DataManager.GetDayAsync (DateTime.Now);
			Debug.WriteLine("Loaded Day");
		}

		public async Task<List<Lesson>> GetScheduleForDay(Day ThisDay) {
			Console.WriteLine ("Need data for " + ThisDay.DayDate.ToShortDateString ());

			List<Lesson> result = new List<Lesson>();
			try {
				result = await DataManager.GetDayAsync (ThisDay.DayDate);
			} catch (Exception e) {
				Debug.WriteLine (e.Message);
			}
			return result; 
				
			//IS ALREADY LOADED?
			//IS IN DATABASE?

			//LOAD FROM SERVER

		}
	}
}

