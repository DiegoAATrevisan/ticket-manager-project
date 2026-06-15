using System.Reflection.Metadata;

class ManejaQuestao
{
   public string Resposta(string question)
    {
        string? resposta;

        do
        {
            Console.WriteLine(question);
            resposta = Console.ReadLine();
        }
        while (string.IsNullOrWhiteSpace(resposta));

        return resposta;
    }

}