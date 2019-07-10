﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using training.Interfaces;
using training.Models;
using training.Services;

namespace training.ViewModel
{
    public class GameDriveViewModel : INotifyPropertyChanged
    {
        IFileService fileService;
        IDialogService dialogService;

        #region notified props
        private Game currentGame;
        public Game CurrentGame
        {
            get { return currentGame; }
            set
            {
                currentGame = value;
                OnPropertyChanged("CurrentGame");
            }
        }

        private IUnit selectedActiveUnit;
        public IUnit SelectedActiveUnit
        {
            get { return selectedActiveUnit; }
            set
            {
                selectedActiveUnit = value;
                OnPropertyChanged("SelectedUnit");
            }
        }
        #endregion

        #region ctor GameDriveVM
        public GameDriveViewModel(IDialogService _dialogService = null, IFileService _fileService = null, Game game = null)
        {
            dialogService = _dialogService;
            fileService = _fileService;

            if (game == null)
                currentGame = new Game();
            else
                currentGame = game; // StaticConfig.ConvertToObjectGame("");

            selectedActiveUnit = currentGame.GetCurrentActiveUnit();

            if (currentGame.IsGameOver == true)
                dialogService.ShowMessage("Game over");
        }
        #endregion

        #region commands
        /// <summary>
        /// SuperCommand - do i must use this command?
        /// </summary>
   
        RelayCommand attackUnitCommand;
        public RelayCommand AttackUnitCommand
        {
            get
            {
                return attackUnitCommand ??
                (attackUnitCommand = new RelayCommand((obj) =>
                {                                      //   Execute block
                    try
                    {
                        selectedActiveUnit.GetDamage();     //     - создать подкоманду для клоцания Действий
                        currentGame.TurnSwitching();
                    }
                    catch (Exception ex)
                    {
                        dialogService.ShowMessage(ex.Message);
                    }
                },
                (obj) => CurrentGame.IsGameOver == true)   //   CanExecute condition  - т.е. комманда досупна к выполенению пока ЭТО условие == ТРУ
                );
            }
        }

        RelayCommand specSkillUnitCommand;
        public RelayCommand SpecSkillUnitCommand
        {
            get
            {
                return specSkillUnitCommand ??
                (specSkillUnitCommand = new RelayCommand((obj) =>
                {                                      //   Execute block
                    try
                    {
                        selectedActiveUnit.SpecialSkill();     
                        currentGame.TurnSwitching();
                    }
                    catch (Exception ex)
                    {
                        dialogService.ShowMessage(ex.Message);
                    }
                },
                (obj) => (CurrentGame.IsGameOver == true && SelectedActiveUnit.AbilitySpecialSkill())   //   CanExecute condition  - т.е. комманда досупна к выполенению пока ЭТО условие == ТРУ
                ));
            }
        }

        RelayCommand moveUnitCommand;
        public RelayCommand MoveUnitCommand
        {
            get
            {
                return moveUnitCommand ??
                (moveUnitCommand = new RelayCommand((obj) =>
                {                                      //   Execute block
                    try
                    {
                        selectedActiveUnit.Move();
                        currentGame.TurnSwitching();
                    }
                    catch (Exception ex)
                    {
                        dialogService.ShowMessage(ex.Message);
                    }
                },
                (obj) => (CurrentGame.IsGameOver == true)   //   CanExecute condition  - т.е. комманда досупна к выполенению пока ЭТО условие == ТРУ
                ));
            }
        }

        #endregion

        #region implementation INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string prop = "")      // CallerMemberName - read!!!
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}