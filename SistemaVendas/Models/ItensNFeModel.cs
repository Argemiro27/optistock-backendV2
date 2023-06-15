using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Models
{
    public class ItensNFeModel
    {
        public int id { get; set; }
        public int id_produto { get; set; }

        [ForeignKey("id_produto")]
        public ProdutoModel Produto { get; set; }

        public int id_nfe { get; set; }

        [ForeignKey("id_nfe")]
        public NFeModel NFe { get; set; }
        public string? quantidade { get; set; }
        public string? valor_unit { get; set; }
        public string? valor_total_produto { get; set; }


        public string? icms { get; set; }
        public string? ipi { get; set; }
        public string? pis { get; set; }
        public string? cofins { get; set; }
        public string? iss { get; set; }


        public string? total_icms_produto { get; set; }
        public string? total_ipi_produto { get; set; }
        public string? total_pis_produto { get; set; }
        public string? total_cofins_produto { get; set; }
        public string? total_iss_produto { get; set; }
    }
}
