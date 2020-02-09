using LiveKraken.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveKraken.DataServices.Extensions
{
    public static class StreamQueryExtensions
    {
        public static IQueryable<Stream> IncludeTables(this IQueryable<Stream> query, bool user, bool game)
        {

            if (user)
            {
                query = query.Include(x => x.User);
            }
            if (game)
            {
                query = query.Include(x => x.Game);
            }
            return query;
        }
    }
}
