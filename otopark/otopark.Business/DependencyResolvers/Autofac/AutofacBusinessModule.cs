using Autofac;
using otopark.Business.Abstract;
using otopark.Business.Concrete;
using otopark.DataAccess.Abstract;
using otopark.DataAccess.Concrete.EntityFramework;

namespace otopark.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<CarParkManager>().As<ICarParkService>();
            builder.RegisterType<EfCarParkDal>().As<ICarParkDal>();

            builder.RegisterType<PriceManager>().As<IPriceService>();
            builder.RegisterType<EfPriceDal>().As<IPriceDal>();

            builder.RegisterType<RecordManager>().As<IRecordService>();
            builder.RegisterType<EfRecordDal>().As<IRecordDal>();

            builder.RegisterType<RoleManager>().As<IRoleService>();
            builder.RegisterType<EfRecordDal>().As<IRecordDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<VehicleManager>().As<IVehicleService>();
            builder.RegisterType<EfVehicleDal>().As<IVehicleDal>();
        }
    }
}
