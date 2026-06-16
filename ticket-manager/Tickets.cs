using System.Data.Common;

public class Tickets
{
    ManejaQuestao maneja = new ManejaQuestao();
    static AppDbContext db = new AppDbContext();

    public int Id { get; set; }
    public int IdFuncionario { get; set; }
    public int Quantidade { get; set; }
    public char Situacao { get; set; }
    public DateTime DataCadastro { get; set; }


    public Tickets() { }

    public Tickets(int idFuncionario, int quantidade)
    {
        IdFuncionario = idFuncionario;
        Quantidade = quantidade;
    }

}
