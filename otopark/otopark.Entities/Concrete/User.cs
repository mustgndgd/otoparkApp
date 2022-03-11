using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using otopark.Core.Entities;

namespace otopark.Entities.Concrete
{
    public class User: IEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
