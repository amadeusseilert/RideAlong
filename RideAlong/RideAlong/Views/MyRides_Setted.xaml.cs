using RideAlong.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RideAlong.Views
{
    public partial class MyRides_Setted : ContentPage
    {

        public MyRides_Setted(List<Ride> rides)
        {
            InitializeComponent();


            Title = "Setted Rides";
            Label message = new Label
            {
                Text = ""
            };

            if (rides.Count == 0)
            {
                message.Text = "No rides found.";
            }

            ListView view = new ListView
            {
                ItemsSource = rides,
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(RideCellModel))
            };

            // Accomodate iPhone status bar.
            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            Content = new StackLayout
            {
                Children =
                {
                    message,
                    view
                }
            };
        }


    }
}
