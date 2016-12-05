using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SayAnything
{
    public class EnterAnswer : ContentPage
    {
        //get question number from server
        int questionNo;
        

        public EnterAnswer()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            questionNo = 1;

            
            BackgroundColor = Color.White;
            QuestionSet questions = new QuestionSet();

            Label EAMainLabel = new Label
            {
                FontSize = 20,
                Text = "The Question of this round is: \n" + questions.QSet[questionNo].Qs,
                TextColor = Color.Blue
            };

            Entry EAAnswerEntry = new Entry
            {
                FontSize = 20,
                Placeholder = "Please enter your response here",
                TextColor = Color.Red
            };

            Button EAConfirm = new Button
            {
                Text = "Confirm",
                FontSize = 20,
                BackgroundColor = Color.Silver,
                TextColor = Color.Red,
                BorderRadius = 15
            };
            EAConfirm.Clicked += EAConfirm_Clicked;

            Content = new StackLayout
            {
                Spacing = 20,
                Children = {
                    EAMainLabel,
                    EAAnswerEntry,
                    EAConfirm
                }
            };
        }

        private async void EAConfirm_Clicked(object sender, EventArgs e)
        {
            //send answer to server


            await Navigation.PushAsync(new WaitingAnswer());
        }
    }
}
