using System;
using System.Collections.Generic;
using System.Text;
using otopark.Core.DataAccess.EntityFramework;
using otopark.DataAccess.Abstract;
using otopark.DataAccess.Concrete.EntityFramework.Context;
using otopark.Entities.Concrete;

namespace otopark.DataAccess.Concrete.EntityFramework
{
    public class EfRoleDal: EfEntityRepositoryBase<Role, OtoparkDbContext>, IRoleDal
    {
    }
}
