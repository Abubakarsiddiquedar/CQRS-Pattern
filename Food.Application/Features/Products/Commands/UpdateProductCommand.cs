using Food.Application.Exceptions;
using Food.Application.Interface;
using Food.Application.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Application.Features.Products.Commands
{
	public class UpdateProductCommand : IRequest<ApiResponse<int>>
	{
		public int Id { get; set; }
		public string? Name { get; set; }	
		public string? Description { get; set; }

		public decimal Rate { get; set; }

		internal class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ApiResponse<int>>
		{
			private readonly IApplicationDbContext _context;

			public UpdateProductHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<ApiResponse<int>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
			{
				var product = await _context.Products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
				if (product == null)
				{
					throw new ApiException("product not found");
				}
					product.Name = request.Name;
					product.Description = request.Description;
					product.Rate = request.Rate;
					_context.Products.Update(product);
					await _context.SaveChangesAsync();
				return new ApiResponse<int>(product.Id, "Updated successfully");
				
			}
		}
	}
}
