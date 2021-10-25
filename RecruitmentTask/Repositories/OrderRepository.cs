using RecruitmentTask.Models;
using RecruitmentTask.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTask.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly DataBaseContext _context;

        public OrderRepository(DataBaseContext context)
        {
            _context = context;
        }

        public Order Create(Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();
            return order;
        }

        public void Delete(Order order)
        {
            _context.Order.Update(order);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Order.AsEnumerable();
        }

        public Order GetById(int id)
        {
            return _context.Order.SingleOrDefault();
        }

        public void Update(Order order)
        {
            _context.Order.Update(order);
            _context.SaveChanges();
        }
    }
}
