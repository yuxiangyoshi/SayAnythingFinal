using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SayAnything
{
    public class BettingPage : ContentPage
    {
        GameData gameData;

        public BettingPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.White;

            //get gameData from server
            gameData = new GameData();
            gameData.Data[0].Answer = "blah blah blah";
            gameData.Data[1].Answer = "blah blah blah";
            gameData.Data[2].Answer = "blah blah blah";

            Label BettingLabel1 = new Label
            {
                TextColor = Color.Blue,
                FontSize = 20,

                Text = "Please select your favoriate answer: \n"
            };

            ListView answers = new ListView();
            answers.ItemsSource = gameData.Data;
            answers.VerticalOptions = LayoutOptions.FillAndExpand;
            answers.SeparatorVisibility = SeparatorVisibility.Default;
            answers.ItemTemplate = new DataTemplate(() =>
            {
                Label players = new Label
                {
                    TextColor = Color.Blue,
                    //BackgroundColor = Color.Yellow,
                    FontSize = 18
                };
                players.SetBinding(Label.TextProperty, "UserName");

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
                        Children =
                            {
                                players,
                                playerAnswer
                            }
                    }
                };
            });
            answers.ItemSelected += Answers_ItemSelected;

            Content = new StackLayout
            {
                Children = {
                    BettingLabel1,
                    answers
                }
            };
        }

        private async void Answers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new WaitingBet());
            //sent server my choice of betting
        }
    }
}
