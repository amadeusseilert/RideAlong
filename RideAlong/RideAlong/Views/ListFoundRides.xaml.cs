using Newtonsoft.Json;
using RideAlong.Entities;
using System.Collections.Generic;
using RideAlong.Resources;
using Xamarin.Forms;

namespace RideAlong.Views
{
    public partial class ListFoundRides : ContentPage
    {

        public ListFoundRides(string jsonFoundRides)
        {
            List<Ride> rides = JsonConvert.DeserializeObject<List<Ride>>(jsonFoundRides);
            Title = "Search Result";
            var ridesList = new ListView
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(RideCellModel)),
                ItemsSource = rides,
                SeparatorColor = Color.FromHex("#ddd"),
            };

            var layout = new StackLayout
            {
                Children = {
					ridesList
                }
            };

            var page = new ContentPage
            {
                Content = layout,
                Title = "Rearch Result",
            };

            Content = layout;

            // Accomodate iPhone status bar.
            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            ridesList.ItemSelected += async (sender, e) => {
                if (e.SelectedItem != null)
                {
                    var resp = await DisplayAlert("Ride Selected", "Do you want to ask for this ride?", "Yes", "No");
                    if (resp == true)
                    {
                        var selected = e.SelectedItem as Ride;

                        string result = await Web.WebService.DELETE(Settings.WebServiceURL + API.API_ReserveRide + selected.ID);
                        if (string.Compare(result, Strings.WS_OK) == 0)
                        {
                            App.dbRide.SaveItem(selected);
                            await DisplayAlert("Success!", "Your ride has been reserved.", "Ok");
                            while (Navigation.NavigationStack.Count > 2)
                            {
                                await Navigation.PopAsync();
                            }
                            
                        } else
                        {
                            await DisplayAlert("Error!", "Could not reserve your ride.", "Ok");
                            await Navigation.PopAsync();
                        }

                    }
                    else
                    {
                        //					e.SelectedItem = null;
                        ridesList.SelectedItem = null;
                    }
                }
            };

        }
    }
}

