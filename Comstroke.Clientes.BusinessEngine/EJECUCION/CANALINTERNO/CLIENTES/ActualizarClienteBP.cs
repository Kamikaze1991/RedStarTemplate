using System;
using System.Collections.Generic;
using System.Text;
using $safeprojectname$.Internal.CanalInterno;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using Comstroke.$ext_safeprojectname$.Model.Transaccion.Response.Transaccionalidad;
using Comstroke.Global.Contract;
using Comstroke.Global.ModelEngine.General;

namespace $safeprojectname$.Ejecucion.CanalInterno.Clientes
{
    public class ActualizarClienteBP : IUpdate<ClienteTransaccion, ClienteResponse>
    {
        public void UpdateInformation(ClienteTransaccion objetoEjecucionCrud)
        {
            ActualizarInformacionBP.ActualizarCliente(objetoEjecucionCrud);
        }

        public List<Link> BuildResponseLinks(ClienteTransaccion objetoEjecucionCrud)
        {
            return new List<Link>();
        }

        public Meta BuildResponseMeta(ClienteTransaccion objetoEjecucionCrud)
        {
            return new Meta();
        }

        public Page BuildResponsePage(ClienteTransaccion objetoEjecucionCrud)
        {
            return new Page();
        }

        public ClienteResponse BuildResponse(ClienteTransaccion objetoEjecucionCrud)
        {
            return new ClienteResponse();
        }

        public void CheckParameters(ClienteTransaccion objetoEjecucionCrud)
        {
            //no ace nada
        }
    }
}
