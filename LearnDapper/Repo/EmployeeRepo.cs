using Dapper;
using LearnDapper.Models;
using LearnDapper.Models.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data;

namespace LearnDapper.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public readonly DapperDbContext _Context;
        public EmployeeRepo(DapperDbContext _Context)
        {
            this._Context = _Context;
        }
        //done
        public async Task<string> AddEmployee(Employee emp)
        {
            string response = string.Empty;
            string query = "insert into Employees(Code,Name,Email,PhoneNumber,designation) values (@Code,@Name,@Email,@PhoneNumber,@designation)";
            var Parameters = new DynamicParameters();
            Parameters.Add("name", emp.name, DbType.String);
            Parameters.Add("code", emp.code, DbType.Int32);
            Parameters.Add("Email", emp.email, DbType.String);
            Parameters.Add("PhoneNumber", emp.phoneNumber, DbType.String);
            Parameters.Add("designation", emp.designation, DbType.String);

            using (var connection = this._Context.createConnection())
            {
                await connection.ExecuteAsync(query, Parameters);
                response = "pass";
            }
            return response;
        }

        //done
        public async Task<List<Employee>> GetAll()
        {
            string query = "select * from Employees";
            using (var connection = this._Context.createConnection())
            {
                var empList = await connection.QueryAsync<Employee>(query);
                if (empList != null)
                {

                    return empList.ToList();
                }
                return null;
            }
        }
        //done
        public async Task<Employee> GetByName(String Name)
        {
            string query = "select * from Employees Where Name=@Name";
            var parameters = new DynamicParameters();
            parameters.Add("Name", Name, DbType.String);
            using (var connection = this._Context.createConnection())
            {

                var emp = await connection.QueryFirstAsync<Employee>(query);
                if (emp != null)
                {

                    return emp;
                }
                return null;
            }
        }

        public async Task<string> Remove(string Name)
        {
            string res;
            string query = "Delete from Employees where Name =@Name";
            using (var connection = this._Context.createConnection())
            {
                var emp = await connection.ExecuteAsync(query, new { Name });
                if (emp.Equals(null))
                {
                    res = "Not Found";
                }
                res = "Deleted";
            }

            return res;
        }


    }
}
