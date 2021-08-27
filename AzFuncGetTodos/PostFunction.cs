using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Infra.Model;
using Infra.Repository;

namespace AzFuncGetTodos
{
    public static class PostFunction
    {
        [FunctionName("SaveTodos")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            TodoItem data = JsonConvert.DeserializeObject<TodoItem>(requestBody);

            if (data == null)
                return new BadRequestObjectResult(new { message = "Dados para criação de uma tarefa é obrigatoria" });

            var repository = new TodoItemRepository();

            data.Id = Guid.NewGuid();

            repository.Save(data);

            return new CreatedResult("", data);
        }
    }
}
