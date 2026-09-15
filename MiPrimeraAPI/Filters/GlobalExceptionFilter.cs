using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MiPrimeraAPI.Data;

namespace MiPrimeraAPI.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        // Logger para registrar errores
        private readonly ILogger<GlobalExceptionFilter> _logger;

        // Constructor: recibe el logger
        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        // Método que se ejecuta cuando hay un error
        public void OnException(ExceptionContext context)
        {
            // 1. Registrar el error en consola
            _logger.LogError(context.Exception,
                "Ocurrió un error: {Message}",
                context.Exception.Message);

            // 2. Crear respuesta de error
            var response = new
            {
                mensaje = "Error interno del servidor",
                detalle = context.Exception.Message
            };

            // 3. Asignar respuesta (código 500)
            context.Result = new ObjectResult(response)
            {
                StatusCode = 500
            };

            // 4. Marcar error como manejado
            context.ExceptionHandled = true;
        }
    }
}