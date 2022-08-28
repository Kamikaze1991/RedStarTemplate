using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Entidad.Transaccionalidad
{
    public class Cliente:Persona
    {
        public int IdCliente { get; set; }
        public string Password { get; set; }
        public string Estado { get; set; }
    }
}
