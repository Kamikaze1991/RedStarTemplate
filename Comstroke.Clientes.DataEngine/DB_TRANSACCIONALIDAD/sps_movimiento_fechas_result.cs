using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.db_transaccionalidad
{
    public class sps_movimiento_fechas_result
    {
		public DateTime mo_fecha_creacion{ get; set; }
		public string pe_nombre{ get; set; }
		public string cu_numero_cuenta{get; set;}
	    public string cu_tipo_cuenta { get; set; }
		public decimal cu_saldo_inicial { get; set; }
		public string cu_estado { get; set; }
		public decimal mo_valor { get; set; }
		public decimal mo_saldo { get; set; }
	}
}
