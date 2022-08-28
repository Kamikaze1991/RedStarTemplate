using $safeprojectname$.Entidad.Transaccionalidad;
using Comstroke.Global.ModelEngine.Transaccion;
using System.Collections.Generic;

namespace $safeprojectname$.Entidad.Transaccional
{
    public class ClienteTransaccion:BaseTransaction
    {
        public ClienteTransaccion()
        {
            ListaCliente = new List<Cliente>();
            ClienteEntrada = new Cliente();
        }

        public Cliente ClienteEntrada { get; set; }
        public List<Cliente> ListaCliente { get; set; }
    }
}
