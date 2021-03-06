using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using otopark.Entities.Concrete;

namespace otopark.Business.Abstract
{
    public interface IRecordService
    {
        IDataResult<Record> GetById(int recordId);
        IDataResult<Record> RecordByVehicleId(int plateId);
        IDataResult<List<Record>> GetAll();
        IDataResult<List<Record>> GetAllOnlineRecords();
        IDataResult<int> GetRecordCountByParkId(int parkId);

        IDataResult<bool> isCarInParkCheck(int vehicleId);
     
        IResult Add(Record record);
        IResult Update(Record record);
        IResult Delete(Record record);
    }
}
