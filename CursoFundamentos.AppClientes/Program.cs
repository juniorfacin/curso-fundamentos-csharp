using System.Globalization;

namespace CursoFundamentos.AppClientes
{
    internal class Program
    {
        static ClientRepository _clientRepository = new ClientRepository();

        static void Main(string[] args)
        {
            var culture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            _clientRepository.ReadFileClients();

            while (true)
            {
                Menu();

                Console.ReadKey();
            }
        }

        static void Menu()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Clientes");
            Console.WriteLine("--------------------");
            Console.WriteLine("1 - Cadastrar Cliente");
            Console.WriteLine("2 - Exibir Clientes");
            Console.WriteLine("3 - Editar Cliente");
            Console.WriteLine("4 - Excluir Cliente");
            Console.WriteLine("5 - Verificar clientes cadastrados");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("--------------------");

            HandleMenuOption();
        }

        private static void HandleMenuOption()
        {
            Console.Write("Selecione uma opção: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    _clientRepository.RegisterClient();
                    Menu();
                    break;
                case "2":
                    _clientRepository.ShowAllClients();
                    Menu();
                    break;
                case "3":
                    _clientRepository.EditClient();
                    Menu();
                    break;
                case "4":
                    _clientRepository.DeleteClient();
                    Menu();
                    break;
                case "5":
                    _clientRepository.ReadFileClients();
                    Environment.Exit(0);
                    break;
                case "6":
                    _clientRepository.SaveClientsToFile();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
