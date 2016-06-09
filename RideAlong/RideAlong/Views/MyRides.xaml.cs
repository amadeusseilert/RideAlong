using RideAlong.Entities;
using RideAlong.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RideAlong
{
    public partial class MyRides : ContentPage
    {
        private List<Ride> settedRides;
        private List<Ride> markedRides;

        public MyRides(string name)
        {
            InitializeComponent();
            Title = "My Rides";

            try {
                IEnumerable<Ride> temp = App.dbRide.GetItemOwner(name);
                settedRides = temp.ToList();
                markedRides = App.dbRide.GetItems().Except(temp).ToList();

            } catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
            
           

            btnSetted.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new MyRides_Setted(settedRides));
            };

            btnMarked.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new MyRides_Marked(markedRides));
            };
        }
    }
}
