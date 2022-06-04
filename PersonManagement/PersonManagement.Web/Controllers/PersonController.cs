using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonManagement.Service.Abstractions;
using PersonManagement.Service.Models;
using PersonManagement.Web.Models.DTOs;
using PersonManagement.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }
        [Route("Add")]
        [HttpPost]
        public async Task AddAsync(CreatePersonRequest person)
        {
            await _service.AddAsync(person.Adapt<PersonServiceModel>());
        }

        [Route("update")]
        [HttpPut]
        public async Task UpdateAsync(UpdatePersonRequest person)
        {
            await _service.UpdateAsync(person.Adapt<PersonServiceModel>());
        }

        [HttpGet("{firstName}")]
        [Route("FirstName/{firstName}")]
        public async Task<List<PersonDTO>> GetByFirstNameAsync(string firstName)
        {
            return (await _service.GetByFirstNameAsync(firstName)).Adapt<List<PersonDTO>>();
        }

        [HttpGet("{lastName}")]
        [Route("LastName/{lastName}")]
        public async Task<List<PersonDTO>> GetByLastNameAsync(string lastName)
        {
            return (await _service.GetByLastNameAsync(lastName)).Adapt<List<PersonDTO>>();
        }

        [HttpGet("{personalNumber}")]
        [Route("PersonalNumber/{personalNumber}")]
        public async Task<PersonDTO> GetByPersonalNumberAsync(string personalNumber)
        {
            return (await _service.GetByPersonalNumberAsync(personalNumber)).Adapt<PersonDTO>();
        }
    }
}
