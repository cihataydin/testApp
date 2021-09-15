using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestApi.Services;
using TestApi.Data;
using TestApi.DTO.Request;
using TestApi.DTO.Response;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StockController : ControllerBase
    {
        private readonly ILogger<StockController> _logger;
        private readonly StockService _stockService;

        public StockController(ILogger<StockController> logger, StockService stockService)
        {
            _logger = logger;
            _stockService = stockService;
        }

        [HttpPost]
        public IEnumerable<StockProcedureResponseDto> RunStockProsedure(StockProcedureRequestDto requestDto)
        {
            return _stockService.RunStockProcedure(requestDto);
        }
    }
}
