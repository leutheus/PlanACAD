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
				HttpResponseMessage calResponse = await httpClient.GetAsync ("http://10.0.19.2/kpallg/kpMobile.ashx?p=baer:s");
				var calResponseText = await calResponse.Content.ReadAsStringAsync ();
				var calResponse2 = await httpClient.GetAsync ("http://10.0.19.2/kpallg/kpMobile.ashx?p=baer:s");
				var calResponseText2 = await calResponse2.Content.ReadAsStringAsync ();
				Console.WriteLine ("!\tResult Data for Day: " + calResponseText2);
				List<Lesson> result = JsonConvert.DeserializeObject<List<Lesson>> (calResponseText2);
				return result;
			}

			return new List<Lesson>();
		}

	}
}

