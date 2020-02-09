using LiveKraken.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveKraken.DataServices.Interfaces
{
    public interface IStreamService
    {
        Task<IEnumerable<StreamDto>> GetStreams();
        Task<IEnumerable<StreamDto>> GetOnlineStreams();
        Task<StreamDto> GetStream(string username);
        Task ChangeStatus(Guid streamId);
    }
}
