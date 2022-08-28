using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using Comstroke.Global.RestTools;
using Microsoft.AspNetCore.Mvc;
using System;
using Comstroke.Global.ModelEngine.General;
using Comstroke.$ext_safeprojectname$.Model.Transaccion.Response.Transaccionalidad;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccionalidad;
using Comstroke.$ext_safeprojectname$.Model.Transaccion.Request.Transaccionalidad;

namespace $safeprojectname$.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ClaveController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public ActionResult ProcesarClave(ClaveRequest clave)
        {
            ClaveTransaccion objTransaccion= this.BuildTransaction<ClaveTransaccion>();
            objTransaccion.UserName = clave.UserName;
            objTransaccion.Password = clave.Password;
            
            BaseStructure<ClaveResponse> BaseStructure = ControllerHelper.Recover<ClaveTransaccion, ClaveResponse>(this, "Clave", objTransaccion);
            return Ok(BaseStructure);
        }

        
    }
}
