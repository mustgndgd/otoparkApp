using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using otopark.Entities.Concrete;

namespace otopark.Business.Abstract
{
    public interface IPriceService
    {
        IDataResult<Price> GetById(int priceId);
        IDataResult<Price> PriceByParkId(int parkId);
        IDataResult<List<Price>> GetAll();
        IResult Add(Price price);
        IResult Update(Price price);
        IResult Delete(Price price);
    }
}
