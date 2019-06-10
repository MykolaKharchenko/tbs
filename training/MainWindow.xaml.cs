﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using training.Services;

namespace training
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game Game { get; private set; }

        public MainWindow(Game _game)
        {
            InitializeComponent();

            // must me staied only one DataContext  !!

            //DataContext = StartWindow.DataContextProperty;
            DataContext = new ApplicationViewModel(new DefaultDialogService(), new JsonFileService());
            //DataContext = new ApplicationViewModel(new DefaultDialogService(), new JsonFileService());
        }
    }
}
