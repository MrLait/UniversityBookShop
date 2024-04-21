using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Cqrs.Faculties.Commands.Create;
using UniversityBookShop.Application.Cqrs.Faculties.Commands.Update;
using UniversityBookShop.Application.Cqrs.Faculties.Queries.GetFaculties;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Api.Controllers
{
    [ApiController]
    [Route(ApiConstants.Routing.ApiController)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FacultyController : BaseController
    {
        /// <summary>
        /// Get all Faculties.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceResult<PaginatedList<FacultyDto>>>> GetAll([FromQuery] PaginationParams paginationParams)
        {
            var query = new GetAllFacultiesWithPaginationQuery(paginationParams);
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        /// <summary>
        /// Get faculty by id
        /// </summary>
        [AllowAnonymous]
        [HttpGet(ApiConstants.Routing.Faculty.FacultyId)]
        public async Task<ActionResult<FacultyDto>> GetByFacultyId(int facultyId)
        {
            var vm = await Mediator.Send(new GetFacultyByIdQuery(facultyId));

            return Ok(vm);
        }
        /// <summary>
        /// Get all faluties by university id.
        /// </summary>
        [AllowAnonymous]
        [HttpGet(ApiConstants.Routing.Faculty.UniversityId)]
        public async Task<ActionResult<PaginatedList<FacultyDto>>> GetByUniversityId(int universityId, [FromQuery] PaginationParams paginationParams)
        {
            var vm = await Mediator.Send(new GetFacultiesByUniversityIdQuery(paginationParams)
            {
                UniversityId = universityId,
            });

            return Ok(vm);
        }
        /// <summary>
        /// Create faculty.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<int>>> Create([FromBody] CreateFacultyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Update faculty.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<ServiceResult<Unit>>> Update(UpdateFacultyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Delete faculty by id.
        /// </summary>
        [HttpDelete(ApiConstants.Routing.Id)]
        public async Task<ActionResult<ServiceResult<Unit>>> Delete(int id)
        {
            var command = new DeleteFacultyCommand() { Id = id };
            return Ok(await Mediator.Send(command));
        }
    }
}