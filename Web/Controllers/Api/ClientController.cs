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
    [RoutePrefix("api/Clients")]
    public class ClientController : ApiController
    {
        IClientService _clientservice;

        public ClientController(IClientService clientservice)
        {
            _clientservice = clientservice;
        }

        [Route(), HttpGet]
        public HttpResponseMessage GetAllClients()
        {
            try
            {
                ItemsResponse<Client> response = new ItemsResponse<Client>();
                response.Items = _clientservice.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetClientById(int id)
        {
            try
            {
                ItemResponse<Client> response = new ItemResponse<Client>();
                response.Item = _clientservice.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route(), HttpPost]
        public HttpResponseMessage PostClient(ClientAddRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                ItemResponse<int> response = new ItemResponse<int>();
                response.Item = _clientservice.Insert(model);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage UpdateClient(ClientUpdateRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                _clientservice.Update(model);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteClient(int id)
        {
            try
            {
                _clientservice.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

    }
}