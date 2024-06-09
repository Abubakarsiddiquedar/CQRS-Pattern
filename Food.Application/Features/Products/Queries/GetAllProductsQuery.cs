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
	public class GetAllProductsQuery : IRequest<ApiResponse<IEnumerable<Product>>>
	{
		
		internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ApiResponse<IEnumerable<Product>>>
		{
			private readonly IApplicationDbContext _context;
			public GetAllProductsQueryHandler(IApplicationDbContext context)
			{
				_context = context;
			}
			public async Task<ApiResponse<IEnumerable<Product>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
			{
				var response = await _context.Products.ToListAsync();
				return new ApiResponse<IEnumerable<Product>>(response,"Data fetched successfully");
			}
		}
	}

}
