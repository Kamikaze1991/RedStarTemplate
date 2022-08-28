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
    public class MovimientosController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public ActionResult RegistrarMovimiento(MovimientoRequest objRequest)
        {
            MovimientoTransaccion objTransaccion= this.BuildTransaction<MovimientoTransaccion>();
            objTransaccion.MovimientoEntrada = new Movimiento()
            {
                IdCuenta=objRequest.IdCuenta,
                Saldo= objRequest.Saldo,
                TipoMovimiento=objRequest.TipoMovimiento,
                Valor=objRequest.Valor
            };
            BaseStructure<MovimientoResponse> BaseStructure = ControllerHelper.Insert<MovimientoTransaccion, MovimientoResponse>(this, "RegistrarMovimiento", objTransaccion);
            return Ok(BaseStructure);
        }

        [HttpGet]
        [Route("")]
        public ActionResult RecuperarMovimiento(int numeroMovimiento)
        {
            MovimientoTransaccion objTransaccion = this.BuildTransaction<MovimientoTransaccion>();
            objTransaccion.MovimientoEntrada = new Movimiento()
            {
                IdMovimiento=numeroMovimiento,
                IdCuenta =0,
                Saldo = 0,
                TipoMovimiento = String.Empty,
                Valor = 0
            };
            BaseStructure<MovimientoResponse> BaseStructure = ControllerHelper.Recover <MovimientoTransaccion, MovimientoResponse>(this, "ConsultarMovimiento", objTransaccion);
            return Ok(BaseStructure);
        }

        [HttpPut]
        [Route("")]
        public ActionResult ActualizarMovimiento(MovimientoRequest objRequest)
        {
            MovimientoTransaccion objTransaccion = this.BuildTransaction<MovimientoTransaccion>();
            objTransaccion.MovimientoEntrada = new Movimiento()
            {
                IdMovimiento = objRequest.IdMovimiento,
                IdCuenta = objRequest.IdCuenta,
                Saldo = objRequest.Saldo,
                TipoMovimiento = objRequest.TipoMovimiento,
                Valor = objRequest.Valor,
                Borrar=objRequest.Borrar
            };
            BaseStructure<MovimientoResponse> BaseStructure = ControllerHelper.Update<MovimientoTransaccion, MovimientoResponse>(this, "ActualizarMovimiento", objTransaccion);
            return Ok(BaseStructure);
        }

        [HttpGet]
        [Route("reporte")]
        public ActionResult RecuperarMovimientoFecha(string fecha)
        {
            string fechaInicial =fecha.Split(',')[0];
            string fechaFinal = fecha.Split(',')[1];
            MovimientoFechaTransaccion objTransaccion = this.BuildTransaction<MovimientoFechaTransaccion>();
            objTransaccion.FechaInicial = DateTime.Parse(fechaInicial);
            objTransaccion.FechaFinal = DateTime.Parse(fechaFinal);

            BaseStructure<MovimientoFechaResponse> BaseStructure = ControllerHelper.Recover<MovimientoFechaTransaccion, MovimientoFechaResponse>(this, "ConsultarMovimientoFecha", objTransaccion);
            return Ok(BaseStructure);
        }
    }
}
