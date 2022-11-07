using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BancoAPI.Src.Models
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por representar tb_clientes no banco.</para>
    /// <para>Criado por: Jonathan</para>
    /// <para>Versão: 1.0</para>
    /// </summary>
    [Table("tb_clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Documento { get; set; }

        [InverseProperty("ChavePixOrigem")]
        public string ChavePix { get; set; }

    }
}
