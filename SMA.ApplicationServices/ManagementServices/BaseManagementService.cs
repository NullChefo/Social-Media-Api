using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMA.Data.Contexts;


namespace SMA.ApplicationServices.ManagementServices
{
    public class BaseManagementService
    {
        
        protected readonly SmaDbContext _context = new SmaDbContext();
        
    }
}
