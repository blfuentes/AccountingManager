using AccountManager.DAL.DTO;
using AccountManager.DAL.EF.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.DAL.DataService
{
    public class BalanceDataService : BaseDataService<Balance, BalanceDTO>, IDataService<BalanceDTO>
    {
        private readonly AccountManagerContext dbContext;

        public BalanceDataService()
        {

        }

        public BalanceDataService(DbContextOptionsBuilder<AccountManagerContext> optionsBuilder)
        {
            dbContext = new AccountManagerContext(optionsBuilder.Options);

            // custom mapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Balance, BalanceDTO>()
                    .ForMember(dest => dest.MonthSort, source => source.MapFrom(source => source.Date.Month))
                    .ForMember(dest => dest.MonthName, source => source.MapFrom(source => (new DateTimeFormatInfo()).GetMonthName(source.Date.Month)))
                    .ReverseMap();
            });
            mapper = config.CreateMapper();
        }

        public async Task AddItem(BalanceDTO dto)
        {
            var entity = mapper.Map<Balance>(dto);
            await dbContext.Balance.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<BalanceDTO> GetItemByID(int id)
        {
            var entity = await dbContext.FindAsync(typeof(Balance), id);
            var dto = mapper.Map<BalanceDTO>(entity);

            return dto;
        }

        public IQueryable<BalanceDTO> GetCollection()
        {
            var entities = dbContext.Balance;
            var dtos = mapper.Map<ICollection<BalanceDTO>>(entities);

            return dtos.AsQueryable();
        }

        public async Task<IList<BalanceDTO>> GetBalancesByYear(int year)
        {
            var entities = dbContext.Balance.Where(_d => _d.Date.Year == year).OrderBy(_d => _d.Date);
            var balanceDTOs = Task<IList<BalanceDTO>>.Factory.StartNew(() =>
            {
                var dtos = mapper.Map<IList<BalanceDTO>>(entities);

                return dtos;
            });

            return await balanceDTOs;
        }
    }
}
