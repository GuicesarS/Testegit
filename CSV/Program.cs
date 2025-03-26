using System;
using System.Globalization;
using System.Collections.Generic;
class Planilha
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public DateTime Aniversario { get; set; }

    public Planilha(string nome, string telefone, DateTime aniversario)
    {
        Nome = nome;
        Telefone = telefone;
        Aniversario = aniversario;
    }

    override public string ToString()
    {
        return Nome + "," + Telefone + "," + Aniversario.ToString("dd-MM-yyyy");
    }
}

class Program
{
    static void Main(string[] args)
    {
        string criarplanilha = @"C:\Users\Guilherme.Soares\Desktop\Estudoc#\Arquivos_C#\CSV\planilha.csv";
        try
        {
            List<Planilha> List = new List<Planilha>
             {
                 new("Guilherme Soares", "31991253590", DateTime.ParseExact("26-12-2006", "dd-MM-yyyy", CultureInfo.InvariantCulture)),
                 new("Suzany", "31991993608", DateTime.ParseExact("19-04-2006", "dd-MM-yyyy", CultureInfo.InvariantCulture)),
             };

            // File.Create(criarplanilha); // crei a planilha
            using (StreamWriter sw = File.AppendText(criarplanilha))
            {
                foreach (Planilha pl in List) // usando lista então precisa do foreach
                {
                    sw.WriteLine(pl.ToString());
                }
                
            }
            Console.WriteLine("Planilha criada!");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Erro IO: " + ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Erro ao criar a planilha: " + ex.Message);
        }


    }
}
