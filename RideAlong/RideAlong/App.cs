using RideAlong.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RideAlong
{
    public class App : Application
    {

        public static User user { get; set; }

        public static Action HideLoginView
        {
            get
            {
                return new Action(() => App.Current.MainPage.Navigation.PopModalAsync());
            }
        }

        public App()
        {
            user = new User();
            MainPage = new NavigationPage(new Start());
        }

        public async static Task NavigateToHome()
        {
            HideLoginView();
            await Current.MainPage.Navigation.PushAsync(new Home(user));
        }

    }
}
