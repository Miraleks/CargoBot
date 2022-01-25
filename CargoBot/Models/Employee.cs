using LinqToDB.Mapping;
using System.Collections.Generic;

namespace CargoBot.Models
{

    [Table(Name = "employees")]
    public class Employee
    {
        [PrimaryKey]
        [Column(Name = "id")]
        public int id { get; set; }

        [Column(Name = "employee_name")]
        public string name { get; set; }

        [Column(Name = "employee_func")]
        public string func { get; set; }

        public List<Client> Clients { get; set; }


    }

}
