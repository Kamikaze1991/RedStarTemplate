using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using Comstroke.Global.RestTools;
using Microsoft.AspNetCore.Mvc;
using System;
using Comstroke.Global.ModelEngine.General;
using Comstroke.$ext_safeprojectname$.Model.Transaccion.Response.Transaccionalidad;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccionalidad;
using Comstroke.$ext_safeprojectname$.Model.Transaccion.Request.Transaccionalidad;
using Microsoft.AspNetCore.Authorization;

namespace $safeprojectname$.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ClientesController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public ActionResult EnrolarCliente(ClienteRequest objRequest)
        {
            ClienteTransaccion cl = this.BuildTransaction<ClienteTransaccion>();
            cl.ClienteEntrada = new Cliente()
            {
                Direccion = objRequest.Direccion,
                Telefono = objRequest.Telefono,
                Edad = objRequest.Edad,
                Estado = objRequest.Estado,
                Genero = objRequest.Genero,
                IdCliente = objRequest.IdCliente,
                Identificacion = objRequest.Identificacion,
                IdPersona = objRequest.IdPersona,
                Nombre = objRequest.Nombre,
                Password = objRequest.Password,
            };
            BaseStructure<ClienteResponse> BaseStructure = ControllerHelper.Insert<ClienteTransaccion, ClienteResponse>(this, "EnrolarCliente", cl);
            return Ok(BaseStructure);
        }

        [HttpGet]
        [Route("")]
        public ActionResult RecuperarCliente(String identificacion)
        {
            ClienteTransaccion cl = this.BuildTransaction<ClienteTransaccion>();
            cl.ClienteEntrada = new Cliente()
            {
                Direccion = String.Empty,
                Telefono = String.Empty,
                Edad =0,
                Estado = String.Empty,
                Genero = String.Empty,
                IdCliente = 0,
                Identificacion =identificacion,
                IdPersona = 0,
                Nombre = String.Empty,
                Password = String.Empty,
            };
            BaseStructure<ClienteResponse> BaseStructure = ControllerHelper.Recover <ClienteTransaccion, ClienteResponse>(this, "ConsultarCliente", cl);
            return Ok(BaseStructure);
        }

        [HttpPut]
        [Route("")]
        public ActionResult ActualizarCliente(ClienteRequest objRequest)
        {
            ClienteTransaccion cl = this.BuildTransaction<ClienteTransaccion>();
            cl.ClienteEntrada = new Cliente()
            {
                Direccion = objRequest.Direccion,
                Telefono = objRequest.Telefono,
                Edad = objRequest.Edad,
                Estado = objRequest.Estado,
                Genero = objRequest.Genero,
                Identificacion = objRequest.Identificacion,
                Nombre = objRequest.Nombre,
                Password = objRequest.Password,
            };
            BaseStructure<ClienteResponse> BaseStructure = ControllerHelper.Update<ClienteTransaccion, ClienteResponse>(this, "ActualizarCliente", cl);
            return Ok(BaseStructure);
        }
    }
}
