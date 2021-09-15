using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.DTO.Response
{
    public class StockProcedureResponseDto
    {
        public int SiraNo { get; set; }
        public string IslemTur { get; set; }
        public string EvrakNo { get; set; }
        public DateTime Tarih { get; set; }
        public decimal GirisMiktar { get; set; }
        public decimal CikisMiktar { get; set; }
        public decimal Stok { get; set; }
    }
}