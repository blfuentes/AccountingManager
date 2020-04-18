using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.DAL.DataService
{
    interface IDataService<Entity>
    {
        Task<Entity> GetItemByID(int id);
    }
}
