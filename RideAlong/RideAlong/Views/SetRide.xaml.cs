using System.Collections.Generic;
using RideAlong.Resources;
using Xamarin.Forms;
using RideAlong.Entities;
using System;
using Newtonsoft.Json;
using System.Net;

namespace RideAlong
{
    public partial class SetRide : ContentPage
    {
        public SetRide(List<Locations> locations, User user)
        {
            InitializeComponent();

            Ride newRide = new Ride();

            Label lblOrigin = new Label { Text = "Origin:", HorizontalOptions = LayoutOptions.Start };

            Label lblDestination = new Label { Text = "Destination:", HorizontalOptions = LayoutOptions.Start };

            Picker pickerOrigin = new Picker { VerticalOptions = LayoutOptions.CenterAndExpand };

            Picker pickerDestinations = new Picker { VerticalOptions = LayoutOptions.CenterAndExpand };

            foreach (Locations l in locations)
            {
                pickerOrigin.Items.Add(l.name);
                pickerDestinations.Items.Add(l.name);
            }

            Label lblDate = new Label
            {
                Text = "Date:",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Start
            };

            DatePicker pickerDate = new DatePicker
            {
                Date = DateTime.Now,
                Format = "dd-MM-yyyy",
                MinimumDate = DateTime.Now.Date,
                MaximumDate = DateTime.Now.AddMonths(6)
            };

            Label lblStepper = new Label
            {
                Text = "Slots count: 4",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Start
            };

            Stepper stepperSlots = new Stepper
            {
                Value = 4,
                Maximum = 6,
                Minimum = 1,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            stepperSlots.ValueChanged += (sender, e) =>
            {
                lblStepper.Text = "Slots count: " + Convert.ToString(e.NewValue);
            };

            Label lblTime = new Label
            {
                Text = "Time:",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Start
            };

            TimePicker pickerTime = new TimePicker { Time = DateTime.Now.TimeOfDay };

            Button btnAdd = new Button
            {
                IsEnabled = false,
                Margin = 10,
                Text = "Criar carona!",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Label lblRes = new Label
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            btnAdd.Clicked += async (sender, e) => {

                newRide.origin = Convert.ToString(pickerOrigin.Items[pickerOrigin.SelectedIndex]);
                newRide.destination = Convert.ToString(pickerDestinations.Items[pickerDestinations.SelectedIndex]);
                newRide.date = pickerDate.Date.ToString("dd/MM/yyyy");
                newRide.time = pickerTime.Time.ToString(@"h\:mm");
                newRide.slots = (int) stepperSlots.Value;
                newRide.driver = user.name;

                string j = JsonConvert.SerializeObject(newRide);

                try
                {
                    string dynamodb_id = await Web.WebService.POST(Settings.WebServiceURL + "api/add/ride/", j);
                    if (dynamodb_id != null)
                    {
                        Ride result_id = JsonConvert.DeserializeObject<Ride>(dynamodb_id);
                        newRide.id = result_id.id;
                        App.dbRide.SaveItem(newRide);
                        await DisplayAlert("Success!", "Your ride has been setted.", "Ok");
                        await Navigation.PopAsync(); 
                    } else
                    {
                        await DisplayAlert("Error!", "Could not connect to web service.", "Ok");
                    }
                } catch (WebException we)
                {
                    await DisplayAlert("Error!", we.Message, "Ok");
                }
                
            };

            pickerOrigin.SelectedIndexChanged += (sender, args) => {
                if (pickerOrigin.SelectedIndex == pickerDestinations.SelectedIndex)
                {
                    btnAdd.IsEnabled = false;
                    pickerOrigin.BackgroundColor = Color.Red;
                    pickerDestinations.BackgroundColor = Color.Red;
                }
                else
                {
                    btnAdd.IsEnabled = (pickerOrigin.SelectedIndex != -1 && pickerDestinations.SelectedIndex != -1);
                    pickerOrigin.BackgroundColor = Color.Default;
                    pickerDestinations.BackgroundColor = Color.Default;
                }
            };

            pickerDestinations.SelectedIndexChanged += (sender, args) => {
                if (pickerOrigin.SelectedIndex == pickerDestinations.SelectedIndex)
                {
                    btnAdd.IsEnabled = false;
                    pickerOrigin.BackgroundColor = Color.Red;
                    pickerDestinations.BackgroundColor = Color.Red;
                }
                else
                {
                    btnAdd.IsEnabled = (pickerOrigin.SelectedIndex != -1 && pickerDestinations.SelectedIndex != -1);
                    pickerOrigin.BackgroundColor = Color.Default;
                    pickerDestinations.BackgroundColor = Color.Default;
                }
            };

            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);


            this.Content = new StackLayout
            {
                Children =
                {
                    lblOrigin,
                    pickerOrigin,
                    lblDestination,
                    pickerDestinations,
                    lblDate,
                    pickerDate,
                    lblTime,
                    pickerTime,
                    lblStepper,
                    stepperSlots,
                    btnAdd
                }
            };

        }
    }
}
