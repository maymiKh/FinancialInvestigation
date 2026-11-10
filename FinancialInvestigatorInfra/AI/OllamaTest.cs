using Microsoft.Extensions.AI;
using OllamaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialInvestigatorInfra.AI
{
    public class OllamaTest
    {
        public async Task TestOllamaAsync()
        {
            IChatClient client =
                        new OllamaApiClient(
                            new Uri("http://localhost:11434/"),
                            "phi3:mini");
            var response = await client.GetResponseAsync(
            "Explain dependency injection in one sentence.");

            Console.WriteLine(response);
        }
    }
}
