using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SayAnything
{
    public class WaitingBet : ContentPage
    {
        public WaitingBet()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.White;

            Label WBMainLabel = new Label
            {
                FontSize = 20,
                Text = "Please wait for other players to place their bets...",
                TextColor = Color.Blue
            };

            //temp page navigation
            Button seeResult = new Button
            {
                Text = "See Result",
                FontSize = 20,
                BackgroundColor = Color.Silver,
                TextColor = Color.Red,
                BorderRadius = 15
            };
            seeResult.Clicked += SeeResult_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    WBMainLabel,
                    seeResult
                }
            };
        }

        private async void SeeResult_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RoundResult());
        }
    }
}
