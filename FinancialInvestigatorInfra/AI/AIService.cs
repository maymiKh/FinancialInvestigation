using FinancialInvetigationApp.AI;
using FinancialInvetigationApp.AI.Models;
using Microsoft.Extensions.AI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialInvestigatorInfra.AI
{
    public class AIService : IAIService
    {
        private readonly IChatClient _client;
        public AIService(IChatClient client)
        {
            _client = client;
        }
        public async Task<IncidentAnalysis> AnalyzeAsync(string title, string? description, CancellationToken cancellationToken)
        {
            var messages = new List<ChatMessage>
                {
                    new(
                        ChatRole.System,
                        """
                        You are a technical incident investigation assistant.

                        Analyze only the information provided.
                        Do not invent facts.

                        Provide:
                        - a short summary
                        - possible causes
                        - investigation steps
                        """),

                    new(
                        ChatRole.User,
                        $"""
                        Incident title:
                        {title}

                        Incident description:
                        {description}
                        """)
                };

            var response =
                await _client.GetResponseAsync(
                    messages,
                    cancellationToken: cancellationToken);

            // Temporary implementation today.
            return new IncidentAnalysis(
                response.ToString(),
                [],
                []);
        }
    }
}
