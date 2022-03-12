using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Utilities.Results;
using otopark.Business.Abstract;
using otopark.DataAccess.Abstract;
using otopark.Entities.Concrete;

namespace otopark.Business.Concrete
{
    public class CarParkManager:ICarParkService
    {
        private ICarParkDal _carParkDal;

        public CarParkManager(ICarParkDal carParkDal)
        {
            _carParkDal = carParkDal;
        }
        public IDataResult<CarPark> GetById(int carParkId)
        {
            return new SuccessDataResult<CarPark>(_carParkDal.Get(c => c.Id == carParkId));
        }

        public IDataResult<int> GetCapacitById(int carParkId)
        {
            return new SuccessDataResult<int>(_carParkDal.Get(c => c.Id == carParkId).Capacity);
        }

        public IDataResult<List<CarPark>> GetAll()
        {
            return new SuccessDataResult<List<CarPark>>(_carParkDal.GetList().ToList());
        }

        public IResult Add(CarPark carPark)
        {
           _carParkDal.Add(carPark);
           return new SuccessResult();
        }

        public IResult Update(CarPark carPark)
        {
            _carParkDal.Update(carPark);
            return new SuccessResult();
        }

        public IResult Delete(CarPark carPark)
        {
            _carParkDal.Delete(carPark);
            return new SuccessResult();
        }
    }
}
