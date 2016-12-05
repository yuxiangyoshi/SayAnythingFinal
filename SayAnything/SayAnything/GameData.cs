using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SayAnything
{
    public class GameData
    {
        public GameData()
        {
            //get from server
            Data = new ObservableCollection<UserData>
            {
                new UserData("Kevin"),
                new UserData("Mickey")
                
            };
        }
        public ObservableCollection<UserData> Data { set; get; }
    }
}
