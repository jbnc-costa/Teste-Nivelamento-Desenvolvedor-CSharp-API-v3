using Newtonsoft.Json;
using System.Net;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        int totalGols = 0;

        for (int i = 1; i < 10; i++)
        {
            for (int j = 1; j < 3; j++)
            {
                string url = String.Format("https://jsonmock.hackerrank.com/api/football_matches?year={0}&team{1}={2}&page={3}", year, j, team, i);
        
                var requisicao = WebRequest.CreateHttp(url);

                var response = (HttpWebResponse)requisicao.GetResponse();
                
                var dataStream = response.GetResponseStream();

                var reader = new StreamReader(dataStream);

                dynamic valor = reader.ReadToEnd();

                var resultado = JsonConvert.DeserializeObject(valor);

                var total = resultado.data;
        
                if (total.Count > 0)
                {
                    foreach (var item in total)
                    {
                        if (j == 1)
                            totalGols += Convert.ToInt32(item.team1goals);
                        else
                            totalGols += Convert.ToInt32(item.team2goals);
                    }
                }
            }
        }

        return totalGols;
    }
}