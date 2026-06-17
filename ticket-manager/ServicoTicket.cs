public class ServicoTicket
{
    ManejaQuestao maneja = new ManejaQuestao();

    private readonly AppDbContext _db;

    public ServicoTicket(AppDbContext db)
    {
        _db = db;
    }

    public List<Ticket> BuscarListaTickets(int idFuncionario)
    {
        return _db.tickets
            .Where(t => t.IdFuncionario == idFuncionario)
            .ToList();
    }

    public Ticket BuscarTicket(int id)
    {
        Ticket ticket = _db.tickets.Find(id);
        return ticket;
    }

    public async Task CadastrarTicket(Ticket ticket)
    {
        try
        {
            _db.tickets.Add(ticket);
            await _db.SaveChangesAsync();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Houve um erro inesperado ao cadastrar o ticket");
            Console.WriteLine("Mensagem de erro: " + ex.Message);
            throw;
        }
    }

    public void Editar(int id, int idFuncionario = 0, int quantidade = 0, char situacao = 'A', DateTime dataCadastro = default)
    {
        try
        {
            Ticket ticket = _db.tickets.Find(id);

            if (ticket == null)
            {
                Console.WriteLine("Ticket não encontrado");
                throw new Exception("Não foi possível encontrar esse ticket na base de dados, verifique o ID fornecido.");
            }

            if (idFuncionario != 0)
            {
                ticket.IdFuncionario = idFuncionario;
                _db.SaveChanges();
            }

            if (quantidade != 0)
            {
                ticket.Quantidade = quantidade;
                _db.SaveChanges();
            }

            
            
                situacao = char.ToUpper(situacao);

                if (situacao == 'A' || situacao == 'I')
                {
                    ticket.Situacao = situacao;
                    _db.SaveChanges();
                }
                else
                {
                    throw new Exception($"A situação '{situacao}' é inválida, apenas A = Ativo e I = Inativo são aceitos, a situação atual do ticket não foi alterada.");
                }
            

            ticket.DataCadastro = dataCadastro;
            _db.SaveChanges();
        }
        catch (System.Exception)
        {
            Console.WriteLine("Houve um erro inesperado ao editar o ticket");
            throw;
        }
    }
}