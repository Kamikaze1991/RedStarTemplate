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
    public class ConsultarMovimientoFechaBP: IRecover<MovimientoFechaTransaccion, MovimientoFechaResponse>
    {
        public List<Link> BuildResponseLinks(MovimientoFechaTransaccion objetoEjecucionCrud)
        {
            return new List<Link>();
        }

        public Meta BuildResponseMeta(MovimientoFechaTransaccion objetoEjecucionCrud)
        {
            return new Meta();
        }

        public Page BuildResponsePage(MovimientoFechaTransaccion objetoEjecucionCrud)
        {
            return new Page();
        }

        public MovimientoFechaResponse BuildResponse(MovimientoFechaTransaccion objetoEjecucionCrud)
        {
            MovimientoFechaResponse cl = new MovimientoFechaResponse();
            cl.Movimientos = objetoEjecucionCrud.Movimientos;
            return cl;
        }

        public void RecoverInformation(MovimientoFechaTransaccion objetoEjecucionCrud)
        {
            ConsultarInformacionBP.ConsultaMovimientosFechas(objetoEjecucionCrud);
        }

        public void CheckParameters(MovimientoFechaTransaccion objetoEjecucionCrud)
        {
            //throw new NotImplementedException();
        }
    }
}
