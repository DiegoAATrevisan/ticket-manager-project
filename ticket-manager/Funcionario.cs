public class Funcionario
{
    ManejaQuestao maneja = new ManejaQuestao();
    AppDbContext db = new AppDbContext();
    private int id { get; set; }
    private string nome { get; set; }
    private string cpf { get; set; }
    private char situacao { get; set; }

    public Funcionario(string nome, string cpf)
    {
        this.nome = nome;
        this.cpf = cpf;
    }

    public static Funcionario BuscarFuncionario(int id)
    {
        AppDbContext db = new AppDbContext();
        return db.funcionarios.Find(id);
    }

    public async Task Cadastrar(Funcionario funcionario)
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

            Console.WriteLine($"Funcionário encontrado: {funcionario.nome} - {funcionario.cpf}");
            Console.WriteLine("Digite 1 para editar o nome do funcionário");
            Console.WriteLine("Digite 2 para editar o CPF do funcionário");
            Console.WriteLine("Digite 3 para editar a situação do funcionário");
            Console.WriteLine("Digite 4 para cancelar a edição");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    funcionario.nome = maneja.Resposta("Digite o novo nome do funcionário:");
                    db.SaveChanges();
                    break;
                case 2:
                    funcionario.nome = maneja.Resposta("Digite o novo CPF do funcionário:");
                    db.SaveChanges();
                    break;
                case 3:
                    funcionario.nome = maneja.Resposta("Digite a nova situação do funcionário (A para ativo, I para inativo):");
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