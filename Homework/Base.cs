using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Бугров Илья, домашнее задание по курсу "С# Уровень 2", восьмое занятие

namespace Lesson_8
{
    /// <summary>
    /// Класс базы данных работников
    /// </summary>
    class Base
    {
        public ObservableCollection<Employee> employee { get; set; }
        public ObservableCollection<string> department { get; set; }
        public int selectedInd { get; set; }
        public string selectedDepart { get; set; }
        public string selectedName { get; set; }
        public Base()
        {
            department = new ObservableCollection<string>
            {
                "Производственный отдел",
                "Бухгалтерия"
            };

            employee = new ObservableCollection<Employee>()
            {
                new Employee("Иван Иванов", department[0]),
                new Employee("Василий Петров", department[0]),
                new Employee("Зинаида Алексеева", department[1]),
                new Employee("Галина Дмитрова", department[1])
            };

            selectedInd = 0;
        }

        /// <summary>
        /// Изменяет департамент выбранного сотрудник на выбранный в меню
        /// </summary>
        public void ChangeDep()
        {
            employee[selectedInd].Department = selectedDepart;
        }
        
        /// <summary>
        /// Добавляет нового сотрудника в список с входящим именем и выбранным департаментом
        /// </summary>
        public void AddWorker()
        {
            employee.Add(new Employee(selectedName, selectedDepart));
        }
    }
}
