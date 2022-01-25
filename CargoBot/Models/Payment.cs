using LinqToDB.Mapping;

namespace CargoBot.Models
{

    [Table(Name = "payments")]
    public class Payment
    {
        [PrimaryKey]
        [Column(Name = "id")]
        public int id { get; set; }

        [Column(Name = "client_id")]
        public string ClientCode { get; set; }

        [Column(Name = "cash_reg")]
        public string CashReg { get; set; }

        [Column(Name = "summa")]
        public decimal Sum { get; set; }

        [Column(Name = "date_rec")]
        public System.DateTime DateRec { get; set; }

    }

}

