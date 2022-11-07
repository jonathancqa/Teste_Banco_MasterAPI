using BancoAPI.Src.Models;
using System.Threading.Tasks;

namespace BancoAPI.Src.Repository
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de Transferencia entre Clientes </para>
    /// <para>Criado por: Jonathan </para>
    /// <para>Versão: 1.0 </para>
    /// </summary>
    public interface ITransferencia
    {
        Task NovaTransferenciaPixAsync(Transferencia transferencia);
    }
}
