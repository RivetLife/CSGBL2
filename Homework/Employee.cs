using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Бугров Илья, домашнее задание по курсу "С# Уровень 2", восьмое занятие

namespace Lesson_8
{
    /// <summary>
    /// Класс работника
    /// </summary>
    class Employee : INotifyPropertyChanged
    {

        string name;
        string department;

        public string Department
        {
            get => this.department;
            set
            {
                this.department = value;
                this.NotifyPropertyChanged("Department");
            }
        }
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                this.NotifyPropertyChanged("Name");
            }
        }

        public Employee(string _name, string _department)
        {
            name = _name;
            department = _department;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

    }
}
