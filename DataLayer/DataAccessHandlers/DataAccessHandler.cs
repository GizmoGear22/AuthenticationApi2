using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DatabaseAccess;
using Microsoft.Extensions.Configuration;

namespace DataLayer.DataAccessHandlers
{
    public class DataAccessHandler
    {
        private readonly DBAccess _dbAccess;
        private readonly IConfiguration _config;
        public DataAccessHandler(DBAccess dbAccess, IConfiguration config)
        {
            _dbAccess = dbAccess;
            _config = config;
        }
    }
}
