using System;
using System.Collections.Generic;

#nullable disable

namespace TestApi.Data
{
    public partial class Stk : BaseEntity
    {
        public string MalKodu { get; set; }
        public string MalAdi { get; set; }
    }
}
