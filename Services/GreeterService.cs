using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario;

namespace GrpcGreeter.Services
{
    public class GreeterService : InventarioService.InventarioServiceBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
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
            return Task.FromResult(new MensajeResponse
            {
                Respuesta = "Recibimos tu mensaje: " + request.Mensaje
            });
        }
    }
}
