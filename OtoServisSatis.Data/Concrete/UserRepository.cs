using Microsoft.EntityFrameworkCore;
using OtoServisSatis.Data.Abstract;
using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data.Concrete
{
    public class UserRepository : Repository<Kullanici>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Kullanici>> GetCustomerList()
        {
            return await _dbSet.AsNoTracking().Include(x => x.Rol).ToListAsync();
        }

        public async Task<List<Kullanici>> GetCustomerList(Expression<Func<Kullanici, bool>> expression)
        {
            return await _dbSet.Where(expression).AsNoTracking().Include(x => x.Rol).ToListAsync();
        }
    }
}
