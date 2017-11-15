using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MVCApp.Models.Response;
using Fuel.Services.Interfaces;
using Fuel.Models.Domain;
using Fuel.Models.Request;
using HtmlAgilityPack;

namespace Fuel.Web.Controllers.Api
{
    [AllowAnonymous]
    [RoutePrefix("api/Trainers")]
    public class TrainerController : ApiController
    {
        ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [Route(), HttpGet]
        public HttpResponseMessage GetAllTrainers()
        {
            try
            {
                ItemsResponse<Trainer> response = new ItemsResponse<Trainer>();
                response.Items = _trainerService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetTrainerById(int id)
        {
            try
            {
                ItemResponse<Trainer> response = new ItemResponse<Trainer>();
                response.Item = _trainerService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route(), HttpPost]
        public HttpResponseMessage PostTrainer(TrainerAddRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                ItemResponse<int> response = new ItemResponse<int>();
                response.Item = _trainerService.Insert(model);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage UpdateTrainer(TrainerUpdateRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                _trainerService.Update(model);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteTrainer(int id)
        {
            try
            {
                _trainerService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("url"), HttpPost]
        public HttpResponseMessage WebScraper(WebScraperRequest model)
        {
            try
            {
                var html = new HtmlDocument();
                //html.Load(@"C:\Repo\Github\fuel\Web\Scripts\Views\ModelHTML.html");
                html.LoadHtml(new WebClient().DownloadString(model.Url));
                var root = html.DocumentNode;
                //var p = root.Descendants()
                //    .Where(n => n.GetAttributeValue("id", "").Equals("main"))
                //    .Single()
                //    .Descendants("h1")
                //    .Single();

                //var content = p.InnerText;


                var p = root.Descendants()
                    .Where(n => n.GetAttributeValue("class", "").Equals("pg-headline")).Single();

                var content = p.InnerText;

                //var p = root.Descendants()
                //    .Where(n => n.GetAttributeValue("class", "").Equals("ratingValue")).Single()
                //    .Descendants("span")
                //    .Where(n => n.GetAttributeValue("itemprop", "").Equals("ratingValue"))
                //    .Single();

                //var content = p.InnerText;

                return Request.CreateResponse(HttpStatusCode.OK, content);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}