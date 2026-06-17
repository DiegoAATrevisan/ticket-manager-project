using Superpower;

class SistemaTickets
{

    private readonly ServicoTicket servico;
    public SistemaTickets(ServicoTicket servicoTicket)
    {
        servico = servicoTicket;
    }
    public void Sistema()
    {
        Boolean SysUp = true;
        ManejaQuestao maneja = new ManejaQuestao();
        while (SysUp)
        {
            Console.WriteLine("Selecione a operação:");
            Console.WriteLine("Digite 1 para cadastrar novo ticket");
            Console.WriteLine("Digite 2 para editar um ticket");
            Console.WriteLine("Para voltar digite 3");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarTicket();
                    break;
                case 2:
                    EditarTicket();
                    break;
                case 3:
                    SysUp = false;
                    Console.WriteLine("Saindo do sistema...");
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }

        void CadastrarTicket()
        {
            int idFuncionario = int.Parse(maneja.Resposta("Digite o id do funcionário responsável pelo ticket:"));
            int quantidade = int.Parse(maneja.Resposta("Digite a quantidade de tickets:"));

            Ticket ticket = new Ticket(idFuncionario, quantidade);
            try
            {
                servico.CadastrarTicket(ticket);
                Console.WriteLine($"Ticket cadastrado com sucesso para o funcionário {idFuncionario}!");
            }
            catch (System.Exception)
            {
                Console.WriteLine("Aconteceu um erro inesperado favor tente novamente. SistemaTickets");

                throw;
            }
        }

        void EditarTicket()
        {
            int id = int.Parse(maneja.Resposta("Insira o id do ticket:"));
            Ticket ticket = servico.BuscarTicket(id);
            if (ticket != null)
            {
                servico.Editar(id);
            }
            else
            {
                Console.WriteLine("Ticket não encontrado.");
            }
        }

        
    }
}
