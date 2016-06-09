using RideAlong.Entities;
using RideAlong.Sqlite;
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
        public static DAUser dbUser;
        public static DARide dbRide;

        public static Action HideLoginView
        {
            get
            {
                return new Action(() => App.Current.MainPage.Navigation.PopAsync());
            }
        }

        public App()
        {
            dbUser = new DAUser();
            dbRide = new DARide();
            MainPage = new NavigationPage(new Start());
        }

        public async static Task NavigateToHome(User user)
        {
            HideLoginView();
            await Current.MainPage.Navigation.PushAsync(new Home(user));
        }

    }
}
