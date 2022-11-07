using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BancoAPI.Src.Models
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por representar tb_transferencia no banco.</para>
    /// <para>Criado por: Jonathan</para>
    /// <para>Versão: 1.0</para>
    /// </summary>
    [Table("tb_transferencia")]
    public class Transferencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("fk_ChavePix")]
        public Cliente ChavePixOrigem { get; set; }
        
        public Cliente ChavePixDestino { get; set; }

        public decimal Valor { get; set; }
    }
}
