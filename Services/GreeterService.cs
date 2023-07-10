using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Inventario;

namespace GrpcGreeter.Services
{

    public class GreeterService : InventarioService.InventarioServiceBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly MensajeService _mensajeService;
        public GreeterService(ILogger<GreeterService> logger, MensajeService mensajeService)
        {
            _logger = logger;
            _mensajeService = mensajeService;
        }

        public override Task<RespuestaTextoPlano> ObtenerTextoPlano(SolicitudTextoPlano request, ServerCallContext context)
        {
            return Task.FromResult(new RespuestaTextoPlano
            {
                Texto = "Texto de prueba"
            });
        }

        public override Task<MensajeResponse> EnviarMensajeWeb(MensajeRequest request, ServerCallContext context)
        {
            _mensajeService.Mensaje = request.Mensaje;
            return Task.FromResult(new MensajeResponse
            {
                Respuesta = "Recibimos tu mensaje: " + request.Mensaje
            });
        }

        public override Task<MensajeResponse> RecibirMensajeInventario(SolicitudTextoPlano request, ServerCallContext context)
        {
            var mensaje = _mensajeService.Mensaje ?? "No hay mensajes nuevos";
            _mensajeService.Mensaje = null; // Borramos el mensaje una vez que ha sido leído
            return Task.FromResult(new MensajeResponse
            {
                Respuesta = mensaje
            });
        }
    }
}
