using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Transaccion.Request.Transaccionalidad
{
    public class MovimientoFechaRequest
    {
        public virtual DateTime FechaInicial { get; set; }
        public virtual DateTime FechaFinal { get; set; }
    }
}
