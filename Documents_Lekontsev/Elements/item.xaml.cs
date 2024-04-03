﻿using Documents_Lekontsev.Classes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;

namespace Documents_Lekontsev.Elements
{
    /// <summary>
    /// Логика взаимодействия для item.xaml
    /// </summary>
    public partial class item : UserControl
    {
        DocumentContext Document;
        public item(DocumentContext Document)
        {
            InitializeComponent();

            img.Source = new BitmapImage(new Uri(Document.src));

            lName.Content = Document.name;
            lUser.Content = $"Ответственный: {Document.user}";
            lCode.Content = $"Код документа: {Document.id_document}";
            lDate.Content = $"Дата поступления {Document.date.ToString("dd.MM.yyyy")}";
            lStatus.Content = Document.status == 0 ? "Статус: входящий" : "Статус: исходящий";
            lDirect.Content = "Направление: " + Document.vector;

            this.Document = Document;
        }

        private void EditDocument(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Add(Document));
        }

        private void DeleteDocument(object sender, RoutedEventArgs e)
        {
            Document.Delete();

            MainWindow.init.AllDocuments = new DocumentContext().AllDocuments(new DocumentContext().GetDataDocuments());
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }
    }
}
