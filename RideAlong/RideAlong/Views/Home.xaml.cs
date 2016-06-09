using RideAlong.Entities;
using RideAlong.Sqlite;
using RideAlong.Web;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using RideAlong.Resources;
using Newtonsoft.Json;
using System.Net;
using System.Diagnostics;

namespace RideAlong
{
    public partial class Home : ContentPage
    {
        private List<Locations> locations;
        private User user { get; set; }

        public Home(User user)
        {
            InitializeComponent();
            locations = null;

            this.user = App.dbUser.GetItemFacebookId(user.id);

            if (this.user == null)
            {
                this.user = user;
                App.dbUser.SaveItem(this.user);
                
            }          

            lblUserName.Text = "Hello, " + this.user.name;
            lblUserRating.Text = "Rating: +" + this.user.rating.ToString();

            btnSet.Clicked += async (sender, e) => {
                await setLocations();
                await Navigation.PushAsync(new SetRide(locations, user));
            };

            btnFind.Clicked += async (sender, e) => {
                await setLocations();
                await Navigation.PushAsync(new FindRide(locations));
            };

            btnMyRides.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new MyRides(this.user.name));
            };
        }

        private async Task setLocations()
        {
            if (locations == null)
            {
                try
                {
                    string jsonLocations = await WebService.GET(Settings.WebServiceURL + "api/locations");
                    locations = JsonConvert.DeserializeObject<List<Locations>>(jsonLocations);
                } catch (WebException we)
                {
                    Debug.WriteLine(we.Message);
                }
                
            }
        }
    }
}
