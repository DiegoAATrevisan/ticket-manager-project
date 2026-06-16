using Superpower;

class SistemaTickets
{
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
    }
}
