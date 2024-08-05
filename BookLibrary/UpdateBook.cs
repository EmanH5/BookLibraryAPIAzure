using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BookLibrary
{
    public class UpdateBook
    {
        private readonly ILogger _logger;

        public UpdateBook(ILogger<UpdateBook> logger)
        {
            _logger = logger;
        }

        [Function("UpdateBook")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "books")] HttpRequest req)
        {
            _logger.LogInformation($"Updating a book...");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var updatedBook = JsonConvert.DeserializeObject<Book>(requestBody);
            BookRepository.UpdateBook(updatedBook);
            return new OkResult();
        }
    }

}
