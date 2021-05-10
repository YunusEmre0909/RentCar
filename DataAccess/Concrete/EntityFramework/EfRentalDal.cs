using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<CarRentalDetailDto> GetCarRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentCarContext context=new RentCarContext())
            {
               
                var result = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join brand in context.Brands
                             on c.BrandId equals brand.BrandId
                             join user in context.Users
                             on cu.UserId equals user.Id
                             join color in context.Colors
                             on c.ColorId equals color.ColorId

                             select new CarRentalDetailDto
                             {
                                BrandName=brand.BrandName,
                                ColorName=color.ColorName,
                                CustomerFirstName=user.FirstName,
                                CustomerLastName=user.LastName,
                                RentalId=r.RentalId,
                                CompanyName=cu.CompanyName,
                                DailyPrice=c.DailyPrice,
                                RentDate=r.RentDate,
                                ReturnDate=r.ReturnDate
                                 
                                
                             };
                return result.ToList();
            }
        }
    }
}
    

