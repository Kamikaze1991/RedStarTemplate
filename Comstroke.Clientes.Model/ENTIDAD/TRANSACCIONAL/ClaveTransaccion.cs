using $safeprojectname$.Entidad.Transaccionalidad;
using Comstroke.Global.ModelEngine.Transaccion;
using System.Collections.Generic;

namespace $safeprojectname$.Entidad.Transaccional
{
    public class ClaveTransaccion:BaseTransaction
    {
        public ClaveTransaccion()
        {
            RespuestaClave = new Clave();
        }

        public string UserName { get; set; }
        public string Password { get; set; }

        public Clave RespuestaClave { get; set; }
    }
}
