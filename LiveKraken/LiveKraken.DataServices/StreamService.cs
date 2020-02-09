using LiveKraken.Data;
using LiveKraken.DataServices.Interfaces;
using LiveKraken.DataServices.Extensions;
using LiveKraken.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveKraken.DataServices
{
    public class StreamService : IStreamService
    {
        private readonly ApplicationDbContext dbContext;
        public StreamService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
        }

        public async Task<IEnumerable<StreamDto>> GetStreams()
        {
            var streams = await this.dbContext.Streams.IncludeTables(true, true).Select(x => new StreamDto(x)).ToListAsync();
            return streams;
        }

        public async Task<IEnumerable<StreamDto>> GetOnlineStreams()
        {
            var onlineStreams = await this.dbContext.Streams.Where(x => x.IsOnline).Select(x => new StreamDto(x)).ToListAsync();
            return onlineStreams;
        }

        public async Task<StreamDto> GetStream(string username)
        {
            var stream = await dbContext.Streams.IncludeTables(true, true).SingleOrDefaultAsync(x => x.User.Username == username);
            return new StreamDto(stream);
        }

        public async Task ChangeStatus(Guid streamId)
        {
            var stream = await this.dbContext.Streams.FindAsync(streamId);
            stream.IsOnline = !stream.IsOnline;
            await this.dbContext.SaveChangesAsync();
        }
    }
}
