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
    [RoutePrefix("api/movies")]
    public class MoviesController : APIControllerBase
    {
        private readonly IEntityBaseRepo<Movie> moviesRepository;

        public MoviesController(IEntityBaseRepo<Movie> moviesRepository, IEntityBaseRepo<Error> errorRepository, IUnitOfWork unitOfWork) 
            : base(unitOfWork, errorRepository)
        {
            this.moviesRepository = moviesRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var movies = moviesRepository.GetAll().OrderByDescending(x => x.ReleaseDate).Take(6).ToList();
                var moviesVM = Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(movies);

                response = request.CreateResponse(HttpStatusCode.OK, moviesVM);
                return response;
            });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("details/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return this.CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var movie = moviesRepository.GetSingle(id);

                if (movie == null)
                {
                    ModelState.AddModelError("No such Movie", "No such movie exists");
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                        ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray());
                }

                else
                {
                    response = request.CreateResponse<MovieViewModel>(HttpStatusCode.OK,
                        Mapper.Map<Movie, MovieViewModel>(movie));
                }

                return response;
            });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("search/{page:int=0}/{pageSize:int=4}/{filter?}")]
        public HttpResponseMessage Search(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;
            int currentpageSize = pageSize.Value;

            return this.CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                List<Movie> moviesList = null;
                int totalMovNom = 0;

                if (string.IsNullOrEmpty(filter))
                {
                    moviesList = moviesRepository.GetAll().ToList();
                }
                else
                {
                    moviesList = moviesRepository.GetAll().OrderBy(movies => movies.Id)
                        .Where(movies => movies.Title.ToLower()
                        .Contains(filter.ToLower().Trim()) ||
                         movies.Writer.ToLower()
                        .Contains(filter.ToLower().Trim()) ||
                         movies.Director.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .ToList();
                }

                totalMovNom = moviesList.Count;
                moviesList = moviesList.Skip(currentPage * currentpageSize).Take(currentpageSize).ToList();

                IEnumerable<MovieViewModel> moviesVM =
                    Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(moviesList);

                Pagination<MovieViewModel> pagedVMSet = new Pagination<MovieViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalMovNom,
                    TotalPages = (int)Math.Ceiling((decimal)totalMovNom / currentpageSize),
                    Items = moviesVM
                };

                response = request.CreateResponse<Pagination<MovieViewModel>>(HttpStatusCode.OK, pagedVMSet);

                return response;
            });
        }
    }
}
