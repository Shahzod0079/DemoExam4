using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
using DemoExam4.Models;

namespace DemoExam4.Pages
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public DocumentReg document = null;



        public Add(DocumentReg document = null)
        {
            InitializeComponent();
            this.document = document;

            var statuses = MainWindow.connection.Statuses.ToList();
            foreach (Status s in statuses)
            {
                tStatus.Items.Add(s.Name);
            }

            if(document != null)
            {
                tName.Text = document.Name;
                tResponsible.Text = document.Responsible;
                tCounterparty.Text = document.Counterparty;
                tOrganization.Text = document.Organization;
                tDirection.Text = document.Direction;

                int index = statuses.FindIndex(x => x.Id == document.IdStatus);
                if(index >= 0)
                {
                    tStatus.SelectedIndex = index;
                }
            }


        }

        private void Back(object sender, RoutedEventArgs e) =>
            MainWindow.Init.frame.Navigate(new Main());

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(tName.Text))
                {
                    MessageBox.Show("Введите наименование");
                    return;
                }

                if (string.IsNullOrWhiteSpace(tResponsible.Text))
                {
                    MessageBox.Show("Введите ответственного");
                    return;
                }

                if (string.IsNullOrWhiteSpace(tCounterparty.Text))
                {
                    MessageBox.Show("Введите контрагента");
                    return;
                }

                if (string.IsNullOrWhiteSpace(tOrganization.Text))
                {
                    MessageBox.Show("Введите организцацию");
                    return;
                }

                if (string.IsNullOrWhiteSpace(tDirection.Text))
                {
                    MessageBox.Show("Введите направление");
                    return;
                }
                if(tStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите статус");
                    return;
                }

                if(document == null)
                {
                    document = new DocumentReg();
                    MainWindow.connection.DocumentRegs.Add(document);
                }

                document.Name = tName.Text;
                document.Responsible = tResponsible.Text;
                document.Counterparty = tCounterparty.Text;
                document.Organization = tOrganization.Text;
                document.Direction = tDirection.Text;

                var selectedStatus = MainWindow.connection.Statuses.ToList()[tStatus.SelectedIndex];
                document.IdStatus = selectedStatus.Id;

                MainWindow.connection.SaveChanges();
                MessageBox.Show("Данные сохранены");
                Back(null, null);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
