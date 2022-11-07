using BancoAPI.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI.Src.Contexts
{
    /// <summary>
    /// <para>Resumo: Classe contexto, responsável por carregar contexto e definir DBSets </para>
    /// <para>Criado por: Jonathan</para>
    /// <para>Versão: 1.0</para>
    /// </summary>
    public class BancoContexto : DbContext
    {
        #region Atributos

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }

        #endregion

        #region Construtores

        public BancoContexto(DbContextOptions<BancoContexto> options) : base (options)
        {
        }

        #endregion
    }
}
