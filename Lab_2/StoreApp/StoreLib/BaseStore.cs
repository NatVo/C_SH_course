using System;

namespace StoreLib
{
    public abstract class BaseStore
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        protected int EmployeesNumber = 1;
        public int AmountOfEmployees { get { return EmployeesNumber; } }
        public void AddEmpolyees(int employee)
        {
            if (employee < 1)
                Console.WriteLine("Количество принимаемых в магазин работников не может быть нулевым или отрицательным!\n");
            else
                EmployeesNumber += employee;

        }
        public void RemoveEmpolyees(int employee)
        {
            if (employee < 1)
            {
                Console.WriteLine("Количество увольняемых из магазина работников не может быть нулевым или отрицательным!\n");
            }
            else
            {
                if ((EmployeesNumber - employee) < 1)
                    Console.WriteLine("Общее количество работников магазина не может быть нулевым или отрицательным!\n");
                else
                    EmployeesNumber -= employee;

            }

        }
        public abstract void OutputStoreInfo();
        public abstract void DeleteItem(string itemName);
        public abstract void ItemsOutput();

    }
}
