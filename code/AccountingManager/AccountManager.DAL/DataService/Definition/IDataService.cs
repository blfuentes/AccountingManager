using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.DAL.DataService
{
    public interface IDataService<Entity> where Entity : class
    {
        Task AddItem(Entity entity);
        Task<Entity> GetItemByID(int id);
        IQueryable<Entity> GetCollection();
    }
}
