using System;
using System.Linq;

namespace Golden_Leaf_Back_End.Models.PaymentModels
{
    public static class OrderFilterExtentions
    {
        public static IQueryable<PaymentApiModel> AplyFilter(this IQueryable<PaymentApiModel> query, PaymentFilter filter)
        {
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Client))
                {
                    query = query.Where(p => 
                        p.ClientName
                        .ToLower()
                        .Contains(filter.Client.ToLower()));
                }
                if (!string.IsNullOrEmpty(filter.Clerk))
                {
                    query = query.Where(p => 
                        p.ClerkName
                        .ToLower()
                        .Contains(filter.Client.ToLower()));
                }

                if (filter.AmountBiggerThan != 0)
                {
                    query = query.Where(p => p.Amount > filter.AmountBiggerThan);
                }

                if (filter.AmountLessThan != 0)
                {
                    query = query.Where(p => filter.AmountLessThan > p.Amount);
                }

                if (filter.Before != null)
                {
                    query = query.Where(p => filter.Before > p.Date);
                }

                if (filter.After != null)
                {
                    query = query.Where(p => p.Date > filter.After);
                }

            }
            return query;
        }

    }
    public class PaymentFilter
    {
        public string Client { get; set; }
        public string Clerk { get; set; }
        public float AmountBiggerThan { get; set; }
        public float AmountLessThan { get; set; }
        public DateTime? Before { get; set; }
        public DateTime? After { get; set; }
    }
}
