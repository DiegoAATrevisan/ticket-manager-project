class Tickets
{
    private int idFuncionario { get; set; }
    private int quantidade { get; set; }

    public Tickets(int idFuncionario, int quantidade)
    {
        this.idFuncionario = idFuncionario;
        this.quantidade = quantidade;
    }
}