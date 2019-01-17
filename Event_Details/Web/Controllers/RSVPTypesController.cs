using Eleveight.Models.Domain.Events;
using Eleveight.Models.Requests.Events;
using Eleveight.Models.Responses;
using Eleveight.Services;
using Eleveight.Services.Events;
using System;
using System.Web.Http;

namespace Eleveight.Web.Controllers.Api.Events
{
    [RoutePrefix("api/events/rsvptypes")]
    public class RSVPTypesController : ApiController
    {
        private IRSVPTypesService _Service;
        private IUserService _userService;

        public RSVPTypesController(IRSVPTypesService service, IUserService userService)
        {
            _Service = service;
            _userService = userService;
        }

        [Route(), HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                ItemsResponse<RSVPTypes> response = new ItemsResponse<RSVPTypes>();
                response.Items = _Service.ReadAll();
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
                ItemResponse<RSVPTypes> response = new ItemResponse<RSVPTypes>
                {
                    Item = _Service.ReadById(id)
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route(), HttpPost]
        public IHttpActionResult Post(RSVPTypesAddRequest data)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                ItemResponse<int> response = new ItemResponse<int>
                {
                    Item = _Service.Insert(data)
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id:int}"), HttpPut]
        public IHttpActionResult Put(RSVPTypesUpdateRequest data)
        {
            try
            {
                _Service.Update(data);
                return Ok(new SuccessResponse());
            }
            catch (Exception ex)
            {
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
                return BadRequest(ex.Message);
            }
        }
    }
}