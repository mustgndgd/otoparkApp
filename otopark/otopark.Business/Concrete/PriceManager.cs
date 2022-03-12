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
    public  class PriceManager:IPriceService
    {
        private IPriceDal _priceDal;
        public PriceManager(IPriceDal pricaDal)
        {
            _priceDal = pricaDal;
        }
        public IDataResult<Price> GetById(int priceId)
        {
            return new SuccessDataResult<Price>(_priceDal.Get(p => p.Id == priceId));
        }

        public IDataResult<Price> PriceByParkId(int parkId)
        {
            return new SuccessDataResult<Price>(_priceDal.Get(p => p.CarParkId == parkId));
        }
        public IDataResult<List<Price>> GetAll()
        {
            return new SuccessDataResult<List<Price>>(_priceDal.GetList().ToList());
        }

        public IResult Add(Price price)
        {
            _priceDal.Add(price);
            return new SuccessResult();
        }

        public IResult Update(Price price)
        {
            _priceDal.Update(price);
            return new SuccessResult();
        }

        public IResult Delete(Price price)
        {
            _priceDal.Delete(price);
            return new SuccessResult();
        }
    }
}
