using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.DAL.DataService
{
    public class BaseDataService<OEntity, TEntity>
    {
        protected IMapper mapper;

        public BaseDataService()
        {
            // One time configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OEntity, TEntity>().ReverseMap();
            });
            mapper = config.CreateMapper();
        }
    }
}
