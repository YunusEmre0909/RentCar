using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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

        public IResult Add(Rental rental)
        {
            Rental result =( (_rentalDal.GetAll(c => c.CarId == rental.CarId)).OrderByDescending(x=>x.RentDate)).FirstOrDefault();
            if (result==null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else
            {

                if (result.ReturnDate.HasValue)
                {
                    if (DateTime.Compare(DateTime.Now,(DateTime)result.ReturnDate)>0)
                    {
                        _rentalDal.Add(rental);
                        return new SuccessResult(Messages.RentalAdded);
                   
                    }
                    else
                    {
                        return new ErrorResult(Messages.InvalidRental);
                    }
                
                }

            }

            return new ErrorResult(Messages.InvalidRental);

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

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id), Messages.RentalListed);
        }

       

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
