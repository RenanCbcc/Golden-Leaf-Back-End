using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Golden_Leaf_Back_End.Models.ClerkModels
{
    public interface IClerkRepository
    {
        Task<Clerk> Read(int Id);
        Clerk Read(string Id);
        Task Add(Clerk clerk);
        Task Edit(Clerk clerk);
    }

    public class ClerkRepository : IClerkRepository
    {

        private readonly GoldenLeafContext context;

        public ClerkRepository(GoldenLeafContext context)
        {
            this.context = context;
        }
        public async Task Add(Clerk clerk)
        {
            await context.AddAsync(clerk);
            await context.SaveChangesAsync();
        }

        public async Task Edit(Clerk alteredclerk)
        {
            var clerk = context.Clerks.Attach(alteredclerk);
            clerk.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Clerk> Read(int Id)
        {
            return await context.Clerks.FindAsync(Id);
        }

        public Clerk Read(string Id)
        {
            return context.Clerks.Single(c => c.User.Id == Id);
        }


    }
}
