using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.db_transaccionalidad
{
    public class sps_movimiento_result
    {
        public int mo_id_movimiento { get; set; }
        public int mo_id_cuenta { get; set; }
        public string mo_tipo_movimiento { get; set; }
        public decimal mo_valor { get; set; }
        public decimal mo_saldo { get; set; }
        public DateTime mo_fecha_creacion { get; set; }
        public DateTime mo_fecha_modificacion { get; set; }
    }
}
