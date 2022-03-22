using Microsoft.Extensions.Configuration;
using ModelLayer.Services;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL:IUserRL
    {
        private readonly IConfiguration Configuration;
        public UserRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public void addEmployee(Employeemodel employeemodel)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayrollMVC")))
            {
                SqlCommand command = new SqlCommand("addEmployee", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@emp_name", employeemodel.emp_name);
                command.Parameters.AddWithValue("@profile_img", employeemodel.profile_img);
                command.Parameters.AddWithValue("@gender", employeemodel.gender);
                command.Parameters.AddWithValue("@department", employeemodel.department);
                command.Parameters.AddWithValue("@salary", employeemodel.salary);
                command.Parameters.AddWithValue("@startDate", employeemodel.startDate);
                command.Parameters.AddWithValue("@notes", employeemodel.notes);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<Employeemodel> EmpList = new List<Employeemodel>();
        public List<Employeemodel> GetEmployeemodels()
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayrollMVC")))
            {
                SqlCommand command = new SqlCommand("getEmployee", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                //Bind EmpModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {
                    EmpList.Add(
                        new Employeemodel
                        {

                            emp_id = Convert.ToInt32(dr["emp_id"]),
                            emp_name = Convert.ToString(dr["emp_name"]),
                            profile_img = Convert.ToString(dr["profile_img"]),
                            gender = Convert.ToString(dr["gender"]),
                            department = Convert.ToString(dr["department"]),
                            salary = Convert.ToString(dr["salary"]),
                            startDate = Convert.ToDateTime(dr["startDate"]),
                            notes = Convert.ToString(dr["notes"])
                        }
                        );
                }
                return EmpList;
            }
        }

        public void updateEmployee(Employeemodel employeemodel)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayrollMVC")))
            {
                SqlCommand command = new SqlCommand("updateEmployee", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@emp_id", employeemodel.emp_id);
                command.Parameters.AddWithValue("@emp_name", employeemodel.emp_name);
                command.Parameters.AddWithValue("@profile_img", employeemodel.profile_img);
                command.Parameters.AddWithValue("@gender", employeemodel.gender);
                command.Parameters.AddWithValue("@department", employeemodel.department);
                command.Parameters.AddWithValue("@salary", employeemodel.salary);
                command.Parameters.AddWithValue("@startDate", employeemodel.startDate);
                command.Parameters.AddWithValue("@notes", employeemodel.notes);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }


        public void deleteEmployee(Employeemodel employeemodel)
        {

            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayrollMVC")))
            {
                SqlCommand cmd = new SqlCommand("deleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@emp_id", employeemodel.emp_id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //Get the details of a particular employee  
        public Employeemodel GetEmployeemodel(int? id)
        {
            Employeemodel employeemodel = new Employeemodel();

            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayrollMVC")))
            {
                string sqlQuery = "SELECT * FROM employeePayrollDetails WHERE emp_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employeemodel.emp_id = Convert.ToInt32(rdr["emp_id"]);
                    employeemodel.emp_name = rdr["emp_name"].ToString();
                    employeemodel.profile_img = rdr["profile_img"].ToString();
                    employeemodel.gender = rdr["gender"].ToString();
                    employeemodel.department = rdr["department"].ToString();
                    employeemodel.salary = rdr["salary"].ToString();
                    employeemodel.startDate = Convert.ToDateTime(rdr["startDate"]);
                    employeemodel.notes = rdr["notes"].ToString();

                }
                con.Close();
            }
            return employeemodel;
        }
    } 
}