using System;
using System.Collections.Generic;

#nullable disable

namespace TestApi.Data
{
    public partial class Employee : BaseEntity
    {
        public string Name { get; set; }
        public int EmployeesId { get; set; }
        public string Location { get; set; }
    }
}
