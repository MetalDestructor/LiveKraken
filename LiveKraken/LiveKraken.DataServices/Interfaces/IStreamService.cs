using LiveKraken.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveKraken.DataServices.Interfaces
{
    public interface IStreamService
    {
        IEnumerable<StreamDto> GetStreams();
        IEnumerable<StreamDto> GetOnlineStreams();
        StreamDto GetStream(string username);
        void ChangeStatus(Guid streamId);
    }
}
