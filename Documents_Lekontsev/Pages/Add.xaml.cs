﻿using Documents_Lekontsev.Classes;
using Documents_Lekontsev.Model;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;

namespace Documents_Lekontsev.Pages
{
    public partial class Add : Page
    {

        public Document Document;

        public string s_src = "";
        public Add(Document Document = null)
        {
            InitializeComponent();

            if (Document != null)
            {
                this.Document = Document;

                if (File.Exists(Document.src))
                {
                    s_src = Document.src;
                    src.Source = new BitmapImage(new Uri(s_src));
                }

                tb_name.Text = this.Document.name;
                tb_user.Text = this.Document.user;
                tb_id.Text = this.Document.id_document.ToString();
                tb_date.Text = this.Document.date.ToString("dd.MM.yyyy");
                tb_status.SelectedIndex = this.Document.status;
                tb_vector.Text = this.Document.vector;
                bthAdd.Content = "Изменить";
            }
        }

        private void Back(object sender, RoutedEventArgs e) =>
            MainWindow.init.OpenPages(MainWindow.pages.main);

        private void SelectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "PNG (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                src.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                s_src = openFileDialog.FileName;
            }
        }

        private void AddDocument(object sender, RoutedEventArgs e)
        {
            if (s_src.Length == 0)
            {
                MessageBox.Show("Выберите изображение");
                return;
            }

            if (tb_name.Text.Length == 0)
            {
                MessageBox.Show("Укажите наименование");
                return;
            }

            if (tb_user.Text.Length == 0)
            {
                MessageBox.Show("Укажите ответственного");
                return;
            }

            if (tb_id.Text.Length == 0)
            {
                MessageBox.Show("Укажите код документа");
                return;
            }

            if (tb_date.Text.Length == 0)
            {
                MessageBox.Show("Укажите дату поступления");
                return;
            }

            if (tb_status.Text.Length == 0)
            {
                MessageBox.Show("Укажите статус");
                return;
            }

            if (tb_vector.Text.Length == 0)
            {
                MessageBox.Show("Укажите направление");
                return;
            }

            if (Document == null)
            {
                DocumentContext newDocument = new DocumentContext();
                newDocument.src = s_src;
                newDocument.name = tb_name.Text;
                newDocument.user = tb_user.Text;
                newDocument.id_document = tb_id.Text;

                DateTime newDate = new DateTime();
                DateTime.TryParse(tb_date.Text, out newDate);
                newDocument.date = newDate;
                newDocument.status = tb_status.SelectedIndex;
                newDocument.vector = tb_vector.Text;
                newDocument.Save();

                MessageBox.Show("Документ добавлен");
            }
            else
            {
                DocumentContext newDocument = new DocumentContext();
                newDocument.src = s_src;
                newDocument.id = Document.id;
                newDocument.name = tb_name.Text;
                newDocument.user = tb_user.Text;
                newDocument.id_document = tb_id.Text;

                DateTime newDate = new DateTime();
                DateTime.TryParse(tb_date.Text, out newDate);
                newDocument.date = newDate;
                newDocument.status = tb_status.SelectedIndex;
                newDocument.vector = tb_vector.Text;
                newDocument.Save(true);

                MessageBox.Show("Документ изменён");
            }

            MainWindow.init.AllDocuments = new DocumentContext().AllDocuments(new DocumentContext().GetDataDocuments());
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
