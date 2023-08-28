using DapperCurd.Models;

namespace DapperCurd.Reositories
{

    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        int Add(Employee employee);
        bool Update(Employee employee);
        bool Delete(int id);
    }
}
