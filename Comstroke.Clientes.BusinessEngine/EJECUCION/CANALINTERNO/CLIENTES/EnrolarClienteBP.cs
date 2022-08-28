using $safeprojectname$.Internal.CanalInterno;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using Comstroke.$ext_safeprojectname$.Model.Transaccion.Response.Transaccionalidad;
using Comstroke.Global.Contract;
using Comstroke.Global.ModelEngine.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Ejecucion.CanalInterno.Clientes
{
    public class EnrolarClienteBP : IInsert<ClienteTransaccion, ClienteResponse>
    {
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
            ClienteResponse cl = new ClienteResponse();
            return cl;
        }

        public void InsertInformation(ClienteTransaccion objetoEjecucionCrud)
        {
            InsertarInformacionBP.IngresarCliente(objetoEjecucionCrud);
        }

        public void CheckParameters(ClienteTransaccion objetoEjecucionCrud)
        {
            //no hacer nada
        }
    }
}
