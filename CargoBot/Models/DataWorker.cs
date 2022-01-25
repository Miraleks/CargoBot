using System.Linq;
using Npgsql;
using Dapper;
using System.Collections.Generic;
using CargoBot.Data;
using CargoBot.Repositories;

namespace CargoBot.Models
{
    public static class DataWorker
    {
        // Создать клиента

        public static List<Shipment> shipments = Repositories.RepositoryDB.GetShipments();
        public static List<Client> clients = Repositories.RepositoryDB.GetClients();
        public static List<Container> containers = Repositories.RepositoryDB.GetContainers();
        public static List<Employee> employees = Repositories.RepositoryDB.GetEmployees();
        public static List<Payment> payments = Repositories.RepositoryDB.GetPayments();
        public static List<Warehouse> warehouses = Repositories.RepositoryDB.GetWarehouses();


        public static string CreateClient(int Client_code, string Firstname, string Lastname, string E_mail, string Phone, int User_id)
        {
            string result = "Уже существует";

            var queryInsert = @"insert into clients (client_code, firstname, lastname, e_mail, phone, user_id)
                        values (@client_code, @firstname, @lastname, @e_mail, @phone, @user_id)";


            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                bool checkIsExist = clients.Any(el => el.ClientCode == Client_code);
                if (!checkIsExist)
                {
                    var list = connection.Execute(queryInsert, new { 
                        client_code = Client_code, 
                        firstname = Firstname, 
                        lastname = Lastname, 
                        e_mail = E_mail, 
                        phone = Phone, 
                        user_id = User_id });
                    result = "Сделано!";
                }
                return result;
            }

        }

        // Создать груз
        public static string CreateShipment(int Client_code, string Name, int Place, double Weight, double Value, decimal Price, int WarehouseId, System.DateTime DateRecieve, System.DateTime DateIssue, int ContId, int EmployeeId)
        {
            string result = "Уже существует";
            /*from x in names
                                where x.Length > 3
                                select x;*/
            var clientId = (from x in clients
                            where x.ClientCode == Client_code
                            select x.Id).FirstOrDefault();

            if (clientId == 0)
            {
                return "Такого клиента нет в базе данных!";
            }
            

            var queryInsert = @"insert into shipments (client_id, name, place, weight, value, price, warehouse_id, date_recieve, date_issue, cont_id, employee_id)
                        values (@client_id, @name, @place, @weight, @value, @price, @warehouse_id, @date_recieve, @date_issue, @cont_id, @employee_id)";


            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                bool checkIsExist = shipments.Any(el => el.Name == Name && el.Place == Place && el.Weight == Weight && el.Value == Value);
                if (!checkIsExist)
                {
                    var list = connection.Execute(queryInsert, new { 
                        client_id = clientId, 
                        name = Name, 
                        place = Place, 
                        weight = Weight, 
                        value = Value, 
                        price = Price, 
                        warehouse_id = WarehouseId, 
                        date_recieve = DateRecieve, 
                        date_issue = DateIssue, 
                        cont_id = ContId, 
                        employee_id = EmployeeId });
                    result = "Сделано!";
                }
                return result;
            }

        }

        // Создать платеж
        public static string CreatePayments(string Client_code, string CashReg, decimal Sum, System.DateTime DateRec)
        {
            

            var queryInsert = @"insert into payments (client_code, cash_reg, summa, date_rec)
                        values (@client_code, @cash_reg, @summa, @date_rec)";


            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                
                var list = connection.Execute(queryInsert, new {
                    client_code = Client_code,
                    cash_reg = CashReg,
                    summa = Sum,
                    date_rec = DateRec
                });
                
            }
            return "Сделано!";
        }


        // Удалить груз
        public static string DeleteShipment(Shipment shipment)
        {
            string result = "Груз не найден";
            var query = @"delete from shipments where id = @Id";

            bool checkIsExist = shipments.Any(el => el.Id == shipment.Id);

            if (checkIsExist)
            {

                using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
                {
                    var list = connection.Execute(query, new
                    {
                        id = shipment.Id
                    });
                }
                result = "Груз код клиента: " + shipment.ClientCode + ", наименование: " + shipment.Name + " удален";
            }
            return result;

        }

        // Удалить клиента

        // Удалить платеж

        // Редактировать клиента

        // Редактировать груз

        public static string EditShipment(Shipment oldShipment, int newClient_code, string newName, int newPlace, double newWeight, double newValue, decimal newPrice, int newWarehouseId, System.DateTime newDateRecieve, System.DateTime newDateIssue, int newContId, int newEmployeeId)
        {
            string result = "Груз не найден";
            var query = @"update shipments set client_code = @client_code, name = @name, place = @place, weight = @weight, value = @value, price = @price, warehouse = @warehouse, date_recieve = @date_recieve, date_issue = @date_issue, cont_id = @cont_id, employee_id = @employee_id  where id = @Id";

            bool checkIsExist = shipments.Any(el => el.Id == oldShipment.Id);

            if (checkIsExist)
            {

                using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
                {
                    var list = connection.Execute(query, new
                    {
                        id = oldShipment.Id,
                        client_code = newClient_code,
                        name = newName,
                        place = newPlace,
                        weight = newWeight,
                        value = newValue,
                        price = newPrice,
                        warehouse = newWarehouseId,
                        date_recieve = newDateRecieve,
                        date_issue = newDateIssue,
                        cont_id = newContId,
                        employee_id = newEmployeeId
                    });
                }
                result = "Груз код клиента: " + oldShipment.ClientCode + ", наименование: " + oldShipment.Name + " обновлен";
            }
            return result;

        }

        // Редактировать платеж



    }
}
