using System;
using System.Collections.Generic;
using System.Text;
using $safeprojectname$.Internal.CanalInterno;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using Comstroke.$ext_safeprojectname$.Model.Transaccion.Response.Transaccionalidad;
using Comstroke.Global.Contract;
using Comstroke.Global.ModelEngine.General;

namespace $safeprojectname$.Ejecucion.CanalInterno.Autorizaciones
{
    public class ClaveBP : IRecover<ClaveTransaccion, ClaveResponse>
    {
        public List<Link> BuildResponseLinks(ClaveTransaccion objetoEjecucionCrud)
        {
            return new List<Link>();
        }

        public Meta BuildResponseMeta(ClaveTransaccion objetoEjecucionCrud)
        {
            return new Meta();
        }

        public Page BuildResponsePage(ClaveTransaccion objetoEjecucionCrud)
        {
            return new Page();
        }

        public ClaveResponse BuildResponse(ClaveTransaccion objetoEjecucionCrud)
        {
            ClaveResponse objRespuesta= new ClaveResponse();
            objRespuesta.RespuestaClave = objetoEjecucionCrud.RespuestaClave;
            return objRespuesta;
        }

        public void RecoverInformation(ClaveTransaccion objetoEjecucionCrud)
        {
            ConsultarInformacionBP.ConsultaTokenJwt(objetoEjecucionCrud);
        }

        public void CheckParameters(ClaveTransaccion objetoEjecucionCrud)
        {
            //throw new NotImplementedException();
        }
    }
}
