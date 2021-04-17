using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        //[SecuredOperation("admin,moderatör")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]

        public IResult Add(Car car)
        {

           
                _carDal.Add(car);

                return new SuccessResult(Messages.CarAdded);
           

        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [CacheRemoveAspect("ICarService.Get")]
        // [CacheAspect]
        [SecuredOperation("user,moderatör")]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id), Messages.CarListed);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails());
        }
        [CacheAspect]
        public IDataResult<Car> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.BrandId==id), Messages.CarListed);
        }
        [CacheAspect]
        public IDataResult<Car> GetCarsByColorId(int id)
        {
            return new SuccessDataResult < Car > (_carDal.Get(c => c.ColorId == id), Messages.CarListed);
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
