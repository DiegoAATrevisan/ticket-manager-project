public class ServicoFuncionario
{
    ManejaQuestao maneja = new ManejaQuestao();
    private readonly AppDbContext _db;

    public ServicoFuncionario(AppDbContext db)
    {
        _db = db;
    }

    public Funcionario BuscarFuncionario(int id)
    {
        Funcionario funcionario = _db.funcionarios.Find(id);
        return funcionario;
    }

    public void CadastrarFuncionario(Funcionario funcionario)
    {
        try
        {
            funcionario.Nome = funcionario.Nome.Replace("\0", string.Empty);
            funcionario.Cpf = funcionario.Cpf.Replace("\0", string.Empty);
            _db.funcionarios.Add(funcionario);
            _db.SaveChanges();
        }
        catch (System.Exception)
        {
            Console.WriteLine("Houve um erro inesperado ao cadastrar o funcionário. ServicoFuncionario");
            throw;
        }
    }

    public void Editar(int id)
    {
        try
        {
            Funcionario funcionario = _db.funcionarios.Find(id);

            if (funcionario == null)
            {
                Console.WriteLine("Funcionário não encontrado");
                throw new Exception("Não foi possivel encontrar esse usuario na base de dados, verifique o ID forncido.");
            }

            Console.WriteLine($"Funcionário encontrado: {funcionario.Nome} - {funcionario.Cpf}");
            Console.WriteLine("Digite 1 para editar o nome do funcionário");
            Console.WriteLine("Digite 2 para editar o CPF do funcionário");
            Console.WriteLine("Digite 3 para editar a situação do funcionário");
            Console.WriteLine("Digite 4 para cancelar a edição");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    funcionario.Nome = maneja.Resposta("Digite o novo nome do funcionário:");
                    _db.SaveChanges();
                    break;
                case 2:
                    funcionario.Nome = maneja.Resposta("Digite o novo CPF do funcionário:");
                    _db.SaveChanges();
                    break;
                case 3:
                    funcionario.Situacao = Char.Parse(maneja.Resposta("Digite a nova situação do funcionário (A para ativo, I para inativo):"));
                    _db.SaveChanges();
                    break;
                case 4:
                    Console.WriteLine("Edição cancelada.");
                    break;
                default:
                    Console.WriteLine("Opção inválida, edição cancelada.");
                    break;
            }

        }
        catch (System.Exception)
        {
            Console.WriteLine("Ouve um erro inesperado ao editar o funcionário");
            throw;
        }
    }
}