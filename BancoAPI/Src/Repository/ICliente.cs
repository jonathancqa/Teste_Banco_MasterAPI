using BancoAPI.Src.Models;
using System.Threading.Tasks;

namespace BancoAPI.Src.Repository
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações do CRUD de Cliente</para>
    /// <para>Criado por: Jonathan </para>
    /// <para>Versão: 1.0 </para>
    /// </summary>
    public interface ICliente
    {
        Task NovoClienteAsync(Cliente cliente);

        Task<Cliente> ConsultarClientesAsync(string documento);
    }
}
