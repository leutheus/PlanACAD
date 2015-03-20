using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.Generic;

namespace PlanACAD
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public INavigation Navigation { get; set; }
		public bool IsInitialized { get; set; }

		private bool isBusy;
		/// <summary>
		/// Gets or sets the "IsBusy" property
		/// </summary>
		/// <value>The isbusy property.</value>
		public const string IsBusyPropertyName = "IsBusy";
		public bool IsBusy
		{
			get { return isBusy; }
			set { SetProperty(ref isBusy, value, IsBusyPropertyName);  }
		}


		private string title = string.Empty;
		/// <summary>
		/// Gets or sets the "Title" property
		/// </summary>
		/// <value>The title.</value>
		public const string TitlePropertyName = "Title";
		public string Title
		{
			get { return title; }
			set { SetProperty(ref title, value, TitlePropertyName); }
		}

		private string icon = null;
		/// <summary>
		/// Gets or sets the "Icon" of the viewmodel
		/// </summary>
		public const string IconPropertyName = "Icon";
		public string Icon
		{
			get { return icon; }
			set { SetProperty(ref icon, value, IconPropertyName); }
		}

		protected void SetProperty<U>(
			ref U backingStore, U value,
			string propertyName,
			Action onChanged = null,
			Action<U> onChanging = null)
		{
			if (EqualityComparer<U>.Default.Equals(backingStore, value))
				return;

			if (onChanging != null)
				onChanging(value);

			OnPropertyChanging(propertyName);

			backingStore = value;

			if (onChanged != null)
				onChanged();

			OnPropertyChanged(propertyName);
		}

		public event Xamarin.Forms.PropertyChangingEventHandler PropertyChanging;
		public void OnPropertyChanging(string propertyName)
		{
			if (PropertyChanging == null)
				return;

			PropertyChanging(this, new Xamarin.Forms.PropertyChangingEventArgs(propertyName));
		}


		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged == null)
				return;

			//isChanged = true;
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

