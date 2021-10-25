using AutoMapper;
using RecruitmentTask.Models;
using RecruitmentTask.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTask.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();
        }
    }
}
