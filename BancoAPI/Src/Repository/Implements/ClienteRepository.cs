using BancoAPI.Src.Contexts;
using BancoAPI.Src.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BancoAPI.Src.Repository.Implements
{
    /// <summary>
    /// <para>Resumo: Classe responsável por implementar ICliente </para>
    /// <para>Criado por: Jonathan </para>
    /// <para>Versão: 1.0 </para>
    /// </summary>
    public class ClienteRepository : ICliente
    {
        #region Atributos

        private readonly BancoContexto _contexto;

        #endregion

        #region Construtores

        public ClienteRepository(BancoContexto contexto)
        {
            _contexto = contexto;
        }

        #endregion

        #region Métodos

        public async Task<Cliente> ConsultarClientesAsync(string documento)
        {
            return await _contexto.Clientes.FirstOrDefaultAsync(x => x.Documento == documento);
        }

        public async Task NovoClienteAsync(Cliente cliente)
        {
            await _contexto.Clientes.AddAsync(
                new Cliente
                {
                    Nome = cliente.Nome,
                    Documento = cliente.Documento,
                    ChavePix = cliente.ChavePix,
                });
            await _contexto.SaveChangesAsync();
        }

        #endregion
    }
}
