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
				Console.WriteLine (d);
				var calResponse = await httpClient.GetAsync (String.Format("http://10.0.19.2/api/stdplan/pac_baer_s_201309{0:D2}_201309{1:D2}" , d, d+1));
				var calResponseText = await calResponse.Content.ReadAsStringAsync ();
				var calResponse2 = await httpClient.GetAsync (String.Format("http://10.0.19.2/api/stdplan/pac_baer_s_201309{0:D2}_201309{1:D2}" , d, d+1));
				var calResponseText2 = await calResponse2.Content.ReadAsStringAsync ();
				Console.WriteLine ("!\tResult Data for Day: " + calResponseText2);
				List<Lesson> result = JsonConvert.DeserializeObject<List<Lesson>> (calResponseText2);
				return result;
			}

			//return new List<Lesson>();
		}

	}
}

