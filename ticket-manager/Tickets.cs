using System.Data.Common;

public class Tickets
{
    ManejaQuestao maneja = new ManejaQuestao();
    static AppDbContext db = new AppDbContext();

    public int Id { get; set; }
    public int IdFuncionario { get; set; }
    public int Quantidade { get; set; }
    public char Situacao { get; set; }

    public Tickets() { }

    public Tickets(int idFuncionario, int quantidade)
    {
        IdFuncionario = idFuncionario;
        Quantidade = quantidade;
    }

    public static Tickets BuscarTicket(int id)
    {
        Tickets ticket = db.tickets.Find(id);
        return ticket;
    }

    public async Task CadastrarTicket(Tickets ticket)
    {
        try
        {
            db.tickets.Add(ticket);
            await db.SaveChangesAsync();
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
            Tickets ticket = db.tickets.Find(id);

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
                    db.SaveChanges();
                    break;
                case 2:
                    ticket.Quantidade = int.Parse(maneja.Resposta("Digite a nova quantidade de tickets:"));
                    db.SaveChanges();
                    break;
                case 3:
                    ticket.Situacao = char.Parse(maneja.Resposta("Digite a nova situação do ticket (A para ativo, I para inativo):"));
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
            Console.WriteLine("Houve um erro inesperado ao editar o ticket");
            throw;
        }
    }
}
