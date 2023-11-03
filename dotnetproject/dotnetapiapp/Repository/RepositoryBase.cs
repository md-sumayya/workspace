using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapiapp.Models;

namespace dotnetapiapp.Repository
{
    public abstract class RepositoryBase
    {
        protected readonly OrderDeliveryDbContext _context;
        public RepositoryBase(OrderDeliveryDbContext context){
            _context = context;
        }
        
    }
}