using System;
using System.Collections.Generic;
using System.Text;
using otopark.Core.Entities;

namespace otopark.Entities.Concrete
{
    public  class Vehicle: IEntity
    {
        public int  Id { get; set; }
        public string Plate { get; set; }
    }
}
