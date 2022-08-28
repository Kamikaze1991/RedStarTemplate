using $safeprojectname$.Internal.CanalInterno;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using Comstroke.$ext_safeprojectname$.Model.Transaccion.Response.Transaccionalidad;
using Comstroke.Global.Contract;
using Comstroke.Global.ModelEngine.General;
using System.Collections.Generic;

namespace $safeprojectname$.Ejecucion.CanalInterno.Movimientos
{
    public class RegistrarMovimientoBP : IInsert<MovimientoTransaccion, MovimientoResponse>
    {
        public List<Link> BuildResponseLinks(MovimientoTransaccion objetoEjecucionCrud)
        {
            return new List<Link>();
        }

        public Meta BuildResponseMeta(MovimientoTransaccion objetoEjecucionCrud)
        {
            return new Meta();
        }

        public Page BuildResponsePage(MovimientoTransaccion objetoEjecucionCrud)
        {
            return new Page();
        }

        public MovimientoResponse BuildResponse(MovimientoTransaccion objetoEjecucionCrud)
        {
            MovimientoResponse cl = new MovimientoResponse();
            return cl;
        }

        public void InsertInformation(MovimientoTransaccion objetoEjecucionCrud)
        {
            InsertarInformacionBP.IngresarMovimiento(objetoEjecucionCrud);
        }

        public void CheckParameters(MovimientoTransaccion objetoEjecucionCrud)
        {
            //no hacer nada
        }
    }
}
