using Microsoft.AspNetCore.Mvc;
using DomainDrivenDesign_Poc.Business.ApplicationService.Commands.StudentsCommands;
using DomainDrivenDesign_Poc.Business.ApplicationService.DTOs;
using DomainDrivenDesign_Poc.Business.ApplicationService.Query.StudentQuery;
using DomainDrivenDesign_Poc.Shared.Handlers;
using DomainDrivenDesign_Poc.Shared.Result;

namespace DomainDrivenDesign_Poc.Controllers;

public sealed class StudentController(
    ICommandHandler<CreateStudentCommand> createStudentHandler,
    IQueryHandler<FindStudentByNameQuery, StudentResponseByName> findStudentByName
) : ControllerBase
{
    [HttpPost("create_student")]
    public async Task<CommandResult> Register([FromBody] CreateStudentCommand command) =>
        await createStudentHandler.HandleAsync(command);

    [HttpGet("get_student_by_name")]
    public async Task<QueryResult<StudentResponseByName>> FindStudentByName([FromQuery] FindStudentByNameQuery query) =>
        await findStudentByName.HandleAsync(query);
}