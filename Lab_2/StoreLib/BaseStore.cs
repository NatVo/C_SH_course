using System;

namespace StoreLib
{
    public abstract class BaseStore
    {
        public const string AddZeroOrNegativeEmployeesMessage = "Количество принимаемых в магазин работников не может быть нулевым или отрицательным!\n";
        public const string RemoveZeroOrNegativeEmployeesMessage = "Количество увольняемых из магазина работников не может быть нулевым или отрицательным!\n";
        public const string ZeroOrNegativeTotalAmountOfEmployeesMessage = "Общее количество работников магазина не может быть нулевым или отрицательным!\n";

        protected int employeesNumber = 1;

        public string Name { get; set; }
        public string Adress { get; set; }
        public int AmountOfEmployees { get { return employeesNumber; } }

        public void SetEmployees(int setEmployeeNum)
        {
            if (setEmployeeNum >= 1)
            {
                employeesNumber = setEmployeeNum;
            }
            else
            {
                throw new ArgumentException(ZeroOrNegativeTotalAmountOfEmployeesMessage);
            }
        }

        public void AddEmpolyees(int employee)
        {
            if (employee < 1)
            {
                throw new ArgumentException(AddZeroOrNegativeEmployeesMessage);
            }
            else
            {
                employeesNumber += employee;
            }
        }

        public void RemoveEmpolyees(int employee)
        {
            if (employee < 1)
            {
                throw new ArgumentException(RemoveZeroOrNegativeEmployeesMessage);
            }
            else
            {
                if ((employeesNumber - employee) < 1)
                {
                    throw new ArgumentException(ZeroOrNegativeTotalAmountOfEmployeesMessage);
                }
                else
                {
                    employeesNumber -= employee;
                }
            }
        }

        public abstract void OutputStoreInfo();
        public abstract void DeleteItem(string itemName);
        public abstract void ItemsOutput();

    }
}
