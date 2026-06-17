public class Ticket
{
    public int Id { get; set; }
    public int IdFuncionario { get; set; }
    public int Quantidade { get; set; }
    public char Situacao { get; set; }
    public DateTime DataCadastro { get; set; }


    public Ticket() { }

    public Ticket(int idFuncionario, int quantidade)
    {
        IdFuncionario = idFuncionario;
        Quantidade = quantidade;
    }

}
