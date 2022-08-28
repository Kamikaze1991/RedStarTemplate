using Comstroke.$ext_safeprojectname$.DataEngine;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using System;
using System.Collections.Generic;
using System.Text;

namespace $safeprojectname$.Internal.General
{
    internal static class InsertarInformacion
    {
        internal static void InsertarCliente(ClienteTransaccion transaction)
        {
            Db_TransaccionalidadProcedure.spi_cliente(transaction);
        }

        internal static void InsertarPersona(ClienteTransaccion transaction)
        {
            Db_TransaccionalidadProcedure.spi_persona(transaction);
        }

        internal static void InsertarCuenta(CuentaTransaccion transaction)
        {
            Db_TransaccionalidadProcedure.spi_cuenta(transaction);
        }

        internal static void InsertarMovimiento(MovimientoTransaccion transaction)
        {
            Db_TransaccionalidadProcedure.spi_movimiento(transaction);
        }
    }
}
