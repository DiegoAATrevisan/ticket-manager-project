using System.Runtime.CompilerServices;

public class ServicoFuncionario
{
    ManejaQuestao maneja = new ManejaQuestao();
    private readonly AppDbContext _db;

    public ServicoFuncionario(AppDbContext db)
    {
        _db = db;
    }

    public Funcionario BuscarFuncionario(int? id = 0, string nome = "", string cpf = "")
    {

        try
        {
            Funcionario funcionario;
            if (id != null && id != 0)
            {
                Console.WriteLine("id:: " + id);
                funcionario = _db.funcionarios.Find(id);
                return funcionario;
            }

            if (nome != "")
            {
                Console.WriteLine("Nome:: " + nome);
                funcionario = _db.funcionarios.FirstOrDefault(f => f.Nome == nome.ToUpper());
                return funcionario;
            }

            if (cpf != "")
            {
                Console.WriteLine("cpf:: " + cpf);
                funcionario = _db.funcionarios.FirstOrDefault(f => f.Cpf == cpf.ToUpper());
                return funcionario;
            }

            return null;
        }
        catch (System.Exception)
        {
            throw new Exception("Funcionário não encontrado.");
        }

    }

    public void CadastrarFuncionario(Funcionario funcionario)
    {
        try
        {
            funcionario.Nome = funcionario.Nome.ToUpper();
            funcionario.Cpf = funcionario.Cpf.ToUpper();
            _db.funcionarios.Add(funcionario);
            _db.SaveChanges();
        }
        catch (System.Exception)
        {
            Console.WriteLine("Houve um erro inesperado ao cadastrar o funcionário. ServicoFuncionario");
            throw new Exception("Houve um erro inesperado ao cadastrar o funcionário.");
        }
    }

    public void Editar(int id, String nome = "", String cpf = "", char situacao = 'A')
    {
        try
        {
            Funcionario funcionario = _db.funcionarios.Find(id);

            if (funcionario == null)
            {
                Console.WriteLine("Funcionário não encontrado");
                throw new Exception("Não foi possivel encontrar esse usuario na base de dados, verifique o ID fornecido.");
            }

            if (nome != "")
            {
                funcionario.Nome = nome.ToUpper();
                _db.SaveChanges();
            }
            if (cpf != "")
            {
                funcionario.Cpf = cpf.ToUpper();
                _db.SaveChanges();
            }
            situacao = char.ToUpper(situacao);
            if (situacao == 'A' || situacao == 'I')
            {
                funcionario.Situacao = situacao;
                _db.SaveChanges();
            }
            else
            {
                throw new Exception($"A situação '" + situacao + "' é inválida, apenas A = Ativo e I = Inativo são aceitos, a situação atual do funcionário não foi alterada.");
            }

        }
        catch (System.Exception)
        {
            Console.WriteLine("Ouve um erro ao editar o funcionário");
            throw;
        }
    }
}