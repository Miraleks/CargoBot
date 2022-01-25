using LinqToDB.Mapping;
using System.Collections.Generic;

namespace CargoBot.Models
{

    [Table(Name = "warehouses")]
    public class Warehouse
    {
        [PrimaryKey]
        [Column(Name = "id")]
        public int id { get; set; }

        [Column(Name = "warehouses_name")]
        public string name { get; set; }

        public List<Shipment> Shipments { get; set; }

    }

}
