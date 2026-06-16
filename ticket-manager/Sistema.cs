using DotNetEnv;
using Microsoft.Extensions.DependencyInjection;

class SistemaManejoTickets
{
    private readonly SistemaFuncionario sistemaFuncionario;
    private readonly SistemaTickets sistemaTickets;

    public SistemaManejoTickets(SistemaFuncionario _sistemaFuncionario, SistemaTickets _sistemaTickets)
    {
        sistemaFuncionario = _sistemaFuncionario;
        sistemaTickets = _sistemaTickets;
    }

    static void Main(string[] args)
    {
        string envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", ".env");
        envPath = Path.GetFullPath(envPath);

        if (!File.Exists(envPath))
        {
            Console.WriteLine($"Arquivo .env não encontrado em: {envPath}");
        }

        Env.Load(envPath);

        // Configurar o container de DI
        var services = new ServiceCollection();

        // Registrar DbContext
        services.AddDbContext<AppDbContext>();

        // Registrar Serviços
        services.AddScoped<ServicoFuncionario>();
        services.AddScoped<ServicoTicket>();

        // Registrar Sistemas
        services.AddScoped<SistemaFuncionario>();
        services.AddScoped<SistemaTickets>();

        // Registrar o sistema principal
        services.AddScoped<SistemaManejoTickets>();

        var serviceProvider = services.BuildServiceProvider();

        // Resolver a instância do sistema principal
        var sistema = serviceProvider.GetRequiredService<SistemaManejoTickets>();
        sistema.Executar();
    }

    public void Executar()
    {
        Boolean SysUp = true;

        while (SysUp)
        {
            Console.WriteLine("Bem Vindo ao Sistema de Gerenciamento de Tickets!");
            Console.WriteLine("Digite 1 para acessar o menu de funcionários");
            Console.WriteLine("Digite 2 para acessar o menu de tickets");
            Console.WriteLine("Digite 3 para acessar o menu de relatórios");
            Console.WriteLine("Digite 4 para sair do sistema");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    sistemaFuncionario.Sistema();
                    break;
                case 2:
                    sistemaTickets.Sistema();
                    break;
                case 3:
                    // MenuRelatorios.MenuRelatorios();
                    break;
                case 4:
                    SysUp = false;
                    Console.WriteLine("Saindo do sistema...");
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }
}