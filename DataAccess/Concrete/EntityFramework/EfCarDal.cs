using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                                 on car.BrandId equals brand.BrandId
                             join color in context.Colors
                                 on car.ColorId equals color.ColorId
                             select new CarDetailDto()
                             {
                                 Description = car.Description,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 CarId=car.CarId,
                                 ModelYear=car.ModelYear    
                                
                             };
                return filter is null ? result.ToList() : result.Where(filter).ToList();
            }

        }
    }
}
