using $safeprojectname$.Internal.General;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccionalidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace $safeprojectname$.Internal.CanalInterno
{
    internal static class ActualizarInformacionBP
    {
        internal static void ActualizarCliente(ClienteTransaccion transaction)
        {
            
            Cliente datosClienteEntrada = transaction.ClienteEntrada;
            transaction.ClienteEntrada = new Cliente();
            transaction.ClienteEntrada.Edad = 0;
            transaction.ClienteEntrada.Telefono = String.Empty;
            transaction.ClienteEntrada.IdCliente = 0;
            transaction.ClienteEntrada.Direccion = String.Empty;
            transaction.ClienteEntrada.Estado = String.Empty;
            transaction.ClienteEntrada.Genero = String.Empty;
            transaction.ClienteEntrada.IdPersona = 0;
            transaction.ClienteEntrada.Nombre = String.Empty;
            transaction.ClienteEntrada.Password = String.Empty;
            transaction.ClienteEntrada.Identificacion = datosClienteEntrada.Identificacion;
            RecuperarInformacion.ConsultaClientes(transaction);
            datosClienteEntrada.IdPersona = transaction.ListaCliente[0].IdPersona;
            datosClienteEntrada.IdCliente = transaction.ListaCliente[0].IdCliente;
            transaction.ClienteEntrada = datosClienteEntrada;
            ActualizarInformacion.ActualziarPersona(transaction);
            ActualizarInformacion.ActualizarCliente(transaction);
        }

        internal static void ActualizarCuenta(CuentaTransaccion transaction)
        {
            Cuenta objCuentaTemporal = transaction.CuentaEntrada;
            transaction.CuentaEntrada = new Cuenta()
            {
                Estado = string.Empty,
                IdCliente = 0,
                IdCuenta = objCuentaTemporal.IdCuenta,
                NumeroCuenta = objCuentaTemporal.NumeroCuenta,
                SaldoInicial = 0,
                TipoCuenta = string.Empty
            };
            RecuperarInformacion.ConsultaCuentas(transaction);
            int idCuentaConsultada = transaction.ListaCuenta.FirstOrDefault().IdCuenta;
            transaction.CuentaEntrada = objCuentaTemporal;
            transaction.CuentaEntrada.IdCuenta = idCuentaConsultada;
            ActualizarInformacion.ActualizarCuenta(transaction);
        }

        internal static void ActualizarMovimiento(MovimientoTransaccion transaction)
        {
            Movimiento objMovimientoTemporal = transaction.MovimientoEntrada;
            transaction.MovimientoEntrada = new Movimiento()
            {
                IdCuenta = 0,
                IdMovimiento = objMovimientoTemporal.IdMovimiento,
                Saldo = 0,
                TipoMovimiento = string.Empty,
                Valor = 0
            };
            RecuperarInformacion.ConsultaMovimientos(transaction);
            int idMovimientoConsultado = transaction.ListaMovimiento.FirstOrDefault().IdMovimiento;
            transaction.MovimientoEntrada = objMovimientoTemporal;
            transaction.MovimientoEntrada.IdCuenta = idMovimientoConsultado;
            ActualizarInformacion.ActualizarMovimiento(transaction);
        }
    }
}
