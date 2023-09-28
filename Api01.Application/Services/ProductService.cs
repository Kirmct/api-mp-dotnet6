using Api01.Application.DTOs;
using Api01.Application.DTOs.Validations;
using Api01.Application.Services.Interfaces;
using Api01.Domain.Entities;
using Api01.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api01.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO)
    {
        if (productDTO == null)
        {
            return ResultService.Fail<ProductDTO>("Objeto deve ser informado");
        }
        var result = new ProductDTOValidator().Validate(productDTO);

        if (!result.IsValid)
        {
            return ResultService.RequestError<ProductDTO>("Problemas na validação", result);
        }

        var product = _mapper.Map<Product>(productDTO);
        var data = await _productRepository.CreateAsync(product);

        return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(data));
    }

    public Task<ResultService<ICollection<ProductDTO>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResultService<ProductDTO>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
