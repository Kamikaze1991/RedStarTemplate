using Comstroke.$ext_safeprojectname$.DataEngine;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using System;
using System.Collections.Generic;
using System.Text;

namespace $safeprojectname$.Internal.General
{
    internal static class ActualizarInformacion
    {
        internal static void ActualizarCliente(ClienteTransaccion transaction)
        {
            Db_TransaccionalidadProcedure.spu_cliente(transaction);
        }
        internal static void ActualziarPersona(ClienteTransaccion transaction)
        {
            Db_TransaccionalidadProcedure.spu_persona(transaction);
        }

        internal static void ActualizarMovimiento(MovimientoTransaccion transaction)
        {
            Db_TransaccionalidadProcedure.spu_movimiento(transaction);
        }

        internal static void ActualizarCuenta(CuentaTransaccion transaction)
        {
            Db_TransaccionalidadProcedure.spu_cuenta(transaction);
        }
    }
}
