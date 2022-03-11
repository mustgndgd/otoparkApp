using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using otopark.Core.Entities;

namespace otopark.Entities.Concrete
{
    public class Price:IEntity
    {
        public int Id { get; set; }
        public int CarParkId { get; set; }
        public int HourlyMoney { get; set; }
    }
}
