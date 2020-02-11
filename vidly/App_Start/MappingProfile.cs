using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Dtos;
using vidly.Models;

namespace vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}