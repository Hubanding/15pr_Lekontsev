﻿using Documents_Lekontsev.Classes;
using System;
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

namespace Documents_Lekontsev
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public List<DocumentContext> AllDocuments = new DocumentContext().AllDocuments(new DocumentContext().GetDataDocuments());
        public enum pages
        {
            main,
            add
        }
        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            init = this;
            OpenPages(pages.main);
        }

        public void OpenPages(pages _pages)
        {
            if (_pages == pages.main)
                frame.Navigate(new Pages.Main());
            else if (_pages == pages.add)
                frame.Navigate(new Pages.Add());
        }
    }
}
