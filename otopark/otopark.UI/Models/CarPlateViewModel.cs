using System;
using System.Diagnostics.CodeAnalysis;
using otopark.Entities.Concrete;

namespace otopark.UI.Models
{
    public class CarPlateViewModel
    {
        [AllowNull]
        public CarPlatePostModel CarPlateProperties { get; set; }
        public CarPark park { get; set; }
        public bool isRecordAdded { get; set; }  
        public string vehiclePlate { get; set; }
        public DateTime vehicleLoginTime { get; set; }
        public string Message { get; set; }
        
    }
}
