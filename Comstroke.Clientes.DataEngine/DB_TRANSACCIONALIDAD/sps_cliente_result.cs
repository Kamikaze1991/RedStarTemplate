using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.db_transaccionalidad
{
    public class sps_cliente_result
    {
		public int cl_id_cliente { get; set; }
		public int cl_id_persona { get; set; }
		public string cl_password { get; set; }
		public string cl_estado { get; set; }
		public DateTime cl_fecha_creacion { get; set; }
		public DateTime cl_fecha_modificacion { get; set; }
		public int pe_id_persona { get; set; }
		public string pe_nombre { get; set; }
		public string pe_genero { get; set; }
		public int pe_edad { get; set; }
		public string pe_identificacion { get; set; }
		public string pe_direccion { get; set; }
		public string pe_telefono { get; set; }
		public DateTime pe_fecha_creacion { get; set; }
		public DateTime pe_fecha_modificacion { get; set; }
	}
}
