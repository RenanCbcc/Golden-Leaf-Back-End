using System;
using System.Linq;

namespace Golden_Leaf_Back_End.Models.OrderModels
{
    public static class OrderFilterExtentions
    {
        public static IQueryable<OrderApiModel> AplyFilter(this IQueryable<OrderApiModel> query, OrderFilter filter)
        {
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Client))
                {
                    query = query.Where(o => o.ClientName.Contains(filter.Client));
                }

                if (!string.IsNullOrEmpty(filter.Clerk))
                {
                    query = query.Where(p => p.ClerkName.Contains(filter.Client));
                }


                if (filter.ValueBiggerThan != 0)
                {
                    query = query.Where(o => o.Value > filter.ValueBiggerThan);
                }

                if (filter.ValueLessThan != 0)
                {
                    query = query.Where(o => filter.ValueLessThan > o.Value);
                }

                if (filter.Before != null)
                {
                    query = query.Where(o => filter.Before > o.Date);
                }

                if (filter.After != null)
                {
                    query = query.Where(o => o.Date > filter.After);
                }


            }
            return query;
        }

    }
    public class OrderFilter
    {
        public string Client { get; set; }
        public string Clerk { get; set; }
        public float ValueBiggerThan { get; set; }
        public float ValueLessThan { get; set; }
        public DateTime? Before { get; set; }
        public DateTime? After { get; set; }
    }
}
