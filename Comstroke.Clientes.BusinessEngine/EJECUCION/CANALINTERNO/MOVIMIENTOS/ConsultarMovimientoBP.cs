using System;
using System.Collections.Generic;
using System.Text;
using $safeprojectname$.Internal.CanalInterno;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using Comstroke.$ext_safeprojectname$.Model.Transaccion.Response.Transaccionalidad;
using Comstroke.Global.Contract;
using Comstroke.Global.ModelEngine.General;

namespace $safeprojectname$.Ejecucion.CanalInterno.Movimientos
{
    public class ConsultarMovimientoBP: IRecover<MovimientoTransaccion, MovimientoResponse>
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
            cl.Movimientos = objetoEjecucionCrud.ListaMovimiento;
            return cl;
        }

        public void RecoverInformation(MovimientoTransaccion objetoEjecucionCrud)
        {
            ConsultarInformacionBP.ConsultaMovimientos(objetoEjecucionCrud);
        }

        public void CheckParameters(MovimientoTransaccion objetoEjecucionCrud)
        {
            //throw new NotImplementedException();
        }
    }
}
