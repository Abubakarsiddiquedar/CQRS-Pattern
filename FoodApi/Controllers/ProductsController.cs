﻿
using AutoMapper;
using Food.Application.Features.Products.Commands;
using Food.Application.Features.Products.Queries;
using Food.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Food.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator _mediator;
		public ProductsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
		{
			var result = await _mediator.Send(new GetAllProductsQuery(), cancellationToken);
			return Ok(result);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductById(int id)
		{
			var result = await _mediator.Send(new GetProductByIdQuery { Id = id});
			return Ok(result);
		}
		[HttpPost("CreateProduct")]
		public async Task<IActionResult> AddProducts(CreateProductCommand createProduct,CancellationToken cancellationToken)
		{
			var result = await _mediator.Send(createProduct,cancellationToken);
			return Ok(result);
		}

		[HttpPut("UpdateProduct")]
		public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProduct, CancellationToken cancellationToken)
		{
			var result = await _mediator.Send(updateProduct, cancellationToken);
			return Ok(result);
		}
		[HttpDelete("DeleteProduct/Id")]
		public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
		{
			var result = await _mediator.Send(new DeleteProductCommand { Id = id}, cancellationToken);
			return Ok(result);
		}
	}
}
