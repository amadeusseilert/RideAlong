using RideAlong.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RideAlong
{
    public partial class Home : ContentPage
    {

        public Home(User user)
        {
            
            InitializeComponent();
            lblUserName.Text = "Hello, " + user.name;
            lblUserRating.Text = "Rating: +" + user.rating.ToString();

            btnSet.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new SetRide());
            };

            btnFind.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new FindRide());
            };

            btnMyRides.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new MyRides());
            };
        }
    }
}
