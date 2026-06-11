using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using DemoExam4.Models;
using DemoExam4.Pages;

namespace DemoExam4.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public DocumentReg documentReg;
        public Main main;

        public Item(DocumentReg documentReg, Main main)
        {
            InitializeComponent();
            this.documentReg = documentReg;
            this.main = main;

            lName.Content = $"Наименование: {documentReg.Name}";
            lResponsible.Content = $"Ответственный: {documentReg.Responsible}";
            lCounterparty.Content = $"Контрагент: {documentReg.Counterparty}";
            lOrganization.Content = $"Организцаия: {documentReg.Organization}";
            lDirection.Content = $"Направление: {documentReg.Direction}";

            var status = MainWindow.connection.Statuses.FirstOrDefault(x => x.Id == documentReg.IdStatus);
            string statusName = status?.Name ?? "Не указана";
            lStatus.Content = $"Статус: {statusName}";

        }

        private void Update(object sender, System.Windows.RoutedEventArgs e) =>
            MainWindow.Init.frame.Navigate(new Add(documentReg));

        private void Delete(object sender, System.Windows.RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить запись?", "Уведомление",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MainWindow.connection.DocumentRegs.Remove(documentReg);
                MainWindow.connection.SaveChanges();
                main.spItems.Children.Remove(this);
            }
        }
    }
}
