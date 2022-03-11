using System;
using System.Collections.Generic;
using System.Text;
using otopark.Core.DataAccess.EntityFramework;
using otopark.Entities.Concrete;

namespace otopark.DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
    }
}
