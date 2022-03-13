using System;
using System.Collections.Generic;
using System.Text;
using otopark.Core.Entities;

namespace otopark.Entities.Concrete
{
    public class Record:IEntity
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int CarParkId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime ExitTime { get; set; }
        public decimal TotalPrice { get; set; }
        public bool State { get; set; }
        public int Duration { get; set; }
    }
}
