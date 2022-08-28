using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Transaccion.Request.Transaccionalidad
{
    public class CuentaRequest
    {
        public virtual int IdCuenta { get; set; }
        public virtual int IdCliente { get; set; }
        public virtual string NumeroCuenta { get; set; }
        public virtual string TipoCuenta { get; set; }
        public virtual decimal SaldoInicial { get; set; }
        public virtual string Estado { get; set; }
        public virtual DateTime FechaCreacion { get; set; }
        public virtual DateTime FechaModificacion { get; set; }
        public virtual int Borrar { get; set; }
    }
}
