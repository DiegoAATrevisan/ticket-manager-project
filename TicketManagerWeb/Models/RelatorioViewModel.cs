namespace TicketManagerWeb.Models;

public class RelatorioViewModel
{
    public string Titulo { get; set; } = "Relatórios";
    public List<string> Opcoes { get; set; } = new()
    {
        "Tickets por funcionário",
        "Tickets por período",
        "Funcionários com mais tickets"
    };
}