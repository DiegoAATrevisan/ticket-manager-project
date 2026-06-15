using DotNetEnv;
Env.Load();
class Sistema
{
    static void Main(string[] args)
    {
        SistemaFuncionario sistemaFuncionario = new SistemaFuncionario();

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
                    // MenuTickets.MenuTickets();
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