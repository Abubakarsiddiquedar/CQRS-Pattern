using AutoMapper;
using Food.Application.Interface;
using Food.Application.Wrapper;
using Food.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Application.Features.Products.Commands
{
	public class CreateProductCommand : IRequest<ApiResponse<int>>
	{
		public string? Name { get; set; }	
		public string? Remarks { get; set; }

		public decimal Rate { get; set; }

		internal class CreateProductHandler : IRequestHandler<CreateProductCommand, ApiResponse<int>>
		{
			private readonly IApplicationDbContext _context;
			private readonly IMapper _mapper;

			public CreateProductHandler(IApplicationDbContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}
			
			public async Task<ApiResponse<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
			{

				var product = _mapper.Map<Domain.Entities.Product>(request);
				_context.Products.Add(product);
				await _context.SaveChangesAsync();
				return new ApiResponse<int>(product.Id, "Created successfully");
				
			}
		}
	}
}
