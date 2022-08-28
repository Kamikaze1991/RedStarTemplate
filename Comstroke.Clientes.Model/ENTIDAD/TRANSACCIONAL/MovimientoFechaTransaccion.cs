using $safeprojectname$.Entidad.Transaccionalidad;
using Comstroke.Global.ModelEngine.Transaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Entidad.Transaccional
{
    public class MovimientoFechaTransaccion: BaseTransaction
    {
        public MovimientoFechaTransaccion()
        {
            Movimientos = new List<MovimientoFecha>();
        }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public List<MovimientoFecha> Movimientos { get; set; }
    }
}
