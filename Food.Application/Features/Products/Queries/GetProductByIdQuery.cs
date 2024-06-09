using Food.Application.Exceptions;
using Food.Application.Interface;
using Food.Application.Wrapper;
using Food.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Application.Features.Products.Queries
{
	public class GetProductByIdQuery : IRequest<ApiResponse<Product>>
	{
		public int Id { get; set; }
		
		internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ApiResponse<Product>>
		{
			private readonly IApplicationDbContext _context;
			public GetProductByIdQueryHandler(IApplicationDbContext context)
			{
				_context = context;
			}
			public async Task<ApiResponse<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
			{
				var result = await _context.Products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
				if(result == null)
				{
					throw new ApiException("Product not found");
				}
				return new ApiResponse<Product>(result, "Data Fetched successfully");
				
			}
		}
	}

}
