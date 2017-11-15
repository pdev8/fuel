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
    [RoutePrefix("api/TrainingLogs")]
    public class TrainingLogController : ApiController
    {
        ITrainingLogService _trainingLogService;

        public TrainingLogController(ITrainingLogService trainingLogService)
        {
            _trainingLogService = trainingLogService;
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetTrainingLogByWeek(int id)
        {
            try
            {
                ItemResponse<TrainingLog> response = new ItemResponse<TrainingLog>();
                response.Item = _trainingLogService.GetByWeek(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route(), HttpPost]
        public HttpResponseMessage PostTrainingLog(TrainingLogAddRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                ItemResponse<int> response = new ItemResponse<int>();
                response.Item = _trainingLogService.Insert(model);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage UpdateTrainingLog(TrainingLogUpdateRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                _trainingLogService.UpdateByWeek(model);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteTrainingLogByWeek(int id)
        {
            try
            {
                _trainingLogService.DeleteByWeek(id);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

    }
}