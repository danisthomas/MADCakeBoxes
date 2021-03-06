﻿using MADCakeBoxes.Data;
using MADCakeBoxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADCakeBoxes.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;
        public CustomerService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCustomer(CustomerCreate model)
        {
            var entity = new Customer()
            {
                User = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Phone = model.Phone,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Customers.Single(e => e.CustomerId == model.CustomerId && e.User == _userId);
                if (model.FirstName != null)
                {entity.FirstName = model.FirstName;};
                if(model.LastName != null)
                { entity.LastName = model.LastName; };
                if(model.Address != null) 
                { entity.Address = model.Address; };
                if (model.Phone != null)
                { entity.Phone = model.Phone;};

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCustomer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Customers.Single(e => e.CustomerId == id && e.User == _userId);
                ctx.Customers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Customers.Single(e => e.CustomerId == id && e.User == _userId);
                return new CustomerDetail
                {
                    CustomerId = entity.CustomerId,
                    FirstName=entity.FirstName,
                    LastName=entity.LastName,
                    Phone = entity.Phone,
                    Address = entity.Address,
                };
            }
        }
        //public IEnumerable<CustomerList> GetCustomers()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query = ctx.Customers
        //            .Where(e => e.User == _userId)
        //            .Select(e => new CustomerList
        //            {
        //                FirstName = e.FirstName,
        //                LastName = e.LastName,
        //                CustomerId = e.CustomerId,
        //                Address = e.Address,
        //            });
        //        return query.ToArray();
        //    }
        //}
    }
}
