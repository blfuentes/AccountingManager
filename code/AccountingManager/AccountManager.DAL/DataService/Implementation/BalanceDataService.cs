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
            if (!(entity is null))
            {
                dto.MonthSort = dto.Date.Month;
                dto.MonthName = (new DateTimeFormatInfo()).GetMonthName(dto.MonthSort);
            }

            return dto;
        }

        public IQueryable<BalanceDTO> GetCollection()
        {
            var entities = dbContext.Balance;
            var dtos = mapper.Map<ICollection<BalanceDTO>>(entities);
            foreach(var _d in dtos)
            {
                _d.MonthSort = _d.Date.Month;
                _d.MonthName = (new DateTimeFormatInfo()).GetMonthName(_d.MonthSort);
            };
            return dtos.AsQueryable();
        }

        public async Task<IList<BalanceDTO>> GetBalancesByYear(int year)
        {
            var entities = dbContext.Balance.Where(_d => _d.Date.Year == year).OrderBy(_d => _d.Date);
            var balanceDTOs = Task<IList<BalanceDTO>>.Factory.StartNew(() =>
            {
                var dtos = mapper.Map<IList<BalanceDTO>>(entities);

                foreach (var _d in dtos)
                {
                    _d.MonthSort = _d.Date.Month;
                    _d.MonthName = (new DateTimeFormatInfo()).GetMonthName(_d.MonthSort);
                };
                return dtos;
            });

            return await balanceDTOs;
        }
    }
}
