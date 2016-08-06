using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MoviesApplication.Models;

namespace Infrastructure.DomainToModelProfilers
{
    class DomainToViewModelProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Movie, MovieViewModel>()
                .ForMember(vm => vm.Genre, map => map.MapFrom(m => m.Genre.Name))
                .ForMember(vm => vm.GenreId, map => map.MapFrom(m => m.Genre.Id))
                .ForMember(vm => vm.IsAvailable, map => map.MapFrom(m => m.Stock.Any(s => s.isAvailable.HasValue? s.isAvailable.Value : false)))
                .ForMember(vm => vm.NumberOfStocks, map => map.MapFrom(m => m.Stock.Count))
                .ForMember(vm => vm.Image, map => map.MapFrom(m => string.IsNullOrEmpty(m.Image) == true ? "unknown.jpg" : m.Image));

            Mapper.CreateMap<Genre, GenreViewModel>()
               .ForMember(vm => vm.NumberOfMovies, map => map.MapFrom(g => g.Movie.Count()));

            Mapper.CreateMap<Customer, CustomerViewModel>();
        }
    }
}
