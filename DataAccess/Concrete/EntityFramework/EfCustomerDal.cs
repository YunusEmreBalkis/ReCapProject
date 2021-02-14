using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentCarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from cu in context.Customers
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = cu.CustomerId,
                                 CompanyName = null,
                                 FirstName = u.FirstName, 
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 Password = u.Password
                             };
                return result.ToList();

            }
            
        }
    }
}
