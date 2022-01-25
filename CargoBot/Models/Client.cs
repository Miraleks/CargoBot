using LinqToDB.Mapping;

namespace CargoBot.Models
{

    [Table(Name = "clients")]
    public class Client
    {
        
        [Column(Name = "id")]
        public int Id { get; set; }

        [PrimaryKey]
        [Column(Name = "client_code")]
        public int ClientCode { get; set; }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "e_mail")]
        public string Email { get; set; }

        [Column(Name = "phone")]
        public string Phone { get; set; }

        [Column(Name = "chat_id")]
        public int ChatId { get; set; }

        [Column(Name = "user_id")]
        public int UserId { get; set; }

        public Employee Employee { get; set; }

    }

}
