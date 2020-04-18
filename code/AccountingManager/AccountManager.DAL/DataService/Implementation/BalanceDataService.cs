using AccountManager.DAL.DTO;
using AccountManager.DAL.EF.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public async Task<BalanceDTO> GetItemByID(int id)
        {
            var entity = await dbContext.FindAsync(typeof(Balance), id);
            var dto = mapper.Map<BalanceDTO>(entity);
            if(!(entity is null))
            {
                dto.MonthSort = dto.Date.Month;
                dto.MonthName = (new DateTimeFormatInfo()).GetMonthName(dto.MonthSort);
            }

            return dto;
        }
    }
}
