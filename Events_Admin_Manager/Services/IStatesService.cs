using Eleveight.Models.Domain.Common;
using System.Collections.Generic;

namespace Eleveight.Services.Common
{
    public interface IStatesService
    {
        List<States> ReadAll();
    }
}