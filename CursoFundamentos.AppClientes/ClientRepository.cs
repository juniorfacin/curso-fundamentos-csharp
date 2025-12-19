namespace CursoFundamentos.AppClientes
{
    public class ClientRepository
    {
        public List<Client> clients = new List<Client>();

        public void RegisterClient()
        {
            Console.Clear();

            Console.Write("Nome do cliente: ");
            var name = Console.ReadLine();

            Console.Write("Data de Nascimento: ");
            var birthday = Console.ReadLine();

            Console.Write("Desconto: ");
            var discount = Console.ReadLine();
         
            var client = new Client
            {
                Id = clients.Count + 1,
                Name = name,
                Birthday = DateOnly.Parse(birthday),
                Discount = decimal.Parse(discount)
            };

            clients.Add(client);
            Console.WriteLine("\nCliente cadastrado com sucesso!\n");
            DisplayClient(client);
            Console.ReadKey();
        }

        public void ShowAllClients()
        {
            Console.Clear();
            foreach (var client in clients)
            {
                DisplayClient(client);
            }
            Console.ReadKey();
        }

        public void EditClient()
        {
            Console.Clear();
            Console.Write("Informe o ID do cliente a ser editado: ");
            var id = int.Parse(Console.ReadLine());
            var client = clients.FirstOrDefault(c => c.Id == id);
            
            if (client == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                Console.ReadKey();
                return;
            }
            Console.Write("Novo nome do cliente (deixe em branco para manter o atual): ");
            var name = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(name))
            {
                client.Name = name;
            }
            Console.Write("Nova data de nascimento (deixe em branco para manter a atual): ");
            var birthday = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(birthday))
            {
                client.Birthday = DateOnly.Parse(birthday);
            }
            Console.Write("Novo desconto (deixe em branco para manter o atual): ");
            var discount = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(discount))
            {
                client.Discount = decimal.Parse(discount);
            }
            Console.WriteLine("\nCliente atualizado com sucesso!\n");
            DisplayClient(client);
            Console.ReadKey();
        }

        public void DeleteClient()
        {
            Console.Clear();
            Console.Write("Informe o ID do cliente a ser excluído: ");
            var id = int.Parse(Console.ReadLine());
            var client = clients.FirstOrDefault(c => c.Id == id);
            
            if (client == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                Console.ReadKey();
                return;
            }

            clients.Remove(client);

            Console.WriteLine("-------------------------------------------"); 
            Console.WriteLine("Cliente excluído com sucesso!");
            Console.ReadKey();
        }

        public void DisplayClient(Client client)
        {
            Console.WriteLine($"ID: {client.Id}");
            Console.WriteLine($"Nome: {client.Name}");
            Console.WriteLine($"Data de Nascimento: {client.Birthday}");
            Console.WriteLine($"Data de Registro: {client.RegistrationDate}");
            Console.WriteLine($"Desconto: R$ {client.Discount}");
            Console.WriteLine("------------------------------------------");
        }

        public void SaveClientsToFile()
        {
            var json = System.Text.Json.JsonSerializer.Serialize(clients);

            File.WriteAllText("clientes.txt", json);
        }

        public void ReadFileClients()
        {
            if (File.Exists("clientes.txt"))
            {
                var datas = File.ReadAllText("clientes.txt");

                var fileClients = System.Text.Json.JsonSerializer.Deserialize<List<Client>>(datas);

                clients.AddRange(fileClients);
            }
        }
    }
}
