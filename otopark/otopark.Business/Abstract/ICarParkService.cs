using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using otopark.Entities.Concrete;

namespace otopark.Business.Abstract
{
    public interface ICarParkService
    {
        IDataResult<CarPark> GetById(int carParkId);
        IDataResult<int>GetCapacitById(int carParkId);
        IDataResult<List<CarPark>> GetAll();
        IResult Add(CarPark carPark);
        IResult Update(CarPark carPark);
        IResult Delete(CarPark carPark);
    }
}
