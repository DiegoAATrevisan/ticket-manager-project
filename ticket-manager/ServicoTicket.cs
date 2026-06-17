public class ServicoTicket
{
    ManejaQuestao maneja = new ManejaQuestao();
    private readonly AppDbContext _db;

    public ServicoTicket(AppDbContext db)
    {
        _db = db;
    }

    public async Task CadastrarTicket(Ticket ticket, string cpfFuncionario)
    {
        try
        {
            var cpf = cpfFuncionario?.ToUpper().Trim();

            var funcionario = _db.funcionarios
                .FirstOrDefault(f => f.Cpf == cpf);

            if (funcionario == null)
                throw new Exception("Funcionário não encontrado para o CPF informado.");

            ticket.IdFuncionario = funcionario.Id;
            ticket.DataCadastro = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            ticket.Situacao = 'A';

            _db.tickets.Add(ticket);
            await _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Houve um erro inesperado ao cadastrar o ticket");
            Console.WriteLine("Mensagem de erro: " + ex.Message);
            throw;
        }
    }

    public void Editar(int id, int quantidade = 0, string cpfFuncionario = "")
    {
        try
        {
            Ticket ticket = _db.tickets.Find(id);

            if (ticket == null)
                throw new Exception("Não foi possível encontrar esse ticket na base de dados, verifique o ID fornecido.");

            if (quantidade != 0)
            {
                ticket.Quantidade = quantidade;
            }

            if (!string.IsNullOrWhiteSpace(cpfFuncionario))
            {
                var cpf = cpfFuncionario.ToUpper().Trim();

                Funcionario funcionario = _db.funcionarios
                    .FirstOrDefault(f => f.Cpf == cpf);

                if (funcionario == null)
                    throw new Exception("Funcionário não encontrado para o CPF informado.");

                ticket.IdFuncionario = funcionario.Id;
            }

            ticket.DataCadastro = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);

            _db.SaveChanges();
        }
        catch (Exception)
        {
            Console.WriteLine("Houve um erro inesperado ao editar o ticket");
            throw;
        }
    }

    public List<Ticket> BuscarListaTicketsPorCpf(string cpf)
    {
        try
        {
            string cpfNormalizado = cpf?.ToUpper().Trim();

            Funcionario funcionario = _db.funcionarios
                .FirstOrDefault(f => f.Cpf == cpfNormalizado);

            if (funcionario == null)
                return new List<Ticket>();

            return _db.tickets
                .Where(t => t.IdFuncionario == funcionario.Id)
                .ToList();
        }
        catch (Exception)
        {
            Console.WriteLine("Houve um erro inesperado ao buscar os tickets pelo CPF");
            throw new Exception("Houve um erro inesperado ao buscar os tickets pelo CPF.");
        }
    }
}