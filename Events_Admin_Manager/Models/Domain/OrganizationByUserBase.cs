using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleveight.Models.Domain.Events
{
    public class OrganizationByUserBase
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string GroupName { get; set; }
        public int OrganizationId { get; set; }
        public string OrgName { get; set; }

    }
}
