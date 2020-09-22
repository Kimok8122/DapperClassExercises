using System;
using System.Collections.Generic;

namespace DrapperClass
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
        //void CreateDepartment(string Name);



    }




}
