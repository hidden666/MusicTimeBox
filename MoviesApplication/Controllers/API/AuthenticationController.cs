using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;
using Data.Interfaces;
using Infrastructure;
using Membership;
using Membership.Interfaces;
using MoviesApplication.Models;

namespace MoviesApplication.Controllers.API
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/account")]
    public class AuthenticationController : APIControllerBase
    {
        private readonly IMembershipService membershipService;

        public AuthenticationController(IMembershipService membershipService, IEntityBaseRepo<Error> errorRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork, errorRepository)
        {
            this.membershipService = membershipService;
        }

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel model)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    var context = membershipService.ValidateUser(model.UserName, model.Password);
                    if (context.User != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }

                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
                }
                return response;
            });
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request, RegistrationViewModel model)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    var user = membershipService.CreateUser(model.UserName, model.Email, model.Password, new []{1});

                    if (user != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }

                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
                }
                return response;
            });
        }
    }
}
