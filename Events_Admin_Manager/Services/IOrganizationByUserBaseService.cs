using System.Collections.Generic;
using Eleveight.Models.Domain.Events;

namespace Eleveight.Services.Events
{
    public interface IOrganizationByUserBaseService
    {
        OrganizationByUserBase ReadById(int userBaseId);
    }
}