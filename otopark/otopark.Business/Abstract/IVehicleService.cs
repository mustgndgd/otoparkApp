using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using otopark.Entities.Concrete;

namespace otopark.Business.Abstract
{
    public interface IVehicleService
    {
        IDataResult<Vehicle> GetById(int vehicleId);
        IDataResult<Vehicle> GetByPlate(string plate);
        IDataResult<List<Vehicle>>  GetAll();
        IDataResult<string> GetPlateByVehicleId(int vehicleId);
        IResult Add(Vehicle vehicle);
        IResult Update(Vehicle vehicle);
        IResult Delete(Vehicle vehicle);
    }
}
