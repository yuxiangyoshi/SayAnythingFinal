using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SayAnything
{
    public class WaitingAnswer : ContentPage
    {
        public WaitingAnswer()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.White;
            //temp navigation
            Button answerDisplay = new Button
            {
                Text = "Go",
                FontSize = 20,
                BackgroundColor = Color.Silver,
                TextColor = Color.Red,
                BorderRadius = 15
            };
            answerDisplay.Clicked += AnswerDisplay_Clicked;

            Label WAMainLabel = new Label
            {
                FontSize = 20,
                Text = "Please wait for other players to respond...",
                TextColor = Color.Blue
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    WAMainLabel,
                    answerDisplay
                }
            };

            //wait for server to signal to go

        }

        private async void AnswerDisplay_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BettingPage());
        }
    }
}
