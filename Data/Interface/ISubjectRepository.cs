using System.Collections.Generic;
using DutchTreat.Data.Entities;
using Magnifinance.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Magnifinance.Data.Interface
{
    public interface ISubjectRepository
    {
        //IEnumerable<Course> GetAllProducts();

        IEnumerable<Subject> GetAllSubjects();
        //IEnumerable<Product> GetAllProducts();
        //IEnumerable<Product> GetProductsByCategory(string category);

        //IEnumerable<Order> GetAllOrders(bool includeItems);
        //IEnumerable<Order> GetOrdersByUser(string username, bool includeItems);
        //Order GetOrderById(string username, int id);

        void AddEntity(object entity);
        bool SaveAll();
    }
}