using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
using System.Windows.Xps.Packaging;
using DemoExam4.Elements;
using DemoExam4.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoExam4.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            LoadDocumentRegs();


        }

        public void LoadDocumentRegs()
        {
            spItems.Children.Clear();
            foreach (DocumentReg d in MainWindow.connection.DocumentRegs.ToList())
                spItems.Children.Add(new Item(d, this));

            var allDocumentRegs = MainWindow.connection.DocumentRegs.ToList();




        }


        private void Add(object sender, RoutedEventArgs e) =>
            MainWindow.Init.frame.Navigate(new Add());
    }
}
