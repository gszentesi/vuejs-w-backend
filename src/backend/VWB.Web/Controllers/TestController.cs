using Microsoft.AspNetCore.Mvc;
using VWB.App.Exceptions;

namespace RWA.Web.Controllers
{
    public class TestController : Controller
    {
        [HttpPost("ThrowBusinessException/{message}/{code}")]
        [ProducesResponseType(typeof(GlobalErrorHandlingMiddleware.Result), StatusCodes.Status400BadRequest)]
        public async Task ThrowBusinessException(string message, int code, CancellationToken cancellationToken)
        {
            throw new BusinessException(message, code, new Exception("Inner exception", new Exception("Inner inner exception")));
        }

        [HttpPost("ThrowUnHandledException")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task ThrowUnhandledException(CancellationToken cancellationToken)
        {
            throw new Exception("Unhandled exception occured.");
        }
    }
}
