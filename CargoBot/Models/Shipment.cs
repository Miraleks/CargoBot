using LinqToDB.Mapping;

namespace CargoBot.Models
{

    [Table(Name = "shipments")]
    public class Shipment
    {
        [PrimaryKey]
        [Column(Name = "id")]
        public int Id { get; set; }

		[Column(Name = "shipment_name")]
        public string Name { get; set; }
		
		[Column(Name = "place")]
		public int Place { get; set; }

		[Column(Name = "weight")]
		public double Weight { get; set; }

		[Column(Name = "value")]
		public double Value { get; set; }

		[Column(Name = "price")]
		public decimal Price { get; set; }

		[Column(Name = "client_id")]
		public int ClientCode { get; set; }

		[Column(Name = "warehouse_id")]
		public int WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }

        [Column(Name = "date_recieve")]
		public System.DateTime DateRecieve { get; set; }

		[Column(Name = "date_issue")]
		public System.DateTime DateIssue { get; set; }

		[Column(Name = "cont_id")]
		public int ContId { get; set; }

        public Container Container { get; set; }

        [Column(Name = "employee_id")]
		public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

    }

}
