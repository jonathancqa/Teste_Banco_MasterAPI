using System;
using BancoAPI.Src.Contexts;
using System.Threading.Tasks;
using BancoAPI.Src.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq;

namespace BancoAPI.Src.Repository.Implements
{
    /// <summary>
    /// <para>Resumo: Classe responsável por implementar ITransferencia </para>
    /// <para>Criado por: Jonathan </para>
    /// <para>Versão: 1.0 </para>
    /// </summary>
    public class TransferenciaRepository : ITransferencia
    {
        #region Atributos

        private readonly BancoContexto _contexto;

        #endregion

        #region Construtores

        public TransferenciaRepository(BancoContexto contexto)
        {
            _contexto = contexto;
        }

        #endregion

        #region Métodos
        public async Task NovaTransferenciaPixAsync(Transferencia transferencia)
        {
            if (!ExistsChavePixOrigem(transferencia.ChavePixOrigem.ChavePix)) throw new Exception("Chave Pix de origem está incorreta!");
            if (!ExistsChavePixDestino(transferencia.ChavePixDestino.ChavePix)) throw new Exception("Chave Pix destino está incorreta!");
            await _contexto.Transferencias.AddAsync(
                new Transferencia
                {
                    ChavePixOrigem = transferencia.ChavePixOrigem,
                    ChavePixDestino = transferencia.ChavePixDestino,
                    Valor = transferencia.Valor,
                });
            await _contexto.SaveChangesAsync();
        }

        //Funções Auxiliares

        bool ExistsChavePixOrigem(string chavepix)
        {
            var auxiliar = _contexto.Clientes.FirstOrDefault(c => c.ChavePix == chavepix);
            return auxiliar != null;
        }

        bool ExistsChavePixDestino(string chavepix)
        {
            var auxiliar = _contexto.Clientes.FirstOrDefault(c => c.ChavePix == chavepix);
            return auxiliar != null;
        }

        #endregion
    }
}
