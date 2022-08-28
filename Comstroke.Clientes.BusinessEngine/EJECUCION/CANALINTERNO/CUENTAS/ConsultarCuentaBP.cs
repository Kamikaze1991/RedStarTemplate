using System;
using System.Collections.Generic;
using System.Text;
using $safeprojectname$.Internal.CanalInterno;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using Comstroke.$ext_safeprojectname$.Model.Transaccion.Response.Transaccionalidad;
using Comstroke.Global.Contract;
using Comstroke.Global.ModelEngine.General;

namespace $safeprojectname$.Ejecucion.CanalInterno.Cuentas
{
    public class ConsultarCuentaBP : IRecover<CuentaTransaccion, CuentaResponse>
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
            cl.Cuentas = objetoEjecucionCrud.ListaCuenta;
            return cl;
        }

        public void RecoverInformation(CuentaTransaccion objetoEjecucionCrud)
        {
            ConsultarInformacionBP.ConsultaCuenta(objetoEjecucionCrud);
        }

        public void CheckParameters(CuentaTransaccion objetoEjecucionCrud)
        {
            //throw new NotImplementedException();
        }
    }
}
