// MyBlazorHybridApp.Shared/Services/SpecialsService.cs
using MyBlazorHybridApp.Shared.Model;
using MyBlazorHybridApp.Shared.Data;
using Microsoft.EntityFrameworkCore;

    public class SpecialsService
    {
        private readonly PizzaStoreContext _db;

        public SpecialsService(PizzaStoreContext db)
        {
            _db = db;
        }

        public async Task<List<PizzaSpecial>> GetSpecialsAsync()
        {
            return await _db.Specials
                            .OrderByDescending(s => s.BasePrice)
                            .ToListAsync();
        }
    }
