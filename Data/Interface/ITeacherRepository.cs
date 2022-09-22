using Magnifinance.Data.Entities;
using System.Collections.Generic;

namespace MAGNIFINANCE.Web.Data.Interface
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAllTeachers();
        void AddEntity(object entity);
        bool SaveAll();
    }
}
