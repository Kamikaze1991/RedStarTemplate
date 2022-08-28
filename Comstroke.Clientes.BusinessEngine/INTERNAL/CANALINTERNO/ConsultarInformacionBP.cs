using $safeprojectname$.Internal.General;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace $safeprojectname$.Internal.CanalInterno
{
    internal static class ConsultarInformacionBP
    {
        internal static void ConsultaClientes(ClienteTransaccion transaction)
        {
            RecuperarInformacion.ConsultaClientes(transaction);
        }

        internal static void ConsultaCuenta(CuentaTransaccion transaction)
        {
            RecuperarInformacion.ConsultaCuentas(transaction);
        }

        internal static void ConsultaMovimientos(MovimientoTransaccion transaction)
        {
            RecuperarInformacion.ConsultaMovimientos(transaction);
        }

        internal static void ConsultaMovimientosFechas(MovimientoFechaTransaccion transaction)
        {
            RecuperarInformacion.ConsultaMovimientosFechas(transaction);
        }

        internal static void ConsultaTokenJwt(ClaveTransaccion transaction)
        {
            CuentaTransaccion cuentaTransaccion = new CuentaTransaccion();
            cuentaTransaccion.CuentaEntrada.IdCliente = 0;
            cuentaTransaccion.CuentaEntrada.IdCuenta = 0;
            cuentaTransaccion.CuentaEntrada.NumeroCuenta = transaction.UserName;
            cuentaTransaccion.CuentaEntrada.SaldoInicial = 0;
            cuentaTransaccion.CuentaEntrada.TipoCuenta = String.Empty;
            cuentaTransaccion.CuentaEntrada.Estado = String.Empty;
            
            RecuperarInformacion.ConsultaCuentas(cuentaTransaccion);

            if (!cuentaTransaccion.ListaCuenta.Any())
                transaction.Response.InternalResponseCode = 105070; //no existe la cuenta

            int idCliente = cuentaTransaccion.ListaCuenta.FirstOrDefault().IdCliente;

            ClienteTransaccion clienteTransaccion = new ClienteTransaccion();
            clienteTransaccion.ClienteEntrada.Edad = 0;
            clienteTransaccion.ClienteEntrada.Identificacion = String.Empty;
            clienteTransaccion.ClienteEntrada.IdPersona = 0;
            clienteTransaccion.ClienteEntrada.Nombre = String.Empty;
            clienteTransaccion.ClienteEntrada.IdCliente = idCliente;
            clienteTransaccion.ClienteEntrada.Telefono = String.Empty;
            clienteTransaccion.ClienteEntrada.Direccion = String.Empty;
            clienteTransaccion.ClienteEntrada.Estado = String.Empty;
            clienteTransaccion.ClienteEntrada.Password = transaction.Password;
            RecuperarInformacion.ConsultaClientes(clienteTransaccion);
            if (!clienteTransaccion.ListaCliente.Any())
                transaction.Response.InternalResponseCode = 105071; //password incorrecto
            RecuperarInformacion.ConsultaTokenJwt(transaction);
        }
    }
}
