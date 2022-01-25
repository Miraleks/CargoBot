using System.Linq;
using Npgsql;
using Dapper;
using System.Collections.Generic;
using CargoBot.Data;
using CargoBot.Models;


namespace CargoBot.Repositories
{
    internal static class RepositoryDB
    {

        public static List<Shipment> GetShipments()
        {
            var query = @"select 
                        id, shipment_name, place, weight, value, price, client_id, date_recieve, date_issue, warehouse_id, cont_id, employee_id
                        from shipments";

            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                var list = connection.Query<Shipment>(query);
                return list.ToList();
            }

        }

        public static List<Client> GetClients()
        {
            var query = "select id, client_code, firstname, lastname, e_mail, phone, chat_id, user_id from clients";

            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                var list = connection.Query<Client>(query);
                return list.ToList();
            }

        }
        
        public static List<Container> GetContainers()
        {
            var query = @"select
                        id, number_cont, date_of_load, eta, sealine
                        from containers";

            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                var list = connection.Query<Container>(query);
                return list.ToList();
            }

        }
        
        public static List<Employee> GetEmployees()
        {
            var query = @"select
                        id, employee_name, employee_func 
                        from employees";

            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                var list = connection.Query<Employee>(query);
                return list.ToList();
            }

        }
        
        public static List<Payment> GetPayments()
        {
            var query = @"select
                        id, client_id, cash_reg, summa, date_rec 
                        from payments";

            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                var list = connection.Query<Payment>(query);
                return list.ToList();
            }

        }
        
        public static List<Warehouse> GetWarehouses()
        {
            var query = @"select
                        id, warehouse_name 
                        from warehouses";

            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                var list = connection.Query<Warehouse>(query);
                return list.ToList();
            }

        }



    }
}