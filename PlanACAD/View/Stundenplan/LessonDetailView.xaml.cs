using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PlanACAD
{
	public partial class LessonDetailView : ContentPage
	{

		public Lesson Lesson { get; set; }

		public LessonDetailView (Lesson l) 
		{
			InitializeComponent ();
			Lesson = l;
			BindingContext = l;
		}
	}
}

