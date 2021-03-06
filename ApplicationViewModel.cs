﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace training
{
    public class ApplicationViewModel
    {
        private Player selectedPlayer;
        public Player SelectedPlayer
        {
            get { return selectedPlayer; }
            set
            {
                selectedPlayer = value;
                OnPropertyChanged("SelectedPlayer");
            }
        }
        
        private Game game;


        //public ObservableCollection<Player> Players { get; set; }

        public ApplicationViewModel()       // deafault constructor of VM
        {

            game = new Game();            
        }


        // implement INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}