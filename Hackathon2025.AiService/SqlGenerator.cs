
using Azure;
using Azure.AI.OpenAI;
using Azure.AI.OpenAI.Chat;
using OpenAI.Chat;
using System;
using System.ClientModel.Primitives;

namespace Hackathon2025.AiService
{
    public class SqlGenerator
    {
        private readonly ChatClient chatClient;

        public SqlGenerator()
        {
            var endpoint = new Uri("https://micha-mbkfitxi-eastus2.cognitiveservices.azure.com/");
            var model = "gpt-4.1";
            var deploymentName = "gpt-4.1";
            var apiKey = "AvKEs9SpzvdI4sOxCrzs16Mw8KedWfBLe9EzrJy39X5Da8KqKf5FJQQJ99BFACHYHv6XJ3w3AAAAACOGlNym";

            AzureOpenAIClient azureOpenAIClient = new(
                endpoint,
                new AzureKeyCredential(apiKey));
            chatClient = azureOpenAIClient.GetChatClient(deploymentName);
        }

        public string GenerateSqlQuery<T>(string searchText)
        {
            var requestOptions = new ChatCompletionOptions()
            {
                //MaxCompletionTokens = 800,
                Temperature = 1.0f,
                TopP = 1.0f,
                FrequencyPenalty = 0.0f,
                PresencePenalty = 0.0f,

            };

            List<ChatMessage> messages = new List<ChatMessage>()
            {
                new SystemChatMessage("I want you to produce a SQL Statement. It should provide a query with the following parameters for a table name Products that contains a ProductName and ProductDescription field which are both strings. "),
                new SystemChatMessage("This query is for a SQL Server database. "),
                new SystemChatMessage("Return only the sql query. "),
                new SystemChatMessage("Optimise the query for best performance but do not attempt to use indexes."),
                new SystemChatMessage("Add a top 100 clause to the query in the select and return the following columns: Id, ProductName, ProductDescription."),
                new UserChatMessage(searchText),
                    new UserChatMessage("Consider variations of the query which will satisfy the user's query"),
            };

            var response = chatClient.CompleteChat(messages, requestOptions);

            return response.Value.Content[0].Text;
        }
    }
}
