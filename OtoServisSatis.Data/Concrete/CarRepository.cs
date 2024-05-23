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
    public class CarRepository : Repository<Arac>, ICarRepository
    {
        public CarRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Arac> GetCustomCar(int id)
        {
            return await _dbSet.AsNoTracking().Include(x => x.Marka).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Arac>> GetCustomCarList()
        {
            //AsNoTracking Liste üzerinden CRUD işlemi yapılmayacaksa kullanılır performansı arttırır
            return await _dbSet.AsNoTracking().Include( x => x.Marka).ToListAsync();
        }

        public async Task<List<Arac>> GetCustomCarList(Expression<Func<Arac, bool>> expression)
        {
            return await _dbSet.Where(expression).AsNoTracking().Include(x => x.Marka).ToListAsync();
        }
    }
}
