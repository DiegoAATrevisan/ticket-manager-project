using Microsoft.EntityFrameworkCore;

public class ServicoRelatorio
{
    private readonly AppDbContext _db;

    public ServicoRelatorio(AppDbContext db)
    {
        _db = db;
    }

    public List<RelatorioTicketItem> FazerRelatorio(
        string nome = "",
        string cpf = "",
        DateTime? dataInicial = null,
        DateTime? dataFinal = null)
    {
        try
        {
            var query =
                from ticket in _db.tickets
                join funcionario in _db.funcionarios on ticket.IdFuncionario equals funcionario.Id
                select new RelatorioTicketItem
                {
                    Quantidade = ticket.Quantidade,
                    NomeFuncionario = funcionario.Nome,
                    CpfFuncionario = funcionario.Cpf,
                    DataCadastro = ticket.DataCadastro
                };

            if (!string.IsNullOrWhiteSpace(nome))
            {
                var nomeBusca = $"%{nome.Trim().ToUpper()}%";
                query = query.Where(x => EF.Functions.ILike(x.NomeFuncionario, nomeBusca));
            }

            if (!string.IsNullOrWhiteSpace(cpf))
            {
                var cpfBusca = $"%{cpf.Trim().ToUpper()}%";
                query = query.Where(x => EF.Functions.ILike(x.CpfFuncionario, cpfBusca));
            }

            if (dataInicial.HasValue)
            {
                var inicio = DateTime.SpecifyKind(dataInicial.Value.Date, DateTimeKind.Utc);
                query = query.Where(x => x.DataCadastro >= inicio);
            }

            if (dataFinal.HasValue)
            {
                var fim = DateTime.SpecifyKind(dataFinal.Value.Date.AddDays(1).AddTicks(-1), DateTimeKind.Utc);
                query = query.Where(x => x.DataCadastro <= fim);
            }

            return query.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Houve um erro ao gerar o relatório. Erro: " + ex.Message);
        }
    }
}

public class RelatorioTicketItem
{
    public int Quantidade { get; set; }
    public string NomeFuncionario { get; set; } = string.Empty;
    public string CpfFuncionario { get; set; } = string.Empty;
    public DateTime DataCadastro { get; set; }
}