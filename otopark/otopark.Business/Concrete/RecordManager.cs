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
    public class RecordManager:IRecordService
    {
        private  IRecordDal _recordDal;
        public RecordManager(IRecordDal recordDal)
        {
             _recordDal=recordDal;
        }
        public IDataResult<Record> GetById(int recordId)
        {
            return new SuccessDataResult<Record>(_recordDal.Get(r => r.Id == recordId));
        }
        public IDataResult<Record> RecordByVehicleId(int vehicleId)
        {
            return new SuccessDataResult<Record>(_recordDal.Get(r => r.VehicleId == vehicleId));
        }
        public IDataResult<List<Record>> GetAll()
        {
            return new SuccessDataResult<List<Record>>(_recordDal.GetList().ToList());
        }

        public IDataResult<List<Record>> GetAllOnlineRecords()
        {
            return new SuccessDataResult<List<Record>>(_recordDal.GetList(r=> r.State == true).ToList());
        }

        public IDataResult<int> GetRecordCountByParkId(int parkId)
        {
            return new SuccessDataResult<int>(_recordDal.GetList(r => r.CarParkId == parkId).ToList().Count);
        }

        public IDataResult<bool> isCarInParkCheck(int vehicleId)
        {
            if ( _recordDal.GetList(r=>r.State==true && r.VehicleId == vehicleId ).Count == 1 )
            {
                return new SuccessDataResult<bool>(true);
            }
            return new SuccessDataResult<bool>(false);
        }

        public IResult Add(Record record)
        {
            _recordDal.Add(record);
            return new SuccessResult();
        }

        public IResult Update(Record record)
        {
            _recordDal.Update(record);
            return new SuccessResult();
        }

        public IResult Delete(Record record)
        {
            _recordDal.Delete(record);
            return new SuccessResult();
        }
    }
}
