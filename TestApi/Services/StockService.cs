using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Repositories;
using TestApi.Data;
using TestApi.UOW;
using TestApi.DTO.Response;
using TestApi.DTO.Request;
using TestApi.Constants;

namespace TestApi.Services
{
    public class StockService
    {
        private readonly IEFRepository<Sti> _stockRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StockService(IEFRepository<Sti> stockRepository, IUnitOfWork unitOfWork)
        {
            _stockRepository = stockRepository;
            _unitOfWork = unitOfWork;
        }

        public IList<Sti> GetStocks()
        {
            return _stockRepository.Get().ToList();
        }

        public IList<StockProcedureResponseDto> RunStockProcedure(StockProcedureRequestDto stockProcedureRequestDto)
        {
            var query = _stockRepository.Get();

            if(!string.IsNullOrWhiteSpace(stockProcedureRequestDto.ProductCode)){
                query = query.Where(t => t.MalKodu.Contains(stockProcedureRequestDto.ProductCode));
            }

            query = query.Where(t => t.Tarih >= Convert.ToInt32(stockProcedureRequestDto.StartDate.ToOADate()));
            query = query.Where(t => t.Tarih <= Convert.ToInt32(stockProcedureRequestDto.EndDate.ToOADate()));

            var stocks = query.ToList();
            List<StockProcedureResponseDto> responseList = new();

            stocks.ForEach(item => {
                StockProcedureResponseDto response = new();
                response.SiraNo = item.Id;
                response.EvrakNo = item.EvrakNo;
                response.Tarih = DateTime.FromOADate(item.Tarih);

                if(item.IslemTur == (short) StockEnum.actionTypeZero){
                    response.IslemTur = StockConstant.enter;
                    response.GirisMiktar = item.Miktar;
                    response.CikisMiktar = 0;
                    response.Stok += item.Miktar;
                }
                else if(item.IslemTur == (short) StockEnum.actionTypeOne){
                    response.IslemTur = StockConstant.exit;
                    response.GirisMiktar = 0;
                    response.CikisMiktar = item.Miktar;
                    response.Stok -= item.Miktar;
                } 

                responseList.Add(response);       
            });

            return responseList;
        }
    }
}