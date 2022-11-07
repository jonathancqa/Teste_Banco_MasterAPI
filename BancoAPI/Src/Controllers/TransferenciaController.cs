using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BancoAPI.Src.Models;
using BancoAPI.Src.Repository;

namespace BancoAPI.Src.Controllers
{
    [ApiController]
    [Route("api/Transferencias")]
    [Produces("application/json")]
    public class TransferenciaController : ControllerBase
    {
        #region Atributos

        private readonly ITransferencia _repositorio;

        #endregion

        #region Construtores

        public TransferenciaController(ITransferencia repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Realiza uma transação entre 2 clientes cadastrados.
        /// </summary>
        /// <param name="transferencia"></param>
        /// <returns></returns>
        /// <response code="201">Transferencia Pix realizada.</response>
        /// <response code="400">Chave Pix Origem ou Destino incorreta.</response>
        [HttpPost("TransferirPix")]
        public async Task<ActionResult> NovaTransferenciaPixAsync([FromBody] Transferencia transferencia)
        {
            try 
            {
                await _repositorio.NovaTransferenciaPixAsync(transferencia);
                return Created($"api/Transferencias/TransferirPix", transferencia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
