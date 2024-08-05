using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace BookLibrary
{
    public class GetBooks
    {
        private readonly ILogger _logger;

        public GetBooks(ILogger<GetBooks> logger)
        {
            _logger = logger;
        }

        [Function("GetBooks")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "books")] HttpRequest req)
        {
            _logger.LogInformation("Fetching all books.");
            var books = BookRepository.GetBooks();
            return new OkObjectResult(books);
        }
    }

}
