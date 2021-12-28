using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Castle.Core.Internal;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);

        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalListed);
        }

        public IDataResult<List<CarRentalDetailDto>> GetRentalDetails()
        {
             return new SuccessDataResult<List<CarRentalDetailDto>>(_rentalDal.GetCarRentalDetails(),Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id), Messages.RentalListed);
        }

       

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult CheclIfCarIsAvaliable(int carId, DateTime rentDate, DateTime returnDate)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId && 
            r.ReturnDate >=rentDate);
            if (result.IsNullOrEmpty()==false)
            {
                return new ErrorResult("Araba şuan kiralanamaz en yakın kiralanabilme tarihi :"+result[result.Count -1].ReturnDate.Value.ToString("yyyy-MM-dd"));
            }
                return new SuccessResult("Araba Kiralanabilir");
            
        }
    }
}
