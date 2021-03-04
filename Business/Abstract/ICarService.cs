using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);

        Car GetCarsByBrandId(int id);
        Car GetCarsByColorId(int id);
        List<CarDetailDto> GetCarDetails();


    }
}
