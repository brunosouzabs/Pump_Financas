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
using System.Windows.Shapes;

namespace ViewWPF
{
    /// <summary>
    /// Lógica interna para Configuration.xaml
    /// </summary>
    public partial class Configuration : Window
    {
        public Configuration()
        {
            InitializeComponent();
        }

        private void btnCadastroUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMenuConfig_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            this.Close();
            home.Show();
        }

        private void btnCadastroProd_Click(object sender, RoutedEventArgs e)
        {
            Product prod = new Product();
            this.Close();
            prod.ShowDialog();
        }

        private void btnCadastroUser_Click_1(object sender, RoutedEventArgs e)
        {
            User user = new User();
            this.Close();
            user.ShowDialog();
        }
    }
}
