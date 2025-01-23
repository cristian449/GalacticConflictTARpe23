using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticConflict.Core.Domain;

namespace IntergalacticConflict.Core.ServiceInterface
{
    public interface IPlayersProfileServices
    {
        Task<PlayerProfile> Create(string useridfor);
    }
}
