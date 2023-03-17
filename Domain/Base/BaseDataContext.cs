using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public class BaseDataContext : IDisposable
    {
        protected DataContext _context = null;
        protected IMapper _mapper = null;
        private readonly IConfiguration _config;


        public BaseDataContext(IConfiguration config, IMapper mapper)
        {
            var dbOptions = new DbContextOptionsBuilder<DataContext>()
                            .UseSqlServer(config.GetConnectionString("Shopbridge_Context"))
                            .Options;

            _context = new DataContext(dbOptions);
            _mapper = mapper;
            _config = config;
        }

        public void Dispose()
        {
                    _context.Dispose();

        }
    }
}
