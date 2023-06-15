using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Models
{
    public class NFeModel
    {
        public int id { get; set; }
        public int id_distribuidora { get; set; }

        [ForeignKey("id_distribuidora")]
        public DistribuidoraModel Distribuidora { get; set; }
        public int num_nfe { get; set; }
        public string? total_icms { get; set; }
        public string? total_ipi { get; set; }
        public string? total_pis { get; set; }
        public string? total_cofins { get; set; }
        public string? total_iss { get; set; }
        public int valortotal_nfe { get; set; }


    }
}
