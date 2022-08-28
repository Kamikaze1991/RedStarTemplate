using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using Comstroke.Global.ModelEngine.Transaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccionalidad;
using static Dapper.SqlMapper;
using $safeprojectname$.db_transaccionalidad;

namespace $safeprojectname$
{
    public class Db_TransaccionalidadProcedure
    {
        #region Persona
        public static void spi_persona(ClienteTransaccion clienteTransaccion)
        {
            using (IDbConnection connection = new SqlConnection(ConfigSettings.ConectionDB("Transaccionalidad")))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@i_pe_nombre", clienteTransaccion.ClienteEntrada.Nombre, DbType.String);
                dynamicParameters.Add("@i_pe_genero", clienteTransaccion.ClienteEntrada.Genero, DbType.String);
                dynamicParameters.Add("@i_pe_edad", clienteTransaccion.ClienteEntrada.Edad, DbType.Int32);
                dynamicParameters.Add("@i_pe_identificacion", clienteTransaccion.ClienteEntrada.Identificacion, DbType.String);
                dynamicParameters.Add("@i_pe_direccion", clienteTransaccion.ClienteEntrada.Direccion, DbType.String);
                dynamicParameters.Add("@i_pe_telefono", clienteTransaccion.ClienteEntrada.Telefono, DbType.String);
                dynamicParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                GridReader gridReader = connection.QueryMultiple("spi_persona", dynamicParameters, commandType: CommandType.StoredProcedure);
                int? intResultado = dynamicParameters.Get<int?>("@ReturnValue");

                if (intResultado == null || intResultado == 0)
                {
                    if (!gridReader.IsConsumed)
                    {
                        List<sps_cliente_result> lstResultado1 = gridReader.Read<sps_cliente_result>().ToList();
                        foreach (sps_cliente_result sps_cliente in lstResultado1)
                        {
                            Cliente objetoCliente = new Cliente()
                            {
                                Direccion = sps_cliente.pe_direccion,
                                Edad = sps_cliente.pe_edad,
                                FechaCreacion = sps_cliente.pe_fecha_creacion,
                                FechaModificacion = sps_cliente.pe_fecha_modificacion,
                                Genero = sps_cliente.pe_genero,
                                Identificacion = sps_cliente.pe_identificacion,
                                IdPersona = sps_cliente.pe_id_persona,
                                Nombre = sps_cliente.pe_nombre,
                                Telefono = sps_cliente.pe_telefono,
                                Estado = sps_cliente.cl_estado,
                                IdCliente = sps_cliente.cl_id_cliente,
                                Password = (sps_cliente.cl_password == null) ? String.Empty : sps_cliente.cl_password
                            };
                            clienteTransaccion.ListaCliente.Add(objetoCliente);
                        }
                    }
                }
                else
                    clienteTransaccion.Response.InternalResponseCode = intResultado.GetValueOrDefault();
            }
        }

        public static void spu_persona(ClienteTransaccion clienteTransaccion)
        {
            using (IDbConnection connection = new SqlConnection(ConfigSettings.ConectionDB("Transaccionalidad")))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@i_pe_id_persona", clienteTransaccion.ClienteEntrada.IdPersona, DbType.String);
                dynamicParameters.Add("@i_pe_nombre", clienteTransaccion.ClienteEntrada.Nombre, DbType.String);
                dynamicParameters.Add("@i_pe_genero", clienteTransaccion.ClienteEntrada.Genero, DbType.String);
                dynamicParameters.Add("@i_pe_edad", clienteTransaccion.ClienteEntrada.Edad, DbType.Int32);
                dynamicParameters.Add("@i_pe_identificacion", clienteTransaccion.ClienteEntrada.Identificacion, DbType.String);
                dynamicParameters.Add("@i_pe_direccion", clienteTransaccion.ClienteEntrada.Direccion, DbType.String);
                dynamicParameters.Add("@i_pe_telefono", clienteTransaccion.ClienteEntrada.Telefono, DbType.String);
                dynamicParameters.Add("@i_pe_borrar", clienteTransaccion.ClienteEntrada.Borrar, DbType.Int32);
                dynamicParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                connection.QueryMultiple("spu_persona", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        #endregion
        #region Cliente
        public static void spi_cliente(ClienteTransaccion clienteTransaccion)
        {
            using (IDbConnection connection = new SqlConnection(ConfigSettings.ConectionDB("Transaccionalidad")))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@i_cl_id_persona", clienteTransaccion.ClienteEntrada.IdPersona, DbType.Int32);
                dynamicParameters.Add("@i_cl_password", clienteTransaccion.ClienteEntrada.Password, DbType.String);
                dynamicParameters.Add("@i_cl_estado", clienteTransaccion.ClienteEntrada.Estado, DbType.String);
                dynamicParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                connection.QueryMultiple("spi_cliente", dynamicParameters, commandType: CommandType.StoredProcedure);
                int? intResultado = dynamicParameters.Get<int?>("@ReturnValue");
                if (intResultado!=null && intResultado != 0)
                    clienteTransaccion.Response.InternalResponseCode = intResultado.GetValueOrDefault();

            }
        }
        public static void spu_cliente(ClienteTransaccion clienteTransaccion)
        {
            using (IDbConnection connection = new SqlConnection(ConfigSettings.ConectionDB("Transaccionalidad")))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@i_cl_id_cliente", clienteTransaccion.ClienteEntrada.IdCliente, DbType.Int32);
                dynamicParameters.Add("@i_cl_id_persona", clienteTransaccion.ClienteEntrada.IdPersona, DbType.Int32);
                dynamicParameters.Add("@i_cl_password", clienteTransaccion.ClienteEntrada.Password, DbType.String);
                dynamicParameters.Add("@i_cl_estado", clienteTransaccion.ClienteEntrada.Estado, DbType.String);
                dynamicParameters.Add("@i_cl_borrar", clienteTransaccion.ClienteEntrada.Borrar, DbType.String);
                dynamicParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                connection.QueryMultiple("spu_cliente", dynamicParameters, commandType: CommandType.StoredProcedure);
                int? intResultado = dynamicParameters.Get<int?>("@ReturnValue");
                if (intResultado != null && intResultado != 0)
                    clienteTransaccion.Response.InternalResponseCode = intResultado.GetValueOrDefault();
            }
        }

        public static void sps_cliente(ClienteTransaccion clienteTransaccion)
        {
            using (IDbConnection connection = new SqlConnection(ConfigSettings.ConectionDB("Transaccionalidad")))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@i_cl_id_cliente", clienteTransaccion.ClienteEntrada.IdCliente, DbType.Int32);
                dynamicParameters.Add("@i_cl_identificacion", clienteTransaccion.ClienteEntrada.Identificacion, DbType.String);
                dynamicParameters.Add("@i_cl_id_persona", clienteTransaccion.ClienteEntrada.IdPersona, DbType.Int32);
                dynamicParameters.Add("@i_cl_nombre", clienteTransaccion.ClienteEntrada.Nombre, DbType.String);
                dynamicParameters.Add("@i_cl_password", clienteTransaccion.ClienteEntrada.Password, DbType.String);
                dynamicParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                GridReader gridReader = connection.QueryMultiple("sps_cliente", dynamicParameters, commandType: CommandType.StoredProcedure);
                int? intResultado = dynamicParameters.Get<int?>("@ReturnValue");

                if (intResultado == null || intResultado == 0)
                {
                    if (!gridReader.IsConsumed)
                    {
                        List<sps_cliente_result> lstResultado1 = gridReader.Read<sps_cliente_result>().ToList();
                        foreach (sps_cliente_result sps_cliente in lstResultado1)
                        {
                            Cliente objetoCliente = new Cliente()
                            {
                                Direccion = sps_cliente.pe_direccion,
                                Edad = sps_cliente.pe_edad,
                                FechaCreacion = sps_cliente.pe_fecha_creacion,
                                FechaModificacion = sps_cliente.pe_fecha_modificacion,
                                Genero = sps_cliente.pe_genero,
                                Identificacion = sps_cliente.pe_identificacion,
                                IdPersona = sps_cliente.pe_id_persona,
                                Nombre = sps_cliente.pe_nombre,
                                Telefono = sps_cliente.pe_telefono,
                                Estado = sps_cliente.cl_estado,
                                IdCliente = sps_cliente.cl_id_cliente,
                                Password = (sps_cliente.cl_password == null) ? String.Empty : sps_cliente.cl_password
                            };
                            clienteTransaccion.ListaCliente.Add(objetoCliente);
                        }
                    }
                }
                else
                    clienteTransaccion.Response.InternalResponseCode = intResultado.GetValueOrDefault();
            }
        }
        #endregion

        #region Cuenta
        public static void spi_cuenta(CuentaTransaccion transaccion)
        {
            using (IDbConnection connection = new SqlConnection(ConfigSettings.ConectionDB("Transaccionalidad")))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@i_cu_id_cliente", transaccion.CuentaEntrada.IdCliente, DbType.Int32);
                dynamicParameters.Add("@i_cu_numero_cuenta", transaccion.CuentaEntrada.NumeroCuenta, DbType.String);
                dynamicParameters.Add("@i_cu_tipo_cuenta", transaccion.CuentaEntrada.TipoCuenta, DbType.String);
                dynamicParameters.Add("@i_cu_saldo_inicial", transaccion.CuentaEntrada.SaldoInicial, DbType.Decimal);
                dynamicParameters.Add("@i_cu_estado", transaccion.CuentaEntrada.Estado, DbType.String);
                dynamicParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                connection.QueryMultiple("spi_cuenta", dynamicParameters, commandType: CommandType.StoredProcedure);
                int? intResultado = dynamicParameters.Get<int?>("@ReturnValue");
                if (intResultado != null && intResultado != 0)
                    transaccion.Response.InternalResponseCode = intResultado.GetValueOrDefault();
            }
        }

        public static void spu_cuenta(CuentaTransaccion transaccion)
        {
            using (IDbConnection connection = new SqlConnection(ConfigSettings.ConectionDB("Transaccionalidad")))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@i_cu_id_cuenta", transaccion.CuentaEntrada.IdCuenta, DbType.Int32);
                dynamicParameters.Add("@i_cu_id_cliente", transaccion.CuentaEntrada.IdCliente, DbType.Int32);
                dynamicParameters.Add("@i_cu_tipo_cuenta", transaccion.CuentaEntrada.TipoCuenta, DbType.String);
                dynamicParameters.Add("@i_cu_numero_cuenta", transaccion.CuentaEntrada.NumeroCuenta, DbType.String);
                dynamicParameters.Add("@i_cu_saldo_inicial", transaccion.CuentaEntrada.SaldoInicial, DbType.Decimal);
                dynamicParameters.Add("@i_cu_estado", transaccion.CuentaEntrada.Estado, DbType.String);
                dynamicParameters.Add("@i_cu_borrar", transaccion.CuentaEntrada.Borrar, DbType.Int32);
                dynamicParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                connection.QueryMultiple("spu_cuenta", dynamicParameters, commandType: CommandType.StoredProcedure);
                int? intResultado = dynamicParameters.Get<int?>("@ReturnValue");
                if (intResultado != null && intResultado != 0)
                    transaccion.Response.InternalResponseCode = intResultado.GetValueOrDefault();
            }
        }

        public static void sps_cuenta(CuentaTransaccion transaccion)
        {
            using (IDbConnection connection = new SqlConnection(ConfigSettings.ConectionDB("Transaccionalidad")))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@i_cu_id_cuenta", transaccion.CuentaEntrada.IdCuenta, DbType.Int32);
                dynamicParameters.Add("@i_cu_id_cliente", transaccion.CuentaEntrada.IdCliente, DbType.Int32);
                dynamicParameters.Add("@i_cu_tipo_cuenta", transaccion.CuentaEntrada.TipoCuenta, DbType.String);
                dynamicParameters.Add("@i_cu_numero_cuenta", transaccion.CuentaEntrada.NumeroCuenta, DbType.String);
                dynamicParameters.Add("@i_cu_saldo_inicial", transaccion.CuentaEntrada.SaldoInicial, DbType.Decimal);
                dynamicParameters.Add("@i_cu_estado", transaccion.CuentaEntrada.Estado, DbType.String);
                dynamicParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                GridReader gridReader = connection.QueryMultiple("sps_cuenta", dynamicParameters, commandType: CommandType.StoredProcedure);
                int? intResultado = dynamicParameters.Get<int?>("@ReturnValue");

                if (intResultado == null || intResultado == 0)
                {
                    if (!gridReader.IsConsumed)
                    {
                        List<sps_cuenta_result> lstResultado1 = gridReader.Read<sps_cuenta_result>().ToList();
                        foreach (sps_cuenta_result sps_cuenta in lstResultado1)
                        {
                            Cuenta objetoCuenta = new Cuenta()
                            {
                                Estado = sps_cuenta.cu_estado,
                                FechaCreacion = sps_cuenta.cu_fecha_creacion,
                                FechaModificacion = sps_cuenta.cu_fecha_modificacion,
                                IdCliente = sps_cuenta.cu_id_cliente,
                                IdCuenta = sps_cuenta.cu_id_cuenta,
                                NumeroCuenta = sps_cuenta.cu_numero_cuenta,
                                SaldoInicial = sps_cuenta.cu_saldo_inicial,
                                TipoCuenta = sps_cuenta.cu_tipo_cuenta
                            };
                            transaccion.ListaCuenta.Add(objetoCuenta);
                        }
                    }
                }
                else
                    transaccion.Response.InternalResponseCode = intResultado.GetValueOrDefault();
            }
        }
        #endregion

        #region Movimiento
        public static void spi_movimiento(MovimientoTransaccion transaccion)
        {
            using (IDbConnection connection = new SqlConnection(ConfigSettings.ConectionDB("Transaccionalidad")))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@i_mo_id_cuenta", transaccion.MovimientoEntrada.IdCuenta, DbType.Int32);
                dynamicParameters.Add("@i_mo_tipo_movimiento", transaccion.MovimientoEntrada.TipoMovimiento, DbType.String);
                dynamicParameters.Add("@i_mo_valor", transaccion.MovimientoEntrada.Valor, DbType.Decimal);
                dynamicParameters.Add("@i_mo_saldo", transaccion.MovimientoEntrada.Saldo, DbType.Decimal);
                dynamicParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                connection.QueryMultiple("spi_movimiento", dynamicParameters, commandType: CommandType.StoredProcedure);
                int? intResultado = dynamicParameters.Get<int?>("@ReturnValue");
                if (intResultado != null && intResultado != 0)
                    transaccion.Response.InternalResponseCode = intResultado.GetValueOrDefault();
            }
        }

        public static void spu_movimiento(MovimientoTransaccion transaccion)
        {
            using (IDbConnection connection = new SqlConnection(ConfigSettings.ConectionDB("Transaccionalidad")))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@i_mo_id_movimiento", transaccion.MovimientoEntrada.IdMovimiento, DbType.Int32);
                dynamicParameters.Add("@i_mo_id_cuenta", transaccion.MovimientoEntrada.IdCuenta, DbType.Int32);
                dynamicParameters.Add("@i_mo_tipo_movimiento", transaccion.MovimientoEntrada.TipoMovimiento, DbType.String);
                dynamicParameters.Add("@i_mo_valor", transaccion.MovimientoEntrada.Valor, DbType.Decimal);
                dynamicParameters.Add("@i_mo_saldo", transaccion.MovimientoEntrada.Saldo, DbType.Decimal);
                dynamicParameters.Add("@i_mo_borrar", transaccion.MovimientoEntrada.Borrar, DbType.Int32);
                dynamicParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                connection.QueryMultiple("spu_movimiento", dynamicParameters, commandType: CommandType.StoredProcedure);
                int? intResultado = dynamicParameters.Get<int?>("@ReturnValue");
                if (intResultado != null && intResultado != 0)
                    transaccion.Response.InternalResponseCode = intResultado.GetValueOrDefault();
            }
        }

        public static void sps_movimiento(MovimientoTransaccion transaccion)
        {
            using (IDbConnection connection = new SqlConnection(ConfigSettings.ConectionDB("Transaccionalidad")))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@i_mo_id_movimiento", transaccion.MovimientoEntrada.IdMovimiento, DbType.Int32);
                dynamicParameters.Add("@i_mo_id_cuenta", transaccion.MovimientoEntrada.IdCuenta, DbType.Int32);
                dynamicParameters.Add("@i_mo_tipo_movimiento", transaccion.MovimientoEntrada.TipoMovimiento, DbType.String);
                dynamicParameters.Add("@i_mo_valor", transaccion.MovimientoEntrada.Valor, DbType.Decimal);
                dynamicParameters.Add("@i_mo_saldo", transaccion.MovimientoEntrada.Saldo, DbType.Decimal);
                dynamicParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                GridReader gridReader = connection.QueryMultiple("sps_movimiento", dynamicParameters, commandType: CommandType.StoredProcedure);
                int? intResultado = dynamicParameters.Get<int?>("@ReturnValue");

                if (intResultado == null || intResultado == 0)
                {
                    if (!gridReader.IsConsumed)
                    {
                        List<sps_movimiento_result> lstResultado1 = gridReader.Read<sps_movimiento_result>().ToList();
                        foreach (sps_movimiento_result sps_movimiento in lstResultado1)
                        {
                            Movimiento objetoMovimiento = new Movimiento()
                            {
                                FechaCreacion = sps_movimiento.mo_fecha_creacion,
                                FechaModificacion = sps_movimiento.mo_fecha_modificacion,
                                IdCuenta = sps_movimiento.mo_id_cuenta,
                                IdMovimiento = sps_movimiento.mo_id_movimiento,
                                Saldo = sps_movimiento.mo_saldo,
                                TipoMovimiento = sps_movimiento.mo_tipo_movimiento,
                                Valor = sps_movimiento.mo_valor
                            };
                            transaccion.ListaMovimiento.Add(objetoMovimiento);
                        }
                    }
                }
                else
                    transaccion.Response.InternalResponseCode = intResultado.GetValueOrDefault();
            }
        }

        public static void sps_movimiento_fechas(MovimientoFechaTransaccion transaccion)
        {
            using (IDbConnection connection = new SqlConnection(ConfigSettings.ConectionDB("Transaccionalidad")))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@i_mo_fecha_inicial", transaccion.FechaInicial, DbType.DateTime);
                dynamicParameters.Add("@i_mo_fecha_final", transaccion.FechaFinal, DbType.DateTime);
                dynamicParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                GridReader gridReader = connection.QueryMultiple("sps_movimiento_fechas", dynamicParameters, commandType: CommandType.StoredProcedure);
                int? intResultado = dynamicParameters.Get<int?>("@ReturnValue");

                if (intResultado == null || intResultado == 0)
                {
                    if (!gridReader.IsConsumed)
                    {
                        List<sps_movimiento_fechas_result> lstResultado1 = gridReader.Read<sps_movimiento_fechas_result>().ToList();
                        foreach (sps_movimiento_fechas_result sps_movimiento in lstResultado1)
                        {
                            MovimientoFecha objetoMovimiento = new MovimientoFecha()
                            {
                                Cliente= sps_movimiento.pe_nombre,
                                Estado= sps_movimiento.cu_estado,
                                Fecha= sps_movimiento.mo_fecha_creacion,
                                Movimiento= sps_movimiento.mo_valor,
                                NumeroCuenta= sps_movimiento.cu_numero_cuenta,
                                SaldoDisponible= sps_movimiento.mo_saldo,
                                SaldoInicial= sps_movimiento.cu_saldo_inicial,
                                Tipo= sps_movimiento.cu_tipo_cuenta
                            };
                            transaccion.Movimientos.Add(objetoMovimiento);
                        }
                    }
                }
                else
                    transaccion.Response.InternalResponseCode = intResultado.GetValueOrDefault();
            }
        }
        #endregion

    }
}
