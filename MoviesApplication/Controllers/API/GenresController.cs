using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Data.Interfaces;
using Infrastructure;
using MoviesApplication.Models;

namespace MoviesApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/genres")]
    public class GenresController : APIControllerBase
    {
        private readonly IEntityBaseRepo<Genre> genresRepository;

        public GenresController(IEntityBaseRepo<Genre> genresRepository, IEntityBaseRepo<Error> errorRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork, errorRepository)
        {
            this.genresRepository = genresRepository;
        }

        [AllowAnonymous]
        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var genres = genresRepository.GetAll().ToList();
                var genresMV = Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreViewModel>>(genres);

                response = request.CreateResponse(HttpStatusCode.OK, genresMV);
                return response;
            });
        }
    }
}