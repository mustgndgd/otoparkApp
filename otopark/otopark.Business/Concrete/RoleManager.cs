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
    public  class RoleManager:IRoleService
    {
        private IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal=roleDal;
        }
        public IDataResult<Role> GetById(int roleId)
        {
            return new SuccessDataResult<Role>(_roleDal.Get(r => r.Id == roleId));
        }

        public IDataResult<List<Role>> GetAll()
        {
            return new SuccessDataResult<List<Role>>(_roleDal.GetList().ToList());
        }

        public IResult Add(Role role)
        {
            _roleDal.Add(role);
            return new SuccessResult();

        }

        public IResult Update(Role role)
        {
            _roleDal.Update(role);
            return new SuccessResult();
        }

        public IResult Delete(Role role)
        {
            _roleDal.Delete(role);
            return new SuccessResult();
        }
    }
}
