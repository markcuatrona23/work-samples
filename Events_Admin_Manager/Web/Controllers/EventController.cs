using Eleveight.Models.Domain.Events;
using Eleveight.Models.Requests.App;
using Eleveight.Models.Requests.Events;
using Eleveight.Models.Responses;
using Eleveight.Services;
using Eleveight.Services.App;
using Eleveight.Services.Events;
using System;
using System.Web.Http;

namespace Eleveight.Web.Controllers.Api.Events
{
    [RoutePrefix("api/events/events")]
    public class EventController : ApiController
    {
        private IEventService _Service;
        private IUserService _userService;
        private IAppLogService _appLogService;

        public EventController(IEventService service, IUserService userService, IAppLogService appLogService)
        {
            _Service = service;
            _userService = userService;
            _appLogService = appLogService;
        }

        [Route(), HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                int userBaseId = _userService.GetCurrentUserId();
                ItemsResponse<Event> response = new ItemsResponse<Event>();
                response.Items = _Service.ReadAll(userBaseId);
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

        [Route("selectall"), HttpGet]
        public IHttpActionResult GetAllEvents()
        {
            try
            {
                ItemsResponse<Event> response = new ItemsResponse<Event>();
                response.Items = _Service.ReadAllEvents();
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


        [Route("Related/{id:int}"), HttpGet]
        public IHttpActionResult GetAllByOrgId(int id)
        {
            try
            {
                ItemsResponse<Event> response = new ItemsResponse<Event>();
                response.Items = _Service.ViewRelatedEventsById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id:int}"), HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                ItemResponse<Event> response = new ItemResponse<Event>
                {
                    Item = _Service.ReadById(id)
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

        [Route(), HttpPost]
        public IHttpActionResult Post(EventAddRequest data)
        {
            try
            {
                data.CreatedById = _userService.GetCurrentUserId();
                data.ModifiedById = _userService.GetCurrentUserId();
                if (!ModelState.IsValid) return BadRequest(ModelState);
                ItemResponse<int> response = new ItemResponse<int>
                {
                    Item = _Service.Insert(data)
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

        [Route("Save"), HttpPost]
        public IHttpActionResult Save(EventAddRequest data)
        {
            try
            {
                data.CreatedById = _userService.GetCurrentUserId();
                data.ModifiedById = _userService.GetCurrentUserId();
                if (!ModelState.IsValid) return BadRequest(ModelState);
                ItemResponse<int> response = new ItemResponse<int>
                {
                    Item = _Service.Save(data)
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id:int}"), HttpPut]
        public IHttpActionResult Put(EventUpdateRequest data)
        {
            try
            {
                data.ModifiedById = _userService.GetCurrentUserId();
                _Service.Update(data);
                return Ok(new SuccessResponse());
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

        [Route("{id:int}"), HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _Service.Delete(id);
                return Ok(new SuccessResponse());
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