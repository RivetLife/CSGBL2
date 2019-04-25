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
using System.Data.SqlClient;
using System.Data;

//Бугров Илья, домашнее задание по курсу "С# Уровень 2", восьмое занятие

namespace Lesson_8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Base dBase = new Base();

        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dt;

        ServiceReference.WebServiceSoapClient serviceClient;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            serviceClient = new ServiceReference.WebServiceSoapClient();
            serviceClient.Init(ref connection, ref adapter, ref dt)
        }

        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Изменение департамента сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeDepartment(object sender, RoutedEventArgs e)
        {
            serviceClient.ChangeDepartment(cmbDepartment.SelectedIndex, (DataRowView)employeeDataGrid.SelectedItem, ref adapter, ref dt);
        }

        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            serviceClient.AddEmployee(cmbDepartment.SelectedIndex, txtName.Text, ref adapter, ref dt);
        }

    }
}
