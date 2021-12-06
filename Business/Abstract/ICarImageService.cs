﻿using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImages, IFormFile file);
        IResult Delete(CarImage carImages);
        IResult Update(CarImage carImages, IFormFile file);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetById(int id);

        IDataResult<CarImage> Get(int id);
        
    }
}
