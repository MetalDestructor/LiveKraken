using System;
using System.Collections.Generic;
using System.Text;

namespace LiveKraken.DataServices.Extensions
{
    public static class StreamQueryExtensions
    {
        public static IQueryable<Stream> IncludeTables(this IQueryable<Stream> query, bool user, bool game)
        {

            if (user)
            {
                query.Include(x => x.User);
            }
            if (game)
            {
                query.Include(x => x.Game);
            }
            return query;
        }
    }
}
