using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BancoAPI.Src.Models;
using BancoAPI.Src.Repository;

namespace BancoAPI.Src.Controllers
{
    [ApiController]
    [Route("api/Clientes")]
    [Produces("application/json")]
    public class ClienteController : ControllerBase
    {
        #region Atributos

        private readonly ICliente _repositorio;

        #endregion

        #region Construtores

        public ClienteController(ICliente repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Cadastrar um novo Cliente
        /// </summary>
        /// <param name="cliente">Construtor para cadastrar um cliente</param>
        /// <returns>ActionResult</returns>
        /// <para>
        /// POST /api/Clientes/CadastrarCliente
        /// {
        ///  "nome": "Nome Sobrenome"
        ///  "documento": "123456789"
        ///  "chavepix": "chavepix@mail.com"
        /// }
        /// </para>
        /// <response code="201">Cliente Cadastrado.</response>
        /// <response code="401">Cliente não foi cadastrado.</response>
        [HttpPost("CadastrarCliente")]
        public async Task<ActionResult> NovoClienteAsync([FromBody] Cliente cliente)
        {
            try
            {
                await _repositorio.NovoClienteAsync(cliente);
                return Created($"api/Clientes/{cliente.Documento}", cliente);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        /// <summary>
        /// Consultar Clientes
        /// </summary>
        /// <param name="documentoCliente">Construtor para consultar um cliente pelo documento</param>
        /// <returns>ActionResult</returns>
        [HttpGet("ConsultarCliente/{documentoCliente}")]
        public async Task<ActionResult> ConsultarClientesAsync([FromRoute] string documentoCliente)
        {
            var cliente = await _repositorio.ConsultarClientesAsync(documentoCliente);

            if (cliente == null) return NotFound(new
            {
                Message = "Cliente não encontrado!"
            }); return Ok(cliente);
        }

        #endregion
    }
}
