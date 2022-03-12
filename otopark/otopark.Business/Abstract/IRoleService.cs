using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using otopark.Entities.Concrete;

namespace otopark.Business.Abstract
{
    public interface IRoleService
    {
        IDataResult<Role> GetById(int roleId);
        IDataResult<List<Role>> GetAll();
        IResult Add(Role role);
        IResult Update(Role role);
        IResult Delete(Role role);
    }
}
