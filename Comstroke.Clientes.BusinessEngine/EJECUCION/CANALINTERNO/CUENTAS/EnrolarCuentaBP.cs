using $safeprojectname$.Internal.CanalInterno;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using Comstroke.$ext_safeprojectname$.Model.Transaccion.Response.Transaccionalidad;
using Comstroke.Global.Contract;
using Comstroke.Global.ModelEngine.General;
using System.Collections.Generic;

namespace $safeprojectname$.Ejecucion.CanalInterno.Cuentas
{
    public class EnrolarCuentaBP : IInsert<CuentaTransaccion, CuentaResponse>
    {
        public List<Link> BuildResponseLinks(CuentaTransaccion objetoEjecucionCrud)
        {
            return new List<Link>();
        }

        public Meta BuildResponseMeta(CuentaTransaccion objetoEjecucionCrud)
        {
            return new Meta();
        }

        public Page BuildResponsePage(CuentaTransaccion objetoEjecucionCrud)
        {
            return new Page();
        }

        public CuentaResponse BuildResponse(CuentaTransaccion objetoEjecucionCrud)
        {
            CuentaResponse cl = new CuentaResponse();
            return cl;
        }

        public void InsertInformation(CuentaTransaccion objetoEjecucionCrud)
        {
            InsertarInformacionBP.IngresarCuenta(objetoEjecucionCrud);
        }

        public void CheckParameters(CuentaTransaccion objetoEjecucionCrud)
        {
            //no hacer nada
        }
    }
}
