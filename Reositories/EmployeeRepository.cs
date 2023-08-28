using System.Data;
using System.Collections.Generic;
using Dapper;
using DapperCurd.Models;
using DapperCurd.Reositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IDbConnection _db;

    public EmployeeRepository(IDbConnection db)
    {
        _db = db;
    }

    public IEnumerable<Employee> GetAll()
    {
        return _db.Query<Employee>("SELECT * FROM Employees");
    }

    public Employee GetById(int id)
    {
        return _db.QuerySingle<Employee>("SELECT * FROM Employees WHERE Id = @Id", new { Id = id });
    }

    public int Add(Employee employee)
    {
        const string sql = "INSERT INTO Employees(Name, Salary) VALUES(@Name, @Salary); SELECT CAST(SCOPE_IDENTITY() as int)";
        return _db.QuerySingle<int>(sql, employee);
    }

    public bool Update(Employee employee)
    {
        const string sql = "UPDATE Employees SET Name = @Name, Salary = @Salary WHERE Id = @Id";
        return _db.Execute(sql, employee) > 0;
    }

    public bool Delete(int id)
    {
        const string sql = "DELETE FROM Employees WHERE Id = @Id";
        return _db.Execute(sql, new { Id = id }) > 0;
    }
}
