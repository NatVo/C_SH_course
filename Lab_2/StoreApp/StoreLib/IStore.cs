using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public interface IStore
    {
        string Name { get; set; }
        string Adress { get; set; }
        int AmountOfEmployees { get; }

        void SetEmployees(int setEmployeeNum);
        void AddEmpolyees(int employee);
        void RemoveEmpolyees(int employee);
        void OutputStoreInfo();
        void DeleteItem(string itemName);
        void ItemsOutput();
    }
}
