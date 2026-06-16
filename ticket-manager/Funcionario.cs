public class Funcionario
{
    ManejaQuestao maneja = new ManejaQuestao();
    static AppDbContext db = new AppDbContext();
    public int Id { get; set; }

    public string Nome { get; set; }
    public string Cpf { get; set; }
    public char Situacao { get; set; }

    public Funcionario() { }

    public Funcionario(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
    }

    public static Funcionario BuscarFuncionario(int id)
    {
        Funcionario funcionario = db.funcionarios.Find(id);
        return funcionario ;
    }

    public async Task CadastrarFuncionario(Funcionario funcionario)
    {
        try
        {
            db.funcionarios.Add(funcionario);
            await db.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            Console.WriteLine("Ouve um erro inesperado ao cadastrar o funcionário");
            throw;
        }
    }

    public void Editar(int id)
    {
        try
        {
            Funcionario funcionario = db.funcionarios.Find(id);

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
                    db.SaveChanges();
                    break;
                case 2:
                    funcionario.Nome = maneja.Resposta("Digite o novo CPF do funcionário:");
                    db.SaveChanges();
                    break;
                case 3:
                    funcionario.Situacao = Char.Parse(maneja.Resposta("Digite a nova situação do funcionário (A para ativo, I para inativo):"));
                    db.SaveChanges();
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