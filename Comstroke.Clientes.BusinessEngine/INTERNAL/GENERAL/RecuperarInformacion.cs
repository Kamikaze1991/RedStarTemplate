using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using System;
using System.Collections.Generic;
using System.Text;
using Comstroke.$ext_safeprojectname$.DataEngine;
using Comstroke.$ext_safeprojectname$.DataEngine.db_transaccionalidad;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace $safeprojectname$.Internal.General
{
    internal static class RecuperarInformacion
    {
        internal static void ConsultaClientes(ClienteTransaccion transaction)
        {
            Db_TransaccionalidadProcedure.sps_cliente(transaction);
        }

        internal static void ConsultaCuentas(CuentaTransaccion transaction)
        {
            Db_TransaccionalidadProcedure.sps_cuenta(transaction);
        }

        internal static void ConsultaMovimientos(MovimientoTransaccion transaction)
        {
            Db_TransaccionalidadProcedure.sps_movimiento(transaction);
        }

        internal static void ConsultaMovimientosFechas(MovimientoFechaTransaccion transaction)
        {
            Db_TransaccionalidadProcedure.sps_movimiento_fechas(transaction);
        }

        internal static void ConsultaTokenJwt(ClaveTransaccion transaction)
        {
            string privateKey = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetSection("JWT:Key")?.Value;

        var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(privateKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, "prueba")
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            transaction.RespuestaClave.token = tokenHandler.WriteToken(token);
        }
    }
}
