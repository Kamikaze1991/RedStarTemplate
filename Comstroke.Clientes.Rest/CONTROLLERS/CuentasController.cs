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
    public class CuentasController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public ActionResult EnrolarCuenta(CuentaRequest objRequest)
        {
            CuentaTransaccion objTransaccion= this.BuildTransaction<CuentaTransaccion>();
            objTransaccion.CuentaEntrada = new Cuenta()
            {
                Borrar = objRequest.Borrar,
                Estado = objRequest.Estado,
                IdCliente = objRequest.IdCliente,
                NumeroCuenta = objRequest.NumeroCuenta,
                SaldoInicial = objRequest.SaldoInicial,
                TipoCuenta = objRequest.TipoCuenta
            };
            BaseStructure<CuentaResponse> BaseStructure = ControllerHelper.Insert<CuentaTransaccion, CuentaResponse>(this, "EnrolarCuenta", objTransaccion);
            return Ok(BaseStructure);
        }

        [HttpGet]
        [Route("")]
        public ActionResult RecuperarCuenta(String numeroCuenta)
        {
            CuentaTransaccion objTransaccion = this.BuildTransaction<CuentaTransaccion>();
            objTransaccion.CuentaEntrada = new Cuenta()
            {
                Estado = string.Empty,
                IdCliente =0,
                NumeroCuenta = numeroCuenta,
                SaldoInicial = 0,
                TipoCuenta = string.Empty
            };
            BaseStructure<CuentaResponse> BaseStructure = ControllerHelper.Recover <CuentaTransaccion, CuentaResponse>(this, "ConsultarCuenta", objTransaccion);
            return Ok(BaseStructure);
        }

        [HttpPut]
        [Route("")]
        public ActionResult ActualizarCuenta(CuentaRequest objRequest)
        {
            CuentaTransaccion objTransaccion = this.BuildTransaction<CuentaTransaccion>();
            objTransaccion.CuentaEntrada = new Cuenta()
            {
                IdCuenta= objRequest.IdCuenta,
                Borrar = objRequest.Borrar,
                Estado = objRequest.Estado,
                IdCliente = objRequest.IdCliente,
                NumeroCuenta = objRequest.NumeroCuenta,
                SaldoInicial = objRequest.SaldoInicial,
                TipoCuenta = objRequest.TipoCuenta
            };
            BaseStructure<CuentaResponse> BaseStructure = ControllerHelper.Update<CuentaTransaccion, CuentaResponse>(this, "ActualizarCuenta", objTransaccion);
            return Ok(BaseStructure);
        }
    }
}
