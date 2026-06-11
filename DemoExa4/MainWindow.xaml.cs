using System.Windows;
using DbConnection = DemoExam4.Classes.DbConnection;
using DemoExam4.Pages;

namespace DemoExam4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DbConnection connection = new DbConnection();
        public static MainWindow Init;
        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(new Main());
            Init = this;
        }
    }
}