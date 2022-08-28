using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Transaccion.Request.Transaccionalidad
{
    public class ClienteRequest
    {
        public virtual string Password { get; set; }
        public virtual string Estado { get; set; }
        public virtual int IdPersona { get; set; }
        public virtual int IdCliente { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Genero { get; set; }
        public virtual int Edad { get; set; }
        public virtual string Identificacion { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string Telefono { get; set; }
        public virtual int Borrar { get; set; }
    }
}
