using Magnifinance.Data.Entities;
using System.Collections.Generic;

namespace Magnifinance.Data.Interface
{
    public interface IStudentsRepository
    {
        IEnumerable<Student> GetAllStudents();
        void AddEntity(object entity);
        bool SaveAll();
    }
}
