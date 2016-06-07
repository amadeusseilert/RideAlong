using Newtonsoft.Json.Linq;
using RideAlong.Entities;
using RideAlong.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RideAlong
{
    public partial class FindRide : ContentPage
    {


        public FindRide()
        {
            InitializeComponent();

            Button button = new Button()
            {
                Text = "Find Locations!"
            };

            Label header = new Label
            {
                Text = "Exemplo de Request",
                HorizontalOptions = LayoutOptions.Center
            };


            Label label = new Label();

            button.Clicked += async (sender, e) =>
            {
                string result = await Web.WebService.getRequest("http://ec2-52-67-5-21.sa-east-1.compute.amazonaws.com/RideAlong-WebService/api/locations");
                //HANDLE JSON
                //...
                //
                label.Text = result;
            };

            Content = new StackLayout
            {
                Children =
                {
                    header,
                    button,
                    label
                }
            };

        }
    }   
}
