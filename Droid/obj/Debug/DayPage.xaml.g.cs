//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlanACAD {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class DayPage : ContentPage {
        
        private ActivityIndicator Circle;
        
        private Label DateLabel;
        
        private ListView ScheduleView;
        
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(DayPage));
            Circle = this.FindByName<ActivityIndicator>("Circle");
            DateLabel = this.FindByName<Label>("DateLabel");
            ScheduleView = this.FindByName<ListView>("ScheduleView");
        }
    }
}
