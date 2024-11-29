using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CCLoungeConsole
{
    class Program
    {
        private static string connectionString = "Server=localhost;Database=cclounge;Uid=root;Pwd=1501;";

        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando o sistema...");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Visualizar dados");
                Console.WriteLine("2. Adicionar dados");
                Console.WriteLine("3. Atualizar dados");
                Console.WriteLine("4. Apagar dados");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewData();
                        break;
                    case "2":
                        AddData();
                        break;
                    case "3":
                        UpdateData();
                        break;
                    case "4":
                        DeleteData();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        private static void ViewData()
        {
            Console.WriteLine("\nTabelas:");
            Console.WriteLine("1. cabine");
            Console.WriteLine("2. cliente");
            Console.WriteLine("3. endereço");
            Console.WriteLine("4. estoque");
            Console.WriteLine("5. fornecedor");
            Console.WriteLine("6. funcionários");
            Console.WriteLine("7. gerente");
            Console.WriteLine("8. mercadoria");
            Console.WriteLine("9. agendamentos");
            Console.Write("Escolha uma tabela para visualizar: ");
            string tableChoice = Console.ReadLine();

            string tableName = GetTableName(tableChoice);
            if (!string.IsNullOrEmpty(tableName))
            {
                LoadTable(tableName);
            }
            else
            {
                Console.WriteLine("Tabela inválida.");
            }
        }

        private static void AddData()
        {
            Console.WriteLine("\nTabelas:");
            Console.WriteLine("1. cabine");
            Console.WriteLine("2. cliente");
            Console.WriteLine("3. endereço");
            Console.WriteLine("4. estoque");
            Console.WriteLine("5. fornecedor");
            Console.WriteLine("6. funcionários");
            Console.WriteLine("7. gerente");
            Console.WriteLine("8. mercadoria");
            Console.WriteLine("9. agendamentos");
            Console.Write("Escolha uma tabela para adicionar dados: ");
            string tableChoice = Console.ReadLine();

            string tableName = GetTableName(tableChoice);
            if (!string.IsNullOrEmpty(tableName))
            {
                AddTableData(tableName);
            }
            else
            {
                Console.WriteLine("Tabela inválida.");
            }
        }

        private static void UpdateData()
        {
            Console.WriteLine("\nTabelas:");
            Console.WriteLine("1. cabine");
            Console.WriteLine("2. cliente");
            Console.WriteLine("3. endereço");
            Console.WriteLine("4. estoque");
            Console.WriteLine("5. fornecedor");
            Console.WriteLine("6. funcionários");
            Console.WriteLine("7. gerente");
            Console.WriteLine("8. mercadoria");
            Console.WriteLine("9. agendamentos");
            Console.Write("Escolha uma tabela para atualizar dados: ");
            string tableChoice = Console.ReadLine();

            string tableName = GetTableName(tableChoice);
            if (!string.IsNullOrEmpty(tableName))
            {
                UpdateTableData(tableName);
            }
            else
            {
                Console.WriteLine("Tabela inválida.");
            }
        }

        private static void DeleteData()
        {
            Console.WriteLine("\nTabelas:");
            Console.WriteLine("1. cabine");
            Console.WriteLine("2. cliente");
            Console.WriteLine("3. endereço");
            Console.WriteLine("4. estoque");
            Console.WriteLine("5. fornecedor");
            Console.WriteLine("6. funcionários");
            Console.WriteLine("7. gerente");
            Console.WriteLine("8. mercadoria");
            Console.WriteLine("9. agendamentos");
            Console.Write("Escolha uma tabela para apagar dados: ");
            string tableChoice = Console.ReadLine();

            string tableName = GetTableName(tableChoice);
            if (!string.IsNullOrEmpty(tableName))
            {
                DeleteTableData(tableName);
            }
            else
            {
                Console.WriteLine("Tabela inválida.");
            }
        }

        private static string GetTableName(string choice)
        {
            switch (choice)
            {
                case "1": return "cabine";
                case "2": return "cliente";
                case "3": return "endereço";
                case "4": return "estoque";
                case "5": return "fornecedor";
                case "6": return "funcionários";
                case "7": return "gerente";
                case "8": return "mercadoria";
                case "9": return "agendamentos";
                default: return null;
            }
        }

        private static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        private static void LoadTable(string tableName)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var query = $"SELECT * FROM {tableName}";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    Console.WriteLine($"\n{tableName.ToUpper()}:");
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            Console.Write(item + "\t");
                        }
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar {tableName}: " + ex.Message);
            }
        }

        private static void AddTableData(string tableName)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    if (tableName == "cabine")
                    {
                        Console.Write("Tipo: ");
                        string tipo = Console.ReadLine();
                        Console.Write("Preço: ");
                        decimal preco = decimal.Parse(Console.ReadLine());
                        Console.Write("Ocupação: ");
                        string ocupacao = Console.ReadLine();

                        var query = $"INSERT INTO {tableName} (tipo, preço, ocupação) VALUES (@tipo, @preco, @ocupacao)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@tipo", tipo);
                        cmd.Parameters.AddWithValue("@preco", preco);
                        cmd.Parameters.AddWithValue("@ocupacao", ocupacao);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Dados adicionados com sucesso.");
                    }
                  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar dados em {tableName}: " + ex.Message);
            }
        }

        private static void UpdateTableData(string tableName)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    if (tableName == "cabine")
                    {
                        Console.Write("ID da Cabine a ser atualizada: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Novo Tipo: ");
                        string tipo = Console.ReadLine();
                        Console.Write("Novo Preço: ");
                        decimal preco = decimal.Parse(Console.ReadLine());
                        Console.Write("Nova Ocupação: ");
                        string ocupacao = Console.ReadLine();

                        var query = $"UPDATE {tableName} SET tipo=@tipo, preço=@preco, ocupação=@ocupacao WHERE idcabine=@id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@tipo", tipo);
                        cmd.Parameters.AddWithValue("@preco", preco);
                        cmd.Parameters.AddWithValue("@ocupacao", ocupacao);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Dados atualizados com sucesso.");
                    }
              
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar dados em {tableName}: " + ex.Message);
            }
        }

        private static void DeleteTableData(string tableName)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    if (tableName == "cabine")
                    {
                        Console.Write("ID da Cabine a ser apagada: ");
                        int id = int.Parse(Console.ReadLine());

                        var query = $"DELETE FROM {tableName} WHERE idcabine=@id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Dados apagados com sucesso.");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao apagar dados em {tableName}: " + ex.Message);
            }
        }
    }
}
