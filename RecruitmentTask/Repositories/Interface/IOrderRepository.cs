using RecruitmentTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTask.Repositories.Interface
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        void Update(Order order);
        Order Create(Order order);
        void Delete(Order order);
    }
}
