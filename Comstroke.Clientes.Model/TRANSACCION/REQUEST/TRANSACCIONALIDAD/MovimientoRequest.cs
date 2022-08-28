using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Transaccion.Request.Transaccionalidad
{
    public class MovimientoRequest
    {
        public virtual int IdMovimiento { get; set; }
        public virtual int IdCuenta { get; set; }
        public virtual string TipoMovimiento { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual decimal Saldo { get; set; }
        public virtual DateTime FechaCreacion { get; set; }
        public virtual DateTime FechaModificacion { get; set; }
        public virtual int Borrar { get; set; }
    }
}
