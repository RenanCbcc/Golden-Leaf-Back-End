using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golden_Leaf_Back_End.Models.OrderModels
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> Read(int Id);
    }
    public class ItemRepository : IItemRepository
    {
        private readonly GoldenLeafContext context;

        public ItemRepository(GoldenLeafContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Item>> Read(int Id)
        {
            return await context
                .Items
                .Include(i => i.Product)
                .Where(i => i.OrderId == Id)
                .ToListAsync();
        }

    }
}
