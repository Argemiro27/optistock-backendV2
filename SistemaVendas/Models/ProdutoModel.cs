using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Models
{
    public class ProdutoModel
    {
        public int id { get; set; }

        public int id_marca { get; set; }

        [ForeignKey("id_marca")]
        public MarcaModel Marca { get; set; }

        public string? cod_barras { get; set; }
        public string? nome_produto { get; set; }
        public string? preco_venda { get; set; }


    }
}
