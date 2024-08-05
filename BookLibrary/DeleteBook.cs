using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace BookLibrary
{
    public class DeleteBook
    {
        private readonly ILogger _logger;

        public DeleteBook(ILogger<DeleteBook> logger)
        {
            _logger = logger;
        }

        [Function("DeleteBook")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "books/{id}")] HttpRequest req, int id)
        {
            _logger.LogInformation($"Deleting book with ID: {id}");
            BookRepository.DeleteBook(id);
            return new OkResult();
        }
    }

}
