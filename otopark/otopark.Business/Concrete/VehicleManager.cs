using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Core.Utilities.Results;
using otopark.Business.Abstract;
using otopark.Business.Constants;
using otopark.DataAccess.Abstract;
using otopark.Entities.Concrete;

namespace otopark.Business.Concrete
{
    public class VehicleManager:IVehicleService
    {
        private IVehicleDal _vehicleDal;
        private IRecordDal _recordDal;
        public VehicleManager(IVehicleDal vehicleDal  , IRecordDal recordDal)
        {
            _vehicleDal= vehicleDal;
            _recordDal= recordDal;
        }
        public IDataResult<Vehicle> GetById(int VehicleId)
        {
           return  new SuccessDataResult<Vehicle>(_vehicleDal.Get(v => v.Id == VehicleId));
        }
        public IDataResult<Vehicle> GetByPlate(string plate)
        {
            return new SuccessDataResult<Vehicle>(_vehicleDal.Get(v => v.Plate == plate));
        }
        public IDataResult<List<Vehicle>> GetAll()
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetList().ToList());
        }

        public IDataResult<string> GetPlateByVehicleId(int vehicleId)
        {
            return new SuccessDataResult<string>(_vehicleDal.Get(v => v.Id == vehicleId).Plate);
        }

        public IResult Add(Vehicle vehicle)
        {
            _vehicleDal.Add(vehicle);
            return new SuccessResult(Messages.vehicleAdded);
        }
        public IResult Update(Vehicle vehicle)
        {
            _vehicleDal.Update(vehicle);
            return new SuccessResult(Messages.vehicleUpdated);
        }
        public IResult Delete(Vehicle vehicle)
        {
            _vehicleDal.Delete(vehicle);
            return new SuccessResult(Messages.vehicleRemoved);
        }
    }
}
