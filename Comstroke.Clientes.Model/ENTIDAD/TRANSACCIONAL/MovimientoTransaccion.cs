using $safeprojectname$.Entidad.Transaccionalidad;
using Comstroke.Global.ModelEngine.Transaccion;
using System.Collections.Generic;

namespace $safeprojectname$.Entidad.Transaccional
{
    public class MovimientoTransaccion : BaseTransaction
    {
        public MovimientoTransaccion()
        {
            ListaMovimiento = new List<Movimiento>();
            MovimientoEntrada = new Movimiento();
        }
        public Movimiento MovimientoEntrada { get; set; }
        public List<Movimiento> ListaMovimiento { get; set; }
    }
}
