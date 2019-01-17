using Eleveight.Models.Domain.Events;
using Eleveight.Models.Requests.Events;
using Eleveight.Models.Responses;
using Eleveight.Services;
using Eleveight.Services.Events;
using System;
using System.Web.Http;

namespace Eleveight.Web.Controllers.Api.Events
{
    [RoutePrefix("api/events/eventRSVPs")]
    public class EventRSVPController : ApiController
    {
        private IEventRSVPService _eventRSVPService;
        private IUserService _userService;

        public EventRSVPController(IEventRSVPService eventRSVPService, IUserService userService)
        {
            _eventRSVPService = eventRSVPService;
            _userService = userService;
        }

        [Route(), HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                ItemsResponse<EventRSVP> response = new ItemsResponse<EventRSVP>();
                response.Items = _eventRSVPService.ReadAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{eventId:int}"), HttpGet]
        public IHttpActionResult GetById(int eventId)
        {
            try
            {
                ItemResponse<EventRSVP> response = new ItemResponse<EventRSVP>
                {
                    Item = _eventRSVPService.ReadById(eventId)
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route(), HttpPost]
        public IHttpActionResult Post(EventRSVPRequest model)
        {
            try
            {
                model.UserBaseId = _userService.GetCurrentUserId();
                if (!ModelState.IsValid) return BadRequest(ModelState);
                ItemResponse<int> response = new ItemResponse<int>
                {
                    Item = _eventRSVPService.Insert(model)
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{eventId:int}/{userBaseId:int}"), HttpPut]
        public IHttpActionResult Put(EventRSVPRequest model)
        {
            try
            {
                model.UserBaseId = _userService.GetCurrentUserId();
                _eventRSVPService.Update(model);
                return Ok(new SuccessResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{eventId:int}/{userBaseId:int}"), HttpDelete]
        public IHttpActionResult Delete(int eventId, int userBaseId)
        {
            try
            {
                userBaseId = _userService.GetCurrentUserId();
                _eventRSVPService.Delete(eventId, userBaseId);
                return Ok(new SuccessResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}