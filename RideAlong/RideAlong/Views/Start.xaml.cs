using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RideAlong
{
    public partial class Start : ContentPage
    {
        public Start()
        {
            InitializeComponent();

            btnLogin.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new Login());
            };

        }
    }
}
