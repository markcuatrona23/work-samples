using Eleveight.Models.Domain.Events;
using Eleveight.Models.Requests.Events;
using Eleveight.Models.Responses;
using Eleveight.Services;
using Eleveight.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Eleveight.Services.App;
using Eleveight.Models.Requests.App;

namespace Eleveight.Web.Controllers.Api.Events
{
    [RoutePrefix("api/events/orgId")]
    public class OrganizationByUserBaseController : ApiController
    {
        IOrganizationByUserBaseService _organizationByUserBaseService;
        IUserService _userService;
        IAppLogService _appLogService;
        public OrganizationByUserBaseController(IOrganizationByUserBaseService organizationByUserBaseService, IUserService userService, IAppLogService appLogService)
        {
            _organizationByUserBaseService = organizationByUserBaseService;
            _userService = userService;
            _appLogService = appLogService;
        }

        [Route("{userBaseId:int}"), HttpGet]
        public IHttpActionResult GetOrgById(int userBaseId)
        {
            try
            {
                userBaseId = _userService.GetCurrentUserId();
                ItemResponse<OrganizationByUserBase> response = new ItemResponse<OrganizationByUserBase>
                {
                    Item = _organizationByUserBaseService.ReadById(userBaseId)
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                int currentUser = _userService.GetCurrentUserId();
                _appLogService.Insert(new AppLogAddRequest
                {
                    AppLogTypeId = 1,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    Title = "Error in " + GetType().Name + " " + System.Reflection.MethodBase.GetCurrentMethod().Name,
                    UserBaseId = currentUser
                });
                return BadRequest(ex.Message);
            }
        }

    }


}