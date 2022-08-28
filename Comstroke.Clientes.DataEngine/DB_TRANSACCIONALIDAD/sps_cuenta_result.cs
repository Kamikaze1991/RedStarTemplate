using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.db_transaccionalidad
{
    internal class sps_cuenta_result
    {
        public int cu_id_cuenta { get; set; }
        public int cu_id_cliente { get; set; }
        public string cu_numero_cuenta { get; set; }
        public string cu_tipo_cuenta { get; set; }
        public decimal cu_saldo_inicial { get; set; }
        public string cu_estado { get; set; }
        public DateTime cu_fecha_creacion { get; set; }
        public DateTime cu_fecha_modificacion { get; set; }
    }
}
