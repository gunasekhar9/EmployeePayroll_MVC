using BusinessLayer.Interface;
using ModelLayer.Services;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL:IUserBL
    {
        IUserRL userRL;

        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public void addEmployee(Employeemodel employeemodel)
        {
            try
            {
                 userRL.addEmployee(employeemodel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void deleteEmployee(Employeemodel employeemodel)
        {
            try
            {
                 userRL.deleteEmployee(employeemodel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Employeemodel GetEmployeemodel(int? id)
        {
            try
            {
                return userRL.GetEmployeemodel(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Employeemodel> GetEmployeemodels()
        {
            try
            {
               return userRL.GetEmployeemodels();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void updateEmployee(Employeemodel employeemodel)
        {
            try
            {
                userRL.updateEmployee(employeemodel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
