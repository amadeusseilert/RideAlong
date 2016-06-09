using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RideAlong.Entities;
using RideAlong.Resources;

using Xamarin.Forms;
using RideAlong.Views;
using System.Net;

namespace RideAlong
{
    public partial class FindRide: ContentPage{

		public FindRide(List<Locations> locations){
			InitializeComponent();

            Title = "Find a Ride";
			
			Label lblOrigin = new Label{ Text = "Origin:", HorizontalOptions = LayoutOptions.Start };
			Label lblDestination = new Label{ Text = "Destination:", HorizontalOptions = LayoutOptions.Start };
			Picker pickerOrigin = new Picker{ VerticalOptions = LayoutOptions.CenterAndExpand };
			Picker pickerDestination = new Picker{ VerticalOptions = LayoutOptions.CenterAndExpand };

			foreach (Locations loc in locations){
				pickerOrigin.Items.Add(loc.name);
				pickerDestination.Items.Add(loc.name);
			}
				
			Label lblData = new Label {
				Text = "Date:",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalTextAlignment = TextAlignment.Start
			};

            DatePicker datepicker = new DatePicker {
                Date = DateTime.Now,
                Format = "dd-MM-yyyy",
                MinimumDate = DateTime.Now.Date,
				MaximumDate = DateTime.Now.AddMonths(6)
			};

			Label lblTime = new Label
			{
				Text = "Time:",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalTextAlignment = TextAlignment.Start
			};

			TimePicker timepicker = new TimePicker{
                Time = DateTime.Now.TimeOfDay
            };

			Button btnAdd = new Button {
				IsEnabled = false,
				Margin = 10,
				Text = "Buscar caronas",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			btnAdd.Clicked += async (sender, e) => {
				string origin = pickerOrigin.Items[pickerOrigin.SelectedIndex];
				string destination = pickerDestination.Items[pickerDestination.SelectedIndex];
				string date = datepicker.Date.ToString("dd-MM-yyyy");
				string time = timepicker.Time.ToString(@"hh\:mm");
                try
                {
                    string jsonFoundRides = await Web.WebService.GET(Settings.WebServiceURL + API.API_GetRides +
                        origin + "/" + destination + "/" + date + "/" + time);
                    if (jsonFoundRides == "[]" || jsonFoundRides == null)
                    {
                        await DisplayAlert("No rides Found!", "No rides were found that matches your search.", "Ok");
                    }
                    else
                    {
                        await Navigation.PushAsync(new ListFoundRides(jsonFoundRides));
                    }
                } catch (WebException we)
                {
                    await DisplayAlert("Error", we.Message, "Ok");
                }
		
			};


			pickerOrigin.SelectedIndexChanged += (sender, args) =>{
				if (pickerOrigin.SelectedIndex == pickerDestination.SelectedIndex){
					btnAdd.IsEnabled = false;;
					pickerOrigin.BackgroundColor = Color.Red;
					pickerDestination.BackgroundColor = Color.Red;
				}
				else{                    
					btnAdd.IsEnabled = (pickerOrigin.SelectedIndex != -1 && pickerDestination.SelectedIndex != -1);
					pickerOrigin.BackgroundColor = Color.Default;
					pickerDestination.BackgroundColor = Color.Default;
				}
			};

			pickerDestination.SelectedIndexChanged += (sender, args) => {
				if (pickerOrigin.SelectedIndex == pickerDestination.SelectedIndex)
				{
					btnAdd.IsEnabled = false;
					pickerOrigin.BackgroundColor = Color.Red;
					pickerDestination.BackgroundColor = Color.Red;
				}
				else
				{
					btnAdd.IsEnabled = (pickerOrigin.SelectedIndex != -1 && pickerDestination.SelectedIndex != -1);
					pickerOrigin.BackgroundColor = Color.Default;
					pickerDestination.BackgroundColor = Color.Default;
				}
			};

			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);


			this.Content = new StackLayout
			{
				Children =
				{
					lblOrigin,
					pickerOrigin,
					lblDestination,
					pickerDestination,
					lblData,
					datepicker,
					lblTime,
					timepicker,
					btnAdd
				}
				};


		}
	}
}
