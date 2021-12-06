using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImages, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimited(carImages.CarId));

            if (result != null)
            {
                return result;
            }

            carImages.ImagePath = FileHelper.Add(file);
            carImages.Date = DateTime.Now;
            _carImageDal.Add(carImages);
            return new SuccessResult(Messages.CarImageAdded);

        }

        public IResult Delete(CarImage carImages)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) +
                _carImageDal.Get(p => p.Id == carImages.Id).ImagePath;
            IResult result = BusinessRules.Run(FileHelper.Delete(oldpath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImages);
            return new SuccessResult(Messages.CarImageDeleted);

        }

        public IDataResult<List<CarImage>> GetById(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c=>c.CarId==id));
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.CarId==id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(CarImage carImages, IFormFile file)
        {
            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot"))
                + _carImageDal.Get(p => p.Id == carImages.CarId).ImagePath;

            carImages.ImagePath = FileHelper.Update(oldPath, file);
            carImages.Date = DateTime.Now;
            _carImageDal.Update(carImages);
            return new SuccessResult();

        }
        private IResult CheckIfCarImageLimited(int id)
        {
            var carImageCount = _carImageDal.GetAll(p => p.CarId == id).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.CheckIfCarImageLimited);
            }
            return new SuccessResult();
        }
    }
}
