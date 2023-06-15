using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Models
{
    public class VendaModel
    {
        public int id { get; set; }

        public int id_cliente { get; set; }

        [ForeignKey("id_cliente")]
        public ClienteModel Cliente { get; set; }
        
        public DateTime data_venda { get; set; } = DateTime.Now;
        public string? precototal_venda { get; set; }
        public string? metodo_pagamento { get; set; }
    }
}