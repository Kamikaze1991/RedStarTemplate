using $safeprojectname$.Entidad.Transaccionalidad;
using Comstroke.Global.ModelEngine.Transaccion;
using System.Collections.Generic;

namespace $safeprojectname$.Entidad.Transaccional
{
    public class CuentaTransaccion : BaseTransaction
    {
        public CuentaTransaccion() { 
            ListaCuenta=new List<Cuenta>();
            CuentaEntrada = new Cuenta();
        }
        public Cuenta CuentaEntrada { get; set; }
        public List<Cuenta> ListaCuenta { get; set; }
    }
}
