using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;

namespace AccesoDatos.DataBase
{
    public class ClsDataBase
    {
        #region Variables Privadas
        private SqlConnection _objSqlConnection;
        private SqlDataAdapter _objSqlDataAdapter;
        private SqlCommand _objSqlCommand;

        private MySqlConnection _objMySqlConnection;
        private MySqlDataAdapter _objMySqlDataAdapter;
        private MySqlCommand _objMySqlCommand;

        private DataSet _dsResultados;
        private DataTable _dtParametros;
        private string _nombreTabla, _nombreSP, _mensajeErrorDB, _valorScalar, _nombreDB;
        private bool _scalar, _tipoConexion;
        #endregion

        #region Variables Publicas
        public SqlConnection ObjSqlConnection { get => _objSqlConnection; set => _objSqlConnection = value; }
        public SqlDataAdapter ObjSqlDataAdapter { get => _objSqlDataAdapter; set => _objSqlDataAdapter = value; }
        public SqlCommand ObjSqlCommand { get => _objSqlCommand; set => _objSqlCommand = value; }

        public MySqlConnection ObjMySqlConnection { get => _objMySqlConnection; set => _objMySqlConnection = value; }
        public MySqlDataAdapter ObjMySqlDataAdapter { get => _objMySqlDataAdapter; set => _objMySqlDataAdapter = value; }
        public MySqlCommand ObjMySqlCommand { get => _objMySqlCommand; set => _objMySqlCommand = value; }

        public DataSet DsResultados { get => _dsResultados; set => _dsResultados = value; }
        public DataTable DtParametros { get => _dtParametros; set => _dtParametros = value; }
        public string NombreTabla { get => _nombreTabla; set => _nombreTabla = value; }
        public string NombreSP { get => _nombreSP; set => _nombreSP = value; }
        public string MensajeErrorDB { get => _mensajeErrorDB; set => _mensajeErrorDB = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public string NombreDB { get => _nombreDB; set => _nombreDB = value; }
        public bool Scalar { get => _scalar; set => _scalar = value; }
        public bool TipoConexion { get => _tipoConexion; set => _tipoConexion = value; }
        #endregion

        #region Constructores
        public ClsDataBase()
        {
            DtParametros = new DataTable("SpParametros");
            DtParametros.Columns.Add("Nombre");
            DtParametros.Columns.Add("TipoDato");
            DtParametros.Columns.Add("Valor");

            NombreDB = "DB_HOTEL";
            TipoConexion = true;
        }
        #endregion

        #region Metodos Privados
        private void CrearConexionBaseDatos(ref ClsDataBase ObjDataBase)
        {
            switch (ObjDataBase.NombreDB)
            {
                case "DB_HOTEL":
                    if (ObjDataBase.TipoConexion)
                    {
                        ObjDataBase.ObjMySqlConnection = new MySqlConnection(Properties.Settings.Default.ConexionMySQL);
                    }
                    else
                    {
                        ObjDataBase.ObjSqlConnection = new SqlConnection(Properties.Settings.Default.ConexionSQL);
                    }
                    break;
                default:
                    break;
            }
        }

        private void ValidarConexionBaseDatos(ref ClsDataBase ObjDataBase)
        {
            if (ObjDataBase.TipoConexion)
            {
                if (ObjDataBase.ObjMySqlConnection.State == ConnectionState.Closed)
                {
                    ObjDataBase.ObjMySqlConnection.Open();
                }
                else
                {
                    ObjDataBase.ObjMySqlConnection.Close();
                    ObjDataBase.ObjMySqlConnection.Dispose();
                }
            }
            else
            {
                if (ObjDataBase.ObjSqlConnection.State == ConnectionState.Closed)
                {
                    ObjDataBase.ObjSqlConnection.Open();
                }
                else
                {
                    ObjDataBase.ObjSqlConnection.Close();
                    ObjDataBase.ObjSqlConnection.Dispose();
                }
            }
        }

        private void AgregarParametros(ref ClsDataBase ObjDataBase)
        {
            if (ObjDataBase.DtParametros != null)
            {
                SqlDbType TipoDatoSQL = new SqlDbType();
                MySqlDbType TipoDatoMySQL = new MySqlDbType();
                bool minusculas = false;

                foreach (DataRow item in ObjDataBase.DtParametros.Rows)
                {
                    switch (item[1])
                    {
                        case "1":
                            TipoDatoSQL = SqlDbType.Bit;
                            TipoDatoMySQL = MySqlDbType.Bit;
                            minusculas = true;
                            break;
                        case "2":
                            TipoDatoSQL = SqlDbType.TinyInt;
                            TipoDatoMySQL = MySqlDbType.Int16;
                            break;
                        case "3":
                            TipoDatoSQL = SqlDbType.SmallInt;
                            TipoDatoMySQL = MySqlDbType.Int24;
                            break;
                        case "4":
                            TipoDatoSQL = SqlDbType.Int;
                            TipoDatoMySQL = MySqlDbType.Int32;
                            break;
                        case "5":
                            TipoDatoSQL = SqlDbType.BigInt;
                            TipoDatoMySQL = MySqlDbType.Int64;
                            break;
                        case "6":
                            TipoDatoSQL = SqlDbType.Decimal;
                            TipoDatoMySQL = MySqlDbType.Decimal;
                            break;
                        case "7":
                            TipoDatoSQL = SqlDbType.SmallMoney;
                            TipoDatoMySQL = MySqlDbType.Decimal;
                            break;
                        case "8":
                            TipoDatoSQL = SqlDbType.Money;
                            TipoDatoMySQL = MySqlDbType.Decimal;
                            break;
                        case "9":
                            TipoDatoSQL = SqlDbType.Float;
                            TipoDatoMySQL = MySqlDbType.Float;
                            break;
                        case "10":
                            TipoDatoSQL = SqlDbType.Real;
                            TipoDatoMySQL = MySqlDbType.Float;
                            break;
                        case "11":
                            TipoDatoSQL = SqlDbType.Date;
                            TipoDatoMySQL = MySqlDbType.Date;
                            break;
                        case "12":
                            TipoDatoSQL = SqlDbType.Time;
                            TipoDatoMySQL = MySqlDbType.Time;
                            break;
                        case "13":
                            TipoDatoSQL = SqlDbType.SmallDateTime;
                            TipoDatoMySQL = MySqlDbType.Timestamp;
                            break;
                        case "14":
                            TipoDatoSQL = SqlDbType.DateTime;
                            TipoDatoMySQL = MySqlDbType.Timestamp;
                            break;
                        case "15":
                            TipoDatoSQL = SqlDbType.Char;
                            TipoDatoMySQL = MySqlDbType.VarChar;
                            break;
                        case "16":
                            TipoDatoSQL = SqlDbType.NChar;
                            TipoDatoMySQL = MySqlDbType.VarChar;
                            break;
                        case "17":
                            TipoDatoSQL = SqlDbType.VarChar;
                            TipoDatoMySQL = MySqlDbType.VarChar;
                            break;
                        case "18":
                            TipoDatoSQL = SqlDbType.NVarChar;
                            TipoDatoMySQL = MySqlDbType.Blob;
                            break;
                        default:
                            break;
                    }

                    if (ObjDataBase.Scalar)
                    {
                        if (item[2].ToString().Equals(string.Empty))
                        {
                            if (ObjDataBase.TipoConexion)
                            {
                                ObjDataBase.ObjMySqlCommand.Parameters.Add(item[0].ToString(), TipoDatoMySQL).Value = DBNull.Value;
                            } else
                            {
                                ObjDataBase.ObjSqlCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = DBNull.Value;
                            }

                        }
                        else
                        {
                            if (ObjDataBase.TipoConexion)
                            {
                                if (minusculas)
                                {
                                    ObjDataBase.ObjMySqlCommand.Parameters.Add(item[0].ToString(), TipoDatoMySQL).Value = item[2].ToString().ToLower();
                                }
                                else
                                {
                                    ObjDataBase.ObjMySqlCommand.Parameters.Add(item[0].ToString(), TipoDatoMySQL).Value = item[2].ToString();
                                }
                            }
                            else
                            {
                                if (minusculas)
                                {
                                    ObjDataBase.ObjSqlCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = item[2].ToString().ToLower();
                                }
                                else
                                {
                                    ObjDataBase.ObjSqlCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = item[2].ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (item[2].ToString().Equals(string.Empty))
                        {
                            if (ObjDataBase.TipoConexion)
                            {
                                ObjDataBase.ObjMySqlDataAdapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoMySQL).Value = DBNull.Value;
                            }
                            else
                            {
                                ObjDataBase.ObjSqlDataAdapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = DBNull.Value;
                            }
                        }
                        else
                        {
                            if (ObjDataBase.TipoConexion)
                            {
                                if (minusculas)
                                {
                                    ObjDataBase.ObjMySqlDataAdapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoMySQL).Value = item[2].ToString().ToLower();
                                }
                                else
                                {
                                    ObjDataBase.ObjMySqlDataAdapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoMySQL).Value = item[2].ToString();
                                }
                            }
                            else
                            {
                                if (minusculas)
                                {
                                    ObjDataBase.ObjSqlDataAdapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = item[2].ToString().ToLower();
                                }
                                else
                                {
                                    ObjDataBase.ObjSqlDataAdapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = item[2].ToString();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void PrepararConexionBaseDatos(ref ClsDataBase ObjDataBase)
        {
            CrearConexionBaseDatos(ref ObjDataBase);
            ValidarConexionBaseDatos(ref ObjDataBase);
        }

        private void EjecutarDataAdapter(ref ClsDataBase ObjDataBase)
        {
            try
            {
                PrepararConexionBaseDatos(ref ObjDataBase);

                if (ObjDataBase.TipoConexion)
                {
                    ObjDataBase.ObjMySqlDataAdapter = new MySqlDataAdapter(ObjDataBase.NombreSP, ObjDataBase.ObjMySqlConnection);
                    ObjDataBase.ObjMySqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    AgregarParametros(ref ObjDataBase);
                    ObjDataBase.DsResultados = new DataSet();
                    ObjDataBase.ObjMySqlDataAdapter.Fill(ObjDataBase.DsResultados, ObjDataBase.NombreTabla);
                }
                else
                {
                    ObjDataBase.ObjSqlDataAdapter = new SqlDataAdapter(ObjDataBase.NombreSP, ObjDataBase.ObjSqlConnection);
                    ObjDataBase.ObjSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    AgregarParametros(ref ObjDataBase);
                    ObjDataBase.DsResultados = new DataSet();
                    ObjDataBase.ObjSqlDataAdapter.Fill(ObjDataBase.DsResultados, ObjDataBase.NombreTabla);
                }
            }
            catch (Exception ex)
            {
                 ObjDataBase.MensajeErrorDB = ex.Message.ToString();
            } 
            finally
            {
                if (ObjDataBase.TipoConexion)
                {
                    if (ObjMySqlConnection.State == ConnectionState.Open)
                    {
                        ValidarConexionBaseDatos(ref ObjDataBase);
                    }
                }
                else
                {
                    if (ObjSqlConnection.State == ConnectionState.Open)
                    {
                        ValidarConexionBaseDatos(ref ObjDataBase);
                    }
                }
            }
        }

        private void EjecutarCommand(ref ClsDataBase ObjDataBase)
        {
            try
            {
                PrepararConexionBaseDatos(ref ObjDataBase);
                if (ObjDataBase.TipoConexion)
                {
                    ObjDataBase.ObjMySqlCommand = new MySqlCommand(ObjDataBase.NombreSP, ObjDataBase.ObjMySqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    AgregarParametros(ref ObjDataBase);
                    if (ObjDataBase.Scalar)
                    {
                        ObjDataBase.ValorScalar = ObjDataBase.ObjMySqlCommand.ExecuteScalar().ToString().Trim();
                    }
                    else
                    {
                        ObjDataBase.ObjSqlCommand.ExecuteNonQuery();
                    }
                }
                else
                {
                    ObjDataBase.ObjSqlCommand = new SqlCommand(ObjDataBase.NombreSP, ObjDataBase.ObjSqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    AgregarParametros(ref ObjDataBase);
                    if (ObjDataBase.Scalar)
                    {
                        ObjDataBase.ValorScalar = ObjDataBase.ObjSqlCommand.ExecuteScalar().ToString().Trim();
                    }
                    else
                    {
                        ObjDataBase.ObjSqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ObjDataBase.MensajeErrorDB = ex.Message.ToString();
            }
            finally
            {
                if (ObjSqlConnection.State == ConnectionState.Open)
                {
                    ValidarConexionBaseDatos(ref ObjDataBase);
                }
            }
        }
        #endregion

        #region Metodos Publicos
        public void CRUD(ref ClsDataBase ObjDataBase)
        {
            if (ObjDataBase.Scalar)
            {
                EjecutarCommand(ref ObjDataBase);
            }
            else
            {
                EjecutarDataAdapter(ref ObjDataBase);
            }
        }
        #endregion

    }
}
