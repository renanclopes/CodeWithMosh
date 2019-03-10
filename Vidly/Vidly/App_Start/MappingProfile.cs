using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Customers
            Mapper.CreateMap<Customer, CustomerDto>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<CustomerDto, Customer>();

            //Movies
            Mapper.CreateMap<Movie, MovieDto>();                

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}