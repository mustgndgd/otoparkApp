using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using otopark.Core.Entities;

namespace otopark.Entities.Concrete
{
    public class CarPark:IEntity
    {
        public int Id { get; set; } 
        public int Capacity { get; set; }
        public decimal Price { get; set; }
    }
}
