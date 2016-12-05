using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SayAnything
{
    public class FinalResults : ContentPage
    {
        GameData gameData;

        public FinalResults()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.White;

            //temp data
            gameData = new GameData();

            Label FRMainLabel = new Label
            {
                TextColor = Color.Blue,
                FontSize = 26,

                Text = "The Final Score of this game is: "
            };

            //Sort List from server, highest score at top
            ListView finalResult = new ListView();
            finalResult.ItemsSource = gameData.Data;
            finalResult.VerticalOptions = LayoutOptions.FillAndExpand;
            finalResult.ItemTemplate = new DataTemplate(() =>
            {
                Label players = new Label
                {
                    TextColor = Color.Blue,
                    FontSize = 18
                };
                players.SetBinding(Label.TextProperty, "UserName");

                Label totalScore = new Label
                {
                    TextColor = Color.Blue,
                    FontSize = 18
                };
                totalScore.SetBinding(Label.TextProperty, new Binding("TotalScore", BindingMode.OneWay, null, null, "TotalScore: {0}"));

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Spacing = 20,
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            players,  totalScore
                        }
                                    
                    }
                };
            });

            //temp navigation
            Button startOver = new Button
            {
                Text = "New Game",
                FontSize = 20,

                BackgroundColor = Color.Silver,
                TextColor = Color.Red,
                BorderRadius = 15

            };
            startOver.Clicked += StartOver_Clicked;

            Content = new StackLayout
            {
                Children = {
                    finalResult,
                    startOver
                }
            };
        }

        private async void StartOver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }
    }
}
