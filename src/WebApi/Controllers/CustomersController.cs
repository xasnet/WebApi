using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess.Interfaces.Repositories;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public CustomersController(ICustomerRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    [HttpGet("{id:long}", Name = "GetCustomerByIdAsync")]
    public async Task<ActionResult<CustomerReadDto>> GetCustomerByIdAsync([FromRoute] long id)
    {
        var customer = await _repository.GetCustomerByIdAsync(id);

        if (customer != null)
        {
            return Ok(_mapper.Map<CustomerReadDto>(customer));
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<CustomerReadDto>> CreateCustomerAsync([FromBody] CustomerCreateDto customerCreateDto)
    {
        var customer = _mapper.Map<Customer>(customerCreateDto);
        await _repository.CreateCustomerAsync(customer);
        await _repository.SaveChangesAsync();

        var CustomerReadDto = _mapper.Map<CustomerReadDto>(customer);

        return CreatedAtRoute(nameof(GetCustomerByIdAsync), new { Id = CustomerReadDto.Id }, CustomerReadDto);
    }
}
