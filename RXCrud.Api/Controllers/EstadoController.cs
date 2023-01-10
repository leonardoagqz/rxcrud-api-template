using System;
using System.Linq;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using RXCrud.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace RXCrud.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService _estadoService;

        public EstadoController(IEstadoService estadoService)
            => _estadoService = estadoService;

        /// <summary>
        /// Consulta
        /// </summary>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpGet]
        [EnableQuery()]
        [Authorize(Roles = "estado_visualizar")]
        [ProducesResponseType(typeof(IQueryable<EstadoDto>), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Get()
            => Ok(_estadoService.ObterTodos());

        /// <summary>
        /// Consulta por id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpGet("{id}")]
        [Authorize(Roles = "estado_visualizar")]
        [ProducesResponseType(typeof(EstadoDto), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult PorId(Guid id)
        {
            EstadoDto estado = _estadoService.PesquisarPorId(id);
            if (estado == null)
            {
                return NotFound();
            }

            return Ok(estado);
        }

        /// <summary>
        /// Criar.
        /// Caso seja passado um array com id’s dos perfis que o estado deve possuir os mesmos serão incluídos no estado criado.
        /// Caso não seja passado nada será feito.
        /// </summary>
        /// <param name="estado"></param>
        /// <response code="200">Criado com sucesso.</response>
        /// <response code="400">Não foi possível criar.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpPost]
        [Authorize(Roles = "estado_novo")]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Post(EstadoDto estado)
        {
            if (!ModelState.IsValid)
            {
                throw new RXCrudException("Os dados para criação são inválidos.");
            }

            _estadoService.Criar(estado);
            return Ok();
        }

        /// <summary>
        /// Atualizar.
        /// Caso seja passado um array com id’s dos perfis que o estado deve possuir, todos os perfis atuais serão removidos e os novos serão incluídos.
        /// Caso não seja passado nada será feito.
        /// </summary>
        /// <param name="estado"></param>
        /// <response code="200">Atualizado com sucesso.</response>
        /// <response code="400">Não foi possível atualizar.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpPut]
        [Authorize(Roles = "estado_editar")]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Put(EstadoDto estado)
        {
            if (!ModelState.IsValid)
            {
                throw new RXCrudException("Os dados para atualização são inválidos.");
            }

            if ((estado.Id.ToString().Equals("")) || (_estadoService.PesquisarPorId(estado.Id) == null))
            {
                return NotFound();
            }

            _estadoService.Atualizar(estado);
            return Ok();
        }

        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Exclusão realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a exclusão.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "estado_excluir")]
        [ProducesResponseType(typeof(EstadoDto), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Delete(Guid id)
        {
            EstadoDto estado = _estadoService.PesquisarPorId(id);
            if (estado == null)
            {
                return NotFound();
            }

            _estadoService.Remover(estado);
            return Ok();
        }
    }
}