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
    public class ConsultarClienteBP: IRecover<ClienteTransaccion, ClienteResponse>
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
            cl.Clientes = objetoEjecucionCrud.ListaCliente;
            return cl;
            
        }

        public void RecoverInformation(ClienteTransaccion objetoEjecucionCrud)
        {
            ConsultarInformacionBP.ConsultaClientes(objetoEjecucionCrud);
        }

        public void CheckParameters(ClienteTransaccion objetoEjecucionCrud)
        {
            //throw new NotImplementedException();
        }
    }
}
