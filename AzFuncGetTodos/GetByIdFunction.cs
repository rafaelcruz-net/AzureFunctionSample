using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Infra.Repository;

namespace AzFuncGetTodos
{
    public static class GetByIdFunction
    {
        [FunctionName("GetByIdFunction")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            Guid id = new Guid(req.Query["id"]);

            var repository = new TodoItemRepository();

            var todo = repository.GetById(id);

            if (todo == null)
                return new NotFoundObjectResult(new { message = "Não encontrei a Tarefa" });

            return new OkObjectResult(todo);
        }
    }
}
