using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SayAnything
{
    public class RoundResult : ContentPage
    {
        GameData gameData;
        int roundNo;

        public RoundResult()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.White;

            //get gameData from server
            roundNo = 1;
            gameData = new GameData();
            gameData.Data[0].Answer = "blah blah blah";
            gameData.Data[1].Answer = "blah blah blah";
            gameData.Data[2].Answer = "blah blah blah";

            Label RRLabel1 = new Label
            {
                TextColor = Color.Blue,
                FontSize = 20,

                Text = "Result of round - " + roundNo
            };

            ListView roundResult = new ListView();
            roundResult.ItemsSource = gameData.Data;
            roundResult.VerticalOptions = LayoutOptions.FillAndExpand;
            //roundResult.RowHeight = 60;
            roundResult.ItemTemplate = new DataTemplate(() =>
            {
                Label players = new Label
                {
                    TextColor = Color.Blue,
                    FontSize = 18
                };
                players.SetBinding(Label.TextProperty, "UserName");

                Label numOfBets = new Label
                {
                    TextColor = Color.Blue,
                    FontSize = 12
                };
                numOfBets.SetBinding(Label.TextProperty, new Binding("BetRecieved", BindingMode.OneWay, null, null, "Bets: {0}"));

                Label totalScore = new Label
                {
                    TextColor = Color.Blue,
                    FontSize = 12
                };
                totalScore.SetBinding(Label.TextProperty, new Binding("TotalScore", BindingMode.OneWay, null, null, "TotalScore: {0}"));

                Label thisRoundScore = new Label
                {
                    TextColor = Color.Blue,
                    FontSize = 12
                };
                thisRoundScore.SetBinding(Label.TextProperty, new Binding("ThisRoundScore", BindingMode.OneWay, null, null, "This Round: {0}"));

                Label playerAnswer = new Label
                {
                    TextColor = Color.Blue,
                    //BackgroundColor = Color.Yellow,
                    FontSize = 12
                };
                playerAnswer.SetBinding(Label.TextProperty, "Answer");

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Spacing = 0,
                        Children =
                            {
                                new StackLayout
                                {
                                    Spacing = 15,
                                    Orientation = StackOrientation.Horizontal,
                                    Children =
                                    {
                                        players, numOfBets, totalScore, thisRoundScore
                                    }
                                },
                                playerAnswer
                            }
                    }
                };
            });

            //temp navigation
            Button endRound = new Button
            {
                Text = "End Round",
                FontSize = 20,
                BackgroundColor = Color.Silver,
                TextColor = Color.Red,
                BorderRadius = 15
            };
            endRound.Clicked += EndRound_Clicked;

            Content = new StackLayout
            {
                Children = {
                    RRLabel1,
                    roundResult,
                    endRound
                }
            };
        }

        private async void EndRound_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FinalResults());
        }
    }
}
