using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BookLibrary
{
    public class CreateBook
    {
        private readonly ILogger _logger;

        public CreateBook(ILogger<CreateBook> logger)
        {
            _logger = logger;
        }

        [Function("CreateBook")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "books")] HttpRequest req)
        {
            _logger.LogInformation("Creating new book.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var book = JsonConvert.DeserializeObject<Book>(requestBody);
            BookRepository.AddBook(book);
            return new OkResult();
        }
    }

}
