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
    [RoutePrefix("api/UserRoles")]
    public class UserRoleController : ApiController
    {
        IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [Route(), HttpGet]
        public HttpResponseMessage GetAllUserRoles()
        {
            try
            {
                ItemsResponse<UserRole> response = new ItemsResponse<UserRole>();
                response.Items = _userRoleService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}