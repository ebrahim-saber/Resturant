using Resturant_pro.AccessData.Repository.IRepository;
using Resturant_pro.Models;
using Resturant_Pro.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturant_pro.AccessData.Repository;


namespace Resturant_pro.AccessData.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }
        private readonly ApplicationDbContext _db;

        public void Update(ApplicationUser obj)
        {
            _db.ApplicationUsers.Update(obj);
        }
    }
}
