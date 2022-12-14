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

    [HttpGet("{id:long}", Name = "GetCustomerById")]
    public async Task<ActionResult<CustomerReadDto>> GetCustomerById([FromRoute] long id)
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
        if (await _repository.GetCustomerByIdAsync(customerCreateDto.Id) != null)
        {
            return Conflict();
        }

        var customer = _mapper.Map<Customer>(customerCreateDto);
        await _repository.CreateCustomerAsync(customer);
        await _repository.SaveChangesAsync();

        var CustomerReadDto = _mapper.Map<CustomerReadDto>(customer);

        return Ok(CustomerReadDto);
    }
}
