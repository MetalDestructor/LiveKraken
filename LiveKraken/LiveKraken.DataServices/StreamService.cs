using LiveKraken.Data;
using LiveKraken.DataServices.Interfaces;
using LiveKraken.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var streams = this.dbContext.Streams.Include(x => x.User).Include(x => x.Game).Select(x => new StreamDto(x)).ToList();
            return streams;
        }

        public IEnumerable<StreamDto> GetOnlineStreams()
        {
            var onlineStreams = this.dbContext.Streams.Where(x => x.IsOnline).Select(x => new StreamDto(x)).ToList();
            return onlineStreams;
        }

        public StreamDto GetStream(string username)
        {
            var stream = this.dbContext.Streams.Include(x => x.User).Include(x => x.Game).FirstOrDefault(x => x.User.Username == username);
            return new StreamDto(stream);
        }

        public void ChangeStatus(Guid streamId)
        {
            this.dbContext.Streams.FirstOrDefault(s => s.StreamId == streamId).IsOnline = !this.dbContext.Streams.FirstOrDefault(s => s.StreamId == streamId).IsOnline;
        }
    }
}
