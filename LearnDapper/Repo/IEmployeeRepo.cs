using LearnDapper.Models;

namespace LearnDapper.Repo
{
    public interface IEmployeeRepo
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetByName(String Name);
        Task<string> Remove(String Name);
        Task<string> AddEmployee(Employee emp);


    }
}
