using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Models
{
    public class ProdutoVendaModel
    {
        public int id { get; set; }
        public int id_produto { get; set; }

        [ForeignKey("id_produto")]
        public ProdutoModel Produto { get; set; }
        public int id_venda { get; set; }

        [ForeignKey("id_venda")]
        public VendaModel Venda { get; set; }
        public string? quantidade { get; set; }
    }
}
