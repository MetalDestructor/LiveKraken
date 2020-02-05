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
        void ChangeStatus(Guid streamId);
    }
}
