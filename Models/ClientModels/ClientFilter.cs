using System.Linq;

namespace Golden_Leaf_Back_End.Models.ClientModels
{
    public static class ClientFilterExtentions
    {
        public static IQueryable<Client> AplyFilter(this IQueryable<Client> query, ClientFilter filter)
        {
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    query = query.Where(c => c.Name.ToLower().Contains(filter.Name.ToLower()));
                }

                if (!string.IsNullOrEmpty(filter.Address))
                {
                    query = query.Where(c => c.Address.ToLower().Contains(filter.Address.ToLower()));
                }

                if (!string.IsNullOrEmpty(filter.PhoneNumber))
                {
                    query = query.Where(c => c.PhoneNumber.Contains(filter.PhoneNumber));
                }

                if (filter.Status != null)
                {
                    query = query.Where(c => c.Status == filter.Status);
                }

            }
            return query;
        }

    }
    public class ClientFilter
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Status? Status { get; set; }
    }
}
