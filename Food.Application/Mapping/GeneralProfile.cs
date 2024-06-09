using AutoMapper;
using Food.Application.Features.Products.Commands;
using Food.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Application.Mapping
{
	public class GeneralProfile : Profile
	{
        public GeneralProfile()
        {
            CreateMap<CreateProductCommand, Domain.Entities.Product>()
                .ForMember(source => source.Description, destination => destination.MapFrom(src => src.Remarks));
        }
    }
}
