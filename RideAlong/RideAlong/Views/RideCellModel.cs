using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RideAlong.Views
{
    public class RideCellModel : ViewCell
    {
        public RideCellModel()
        {

            Label driverLabel = new Label()
            {
                FontFamily = "HelveticaNeue-Medium",
                FontSize = 12,
                TextColor = Color.FromRgb(160,160, 250),
            };
            driverLabel.SetBinding(Label.TextProperty, new Binding("driver")
            {
                StringFormat = "Driver: {0}"
            });

            Label originLabel = new Label()
            {
                FontSize = 12,
                TextColor = Color.Gray
            };
            originLabel.SetBinding(Label.TextProperty, new Binding("origin")
            {
                StringFormat = "Origin: {0}"
            });

            Label destinationLabel = new Label()
            {
                FontSize = 12,
                TextColor = Color.Gray
            };
            destinationLabel.SetBinding(Label.TextProperty, new Binding("destination")
            {
                StringFormat = "Destination: {0}"
            });

            Label dateLabel = new Label()
            {
                FontSize = 10,
                TextColor = Color.White
            };
            dateLabel.SetBinding(Label.TextProperty, new Binding("date")
            {
                StringFormat = "Date: {0}"
            });

            Label timeLabel = new Label()
            {
                FontSize = 10,
                TextColor = Color.White
            };
            timeLabel.SetBinding(Label.TextProperty, new Binding("time")
            {
                StringFormat = "Time: {0}"
            });

            StackLayout infoLayout_1 = new StackLayout
            {
                Spacing = 0,
                Padding = new Thickness(0, 5, 10, 0),
                Orientation = StackOrientation.Vertical,
                Children = { originLabel, dateLabel }
            };

            StackLayout infoLayout_2 = new StackLayout
            {
                Spacing = 0,
                Padding = new Thickness(0, 5, 10, 0),
                Orientation = StackOrientation.Vertical,
                Children = { destinationLabel, timeLabel }
            };

            StackLayout infoLayout = new StackLayout
            {
                Spacing = 0,
                Orientation = StackOrientation.Horizontal,
                Children = { infoLayout_1, infoLayout_2 }
            };

            StackLayout cellLayout = new StackLayout
            {
                Padding = new Thickness(10, 5, 10, 5),
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { driverLabel, infoLayout }
            };

            View = cellLayout;
        }
    }

}
