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

        public IEnumerable<StreamDto> GetStreams()
        {
            var streams = this.dbContext.Streams.IncludeTables(true, true).Select(x => new StreamDto(x)).ToList();
            return streams;
        }

        public IEnumerable<StreamDto> GetOnlineStreams()
        {
            var onlineStreams = this.dbContext.Streams.Where(x => x.IsOnline).Select(x => new StreamDto(x)).ToList();
            return onlineStreams;
        }

        public StreamDto GetStream(string username)
        {
            var stream = dbContext.Streams.IncludeTables(true, true).FirstOrDefault(x => x.User.Username == username);
            return new StreamDto(stream);
        }

        public void ChangeStatus(Guid streamId)
        {
            this.dbContext.Streams.Find(streamId).IsOnline = !this.dbContext.Streams.Find(streamId).IsOnline;
        }
    }
}
