using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using otopark.Entities.Concrete;

namespace otopark.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetById(int userId);
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
