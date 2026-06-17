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
    public void Editar(int id)
    {
        try
        {
            Ticket ticket = _db.tickets.Find(id);

            if (ticket == null)
            {
                Console.WriteLine("Ticket não encontrado");
                throw new Exception("Não foi possível encontrar esse ticket na base de dados, verifique o ID fornecido.");
            }

            Console.WriteLine($"Ticket encontrado: Funcionário {ticket.IdFuncionario} - Quantidade {ticket.Quantidade}");
            Console.WriteLine("Digite 1 para editar o funcionário do ticket");
            Console.WriteLine("Digite 2 para editar a quantidade de tickets");
            Console.WriteLine("Digite 3 para editar a situação do ticket");
            Console.WriteLine("Digite 4 para cancelar a edição");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    ticket.IdFuncionario = int.Parse(maneja.Resposta("Digite o novo id do funcionário:"));
                    _db.SaveChanges();
                    break;
                case 2:
                    ticket.Quantidade = int.Parse(maneja.Resposta("Digite a nova quantidade de tickets:"));
                    _db.SaveChanges();
                    break;
                case 3:
                    ticket.Situacao = char.Parse(maneja.Resposta("Digite a nova situação do ticket (A para ativo, I para inativo):"));
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
            Console.WriteLine("Houve um erro inesperado ao editar o ticket");
            throw;
        }
    }

}