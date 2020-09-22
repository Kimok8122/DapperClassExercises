using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace DrapperClass
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;

        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
             return _connection.Query<Department>("Select * From departments;").ToList();
        }

        //public void InsertDepartment(string newDepartmentName)
        //{
        //    _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
        //    new { departmentName = newDepartmentName });
        //}

        //public void CreateDepartment(string name)
        //{
        //    _connection.Execute("INSERT INTO departments (Name) Values(@name);", new { name = name });
        //}
    }

}
