using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.DTO.Request
{
    public class StockProcedureRequestDto
    {
        public string ProductCode { get; set; }
        public DateTime StartDate { get; set; }     
        public DateTime EndDate { get; set; }
    }
}