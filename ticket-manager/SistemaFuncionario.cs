class SistemaFuncionario
{
    private readonly ServicoFuncionario servico;
    public SistemaFuncionario(ServicoFuncionario servicoFuncionario)
    {
        servico = servicoFuncionario;
    }
    public void Sistema()
    {

        Boolean SysUp = true;

        ManejaQuestao maneja = new ManejaQuestao();
        while (SysUp)
        {
            Console.WriteLine("Selecione a operação:");
            Console.WriteLine("Digite 1 para cadastrar novo funcionário");
            Console.WriteLine("Digite 2 para editar um funcionário");
            Console.WriteLine("Para voltar digite 3");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarFuncionario();
                    break;
                case 2:
                    EditarFuncionario();
                    break;
                case 3:
                    SysUp = false;
                    Console.WriteLine("Saindo do sistema...");
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }

            void CadastrarFuncionario()
            {
                string nome = maneja.Resposta("Digite o nome do funcionário:");
                string cpf = maneja.Resposta("Digite o CPF do funcionário:");

                Funcionario funcionario = new Funcionario(nome, cpf);

                try
                {
                    servico.CadastrarFuncionario(funcionario);
                    Console.WriteLine($"Funcionário {nome}, com o CPF {cpf} cadastrado com sucesso!");
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("Aconteceu um erro inesperado favor tente novamente. SistemaFuncionario");
                    Console.WriteLine("A mensagem de erro foi: " + ex.InnerException);
                    throw;
                }

            }

            void EditarFuncionario()
            {
                int id = int.Parse(maneja.Resposta("Insira o id do funcionário:"));
                Funcionario funcionario = servico.BuscarFuncionario(id);
                if (funcionario != null)
                {
                    servico.Editar(id);
                }
                else
                {
                    Console.WriteLine("Funcionário não encontrado.");
                }
            }

        }
    }

}
