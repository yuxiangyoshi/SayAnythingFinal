using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SayAnything
{
    public class Room : ContentPage
    {
        //Room for Host?
        App app = Application.Current as App;
        List<String> names = new List<String>();

        public Room()
        {
            List<UserData> playerList = app.SignalRClient.GetPlayerList();
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.White;
            ObservableCollection<UserData> gameData = new ObservableCollection<UserData>(playerList);

            Label roomLabel1 = new Label
            {
                //BackgroundColor = Color.Yellow,
                TextColor = Color.Blue,
                //Text = roomNames
                FontSize = 20,
                
                Text = "Players in the room: \n" 
            };

            ListView existedPlayers = new ListView();
            existedPlayers.ItemsSource = gameData;
            gameData.Add(new UserData("new player2"));
            existedPlayers.VerticalOptions = LayoutOptions.FillAndExpand;
            //existedPlayers.RowHeight = 30;
            existedPlayers.ItemTemplate = new DataTemplate(() =>
            {
                Label players = new Label
                {
                    TextColor = Color.Blue,
                    //BackgroundColor = Color.Yellow,
                    FontSize = 18
                };
                players.SetBinding(Label.TextProperty, "UserName");

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Children =
                            {
                                players
                            }
                    }
                };
            });

            Frame roomFrame1 = new Frame
            {

                OutlineColor = Color.Black,

                HasShadow = true,
                Padding = 5,
                HeightRequest = 150,
                WidthRequest = 200,
                Content = roomLabel1
            };

            Button roomButton1 = new Button
            {
                Text = "Leave",
                FontSize = 20,
                BackgroundColor = Color.Silver,
                TextColor = Color.Red,
                BorderRadius = 15
            };
            roomButton1.Clicked += RoomButton1_Clicked;

            Button roomButton2 = new Button
            {
                Text = "Start",
                FontSize = 20,
                BackgroundColor = Color.Silver,
                TextColor = Color.Red,
                BorderRadius = 15
            };
            roomButton2.Clicked += RoomButton2_Clicked;

            //finalize content
            Content = new StackLayout
            {
                Children = {
                    roomLabel1,
                    existedPlayers,
                    roomButton1,
                    roomButton2
                }
            };
        }

        private async void RoomButton1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

        private async void RoomButton2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EnterAnswer());
            //tell server I'm ready
        }
    }
}
