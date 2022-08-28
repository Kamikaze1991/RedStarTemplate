using $safeprojectname$.Internal.General;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccionalidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace $safeprojectname$.Internal.CanalInterno
{
    internal static class InsertarInformacionBP
    {
        internal static void IngresarCliente(ClienteTransaccion transaction) {
            InsertarInformacion.InsertarPersona(transaction);
            transaction.ClienteEntrada.IdPersona = transaction.ListaCliente.FirstOrDefault().IdPersona;
            InsertarInformacion.InsertarCliente(transaction);
        }

        internal static void IngresarPersona(ClienteTransaccion transaction)
        {
            InsertarInformacion.InsertarPersona(transaction);
            Cliente datosClienteEntrada = transaction.ClienteEntrada;
            transaction.ClienteEntrada = new Cliente();
            transaction.ClienteEntrada.Identificacion = datosClienteEntrada.Identificacion;
            RecuperarInformacion.ConsultaClientes(transaction);
            datosClienteEntrada.IdPersona = transaction.ListaCliente[0].IdPersona;
            InsertarInformacion.InsertarCliente(transaction);
        }

        internal static void IngresarCuenta(CuentaTransaccion  transaction)
        {
            InsertarInformacion.InsertarCuenta(transaction);
        }

        internal static void IngresarMovimiento(MovimientoTransaccion transaction)
        {
            //recuperamos la cuenta
            CuentaTransaccion cuentaActual = new CuentaTransaccion();
            cuentaActual.CuentaEntrada = new Cuenta()
            {
                IdCuenta=transaction.MovimientoEntrada.IdCuenta,
                Estado=String.Empty,
                NumeroCuenta=String.Empty,
                TipoCuenta=String.Empty
            };
            RecuperarInformacion.ConsultaCuentas(cuentaActual);
            Cuenta cuenta = cuentaActual.ListaCuenta.FirstOrDefault();



            //recuperamos los movimientos de dicha cuenta y sumamos el total
            MovimientoFechaTransaccion movimientoFechaTransaccion = new MovimientoFechaTransaccion();
            movimientoFechaTransaccion.FechaInicial = DateTime.Now;
            movimientoFechaTransaccion.FechaFinal = DateTime.Now.AddDays(1);
            RecuperarInformacion.ConsultaMovimientosFechas(movimientoFechaTransaccion);
            decimal totalMovimientoDiario = movimientoFechaTransaccion.Movimientos.Sum(x => x.Movimiento);
            //comparamos si no se sobrepaso el limite diario de 1000
            if(totalMovimientoDiario>=1000)
                transaction.Response.InternalResponseCode = 105068; //error se supero el limite diario

            //2 evaluamos si el saldo de la cuenta es negativo
            if (cuentaActual.ListaCuenta.FirstOrDefault().SaldoInicial<=0 && transaction.MovimientoEntrada.Valor<0)
                transaction.Response.InternalResponseCode = 105067; //error de cuenta sin fondos
            //realizamos el proceso de ingreso y actualizacion
            decimal saldoActual = cuentaActual.ListaCuenta.FirstOrDefault().SaldoInicial;
            decimal nuevoSaldo = saldoActual + transaction.MovimientoEntrada.Valor;

            if(nuevoSaldo<0)
                transaction.Response.InternalResponseCode = 105067; //error de cuenta sin fondos
            cuenta.SaldoInicial = nuevoSaldo;
            cuentaActual.CuentaEntrada = cuenta;
            transaction.MovimientoEntrada.Saldo = nuevoSaldo;
            ActualizarInformacion.ActualizarCuenta(cuentaActual);
            InsertarInformacion.InsertarMovimiento(transaction);
            
        }
    }
}
