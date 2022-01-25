using LinqToDB.Mapping;
using System.Collections.Generic;

namespace CargoBot.Models
{

    [Table(Name = "containers")]
    public class Container
    {
        [PrimaryKey]
        [Column(Name = "id")]
        public int id { get; set; }

        [Column(Name = "number_cont")]
        public int Numb { get; set; }

        [Column(Name = "date_of_load")]
        public System.DateTime DateOfLoad { get; set; }

        [Column(Name = "eta")]
        public System.DateTime Eta { get; set; }

        [Column(Name = "sealine")]
        public string SeaLine { get; set; }

        public List<Shipment> Shipments { get; set; }
    }
}