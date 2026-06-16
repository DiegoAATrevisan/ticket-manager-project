using Microsoft.EntityFrameworkCore.Internal;

public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public char Situacao { get; set; }
    public DateTime DataCadastro { get; set; }

    public Funcionario(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
    }


}