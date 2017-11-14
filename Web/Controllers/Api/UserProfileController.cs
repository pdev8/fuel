using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Fuel.Models.Domain;
using Fuel.Models.Request;
using Fuel.Services.Interfaces;
using MVCApp.Models.Response;

namespace Fuel.Web.Controllers.Api
{
    [AllowAnonymous]
    [RoutePrefix("api/UserProfiles")]
    public class UserProfileController : ApiController
    {
        IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [Route(), HttpGet]
        public HttpResponseMessage GetAllUserProfiles()
        {
            try
            {
                ItemsResponse<UserProfile> response = new ItemsResponse<UserProfile>();
                response.Items = _userProfileService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetUserProfileById(int id)
        {
            try
            {
                ItemResponse<UserProfile> response = new ItemResponse<UserProfile>();
                response.Item = _userProfileService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route(), HttpPost]
        public HttpResponseMessage PostUserProfile(UserProfileAddRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                ItemResponse<int> response = new ItemResponse<int>();
                response.Item = _userProfileService.Insert(model);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage UpdateUserProfile(UserProfileUpdateRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                _userProfileService.Update(model);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteUserProfile(int id)
        {
            try
            {
                _userProfileService.DeleteById(id);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

    }
}