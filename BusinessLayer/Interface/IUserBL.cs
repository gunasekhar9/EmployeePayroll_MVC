using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        void addEmployee(Employeemodel employeemodel);
        List<Employeemodel> GetEmployeemodels();
        void updateEmployee(Employeemodel employeemodel);
        void deleteEmployee(Employeemodel employeemodel);
        Employeemodel GetEmployeemodel(int? id);
    }
}
