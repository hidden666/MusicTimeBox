using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Data.Interfaces;
using Infrastructure;
using WebGrease.Activities;

namespace MoviesApplication.Controllers
{
    public class APIControllerBase : ApiController
    {
        private readonly IEntityBaseRepo<Error> errorRepository;
        private readonly IUnitOfWork unitOfWork;

        public APIControllerBase(IUnitOfWork unitOfWork, IEntityBaseRepo<Error> errorRepository )
        {
            this.unitOfWork = unitOfWork;
            this.errorRepository = errorRepository;

        }

        protected virtual HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> executiveFunction)
        {
            HttpResponseMessage response = null;

            try
            {
                response = executiveFunction.Invoke();
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.BadRequest, (ex is DbUpdateException) ? ex.InnerException.Message : ex.Message);
            }

            return response;
        }

        private void LogError(Exception ex)
        {
            try
            {
                var newError = new Error() { Message = ex.Message, StackTrace = ex.StackTrace };
                errorRepository.Add(newError);
                unitOfWork.Commit();
            }
            catch 
            {
            }
        }
    }
}
