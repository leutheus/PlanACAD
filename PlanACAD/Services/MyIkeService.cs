using System;
using PlanACAD;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using ModernHttpClient;
using System.Net.Http;
using Newtonsoft.Json;


[assembly: Xamarin.Forms.Dependency(typeof(MyIkeService))]

namespace PlanACAD
{
	public class MyIkeService : IDataManager
	{
		public MyIkeService ()
		{
		}

		public async Task<List<Lesson>> GetDayAsync(DateTime Day) {
			Console.WriteLine ("!\tLoading Data for Day: " + Day.ToShortDateString ());


			using (var httpClient = new HttpClient()) {
				httpClient.Timeout = TimeSpan.FromSeconds (10);

				int d = Day.Day;
				Console.WriteLine ("MYIKESERVICE\t Needed:  " + d);
				int DaysInMonth = DateTime.DaysInMonth(Day.Year, Day.Month);
				Console.WriteLine ("MYIKESERVICE\t Month has:  " + DaysInMonth);

				var requestString = "";
				//TODO switch
					
				if (d + 2 > DaysInMonth) {
					Console.WriteLine ("Ask for next month");
					d = 1;
					requestString = String.Format ("http://10.0.19.2/api/stdplan/pac_baer_s_201310{0:D2}_201310{1:D2}", d, d + 1);
				} else {
					requestString = String.Format ("http://10.0.19.2/api/stdplan/pac_baer_s_201309{0:D2}_201309{1:D2}", d, d + 1);
				}

				var calResponse = await httpClient.GetAsync (requestString);
				var calResponseText = await calResponse.Content.ReadAsStringAsync ();
				var calResponse2 = await httpClient.GetAsync (requestString);
				var calResponseText2 = await calResponse2.Content.ReadAsStringAsync ();
				Console.WriteLine ("!\tResult Data for Day: " + calResponseText2);
				List<Lesson> result = JsonConvert.DeserializeObject<List<Lesson>> (calResponseText2);
				return result;
			}

			//return new List<Lesson>();
		}

	}
}

