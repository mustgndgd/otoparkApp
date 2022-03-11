using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using otopark.Core.Entities;

namespace otopark.Entities.Concrete
{
    public class Role:IEntity
    {
        public int Id { get; set; }
        public string role { get; set; }
    }
}
