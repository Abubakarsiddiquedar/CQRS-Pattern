using Food.Application.Exceptions;
using Food.Application.Interface;
using Food.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Application.Features.Products.Commands
{
	public class DeleteProductCommand : IRequest<ApiResponse<int>>
	{
		public int Id { get; set; }	

		internal class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ApiResponse<int>>
		{
			private readonly IApplicationDbContext _context;

			public DeleteProductHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<ApiResponse<int>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
			{
				var product = _context.Products.Where(x => x.Id == request.Id).FirstOrDefault();
				if (product == null)
				{
					throw new ApiException("product not found");
				}
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
				return new ApiResponse<int>(product.Id, "Deleted successfully"); ;
				
			}
		}
	}
}
