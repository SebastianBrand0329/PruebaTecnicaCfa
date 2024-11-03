using Cfa.Clientes.Application.DataBase.Clientes.Commands.CrearCliente;
using Cfa.Clientes.Application.DataBase.Clientes.Commands.DeleteClient;
using Cfa.Clientes.Application.DataBase.Clientes.Commands.UpdateCliente;
using Cfa.Clientes.Application.DataBase.Clientes.Queries.GetAllClientFilter;
using Cfa.Clientes.Application.Exceptions;
using Cfa.Clientes.Application.Features;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cfa.Clientes.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[TypeFilter(typeof(ExceptionManager))]
public class ClientesController : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateClientModel model, [FromServices] ICreateClientCommand createClient, [FromServices] IValidator<CreateClientModel> validator)
    {
        var validate = await validator.ValidateAsync(model);

        if (!validate.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

        var data = await createClient.Execute(model);

        return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateClientModel model, [FromServices] IUpdateClientCommand updateClient, [FromServices] IValidator<UpdateClientModel> validator)
    {

        var validate = await validator.ValidateAsync(model);

        if(!validate.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

        var data = await updateClient.Execute(model);

        return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteClientModel model, [FromServices] IDeleteClientModel deleteClient, [FromServices] IValidator<DeleteClientModel> validator)
    {

        var validate = await validator.ValidateAsync(model);

        if (!validate.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

        var data = await deleteClient.Execute(model);

        return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
    }

    [HttpGet("getbyfilter")]
    public async Task<IActionResult> Delete([FromBody] string search, [FromServices] IGetAllClientFilterQuery filterQuery)
    {

        var data = await filterQuery.Execute(search);

        if (data == null || data.Count == 0)
            return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
    }
}