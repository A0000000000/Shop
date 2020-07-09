using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.DatabaseContext;
using Shop.Models.ORM.User;

namespace Shop.Entity.Impl
{
    public class LocationEntity: ILocationEntity
    {
        private readonly SqlServerDatabaseContext _context;
        private readonly DbSet<Location> Locations;

        public LocationEntity(SqlServerDatabaseContext context)
        {
            _context = context;
            Locations = context.Locations;
        }


        public async Task<Location> GetLocationByName(string name)
        {
            return await (from locations in Locations where locations.Name == name select locations).FirstOrDefaultAsync();
        }

        public async Task AddNewLocation(Location location)
        {
            await Locations.AddAsync(location);
            await _context.SaveChangesAsync();
        }
    }
}
