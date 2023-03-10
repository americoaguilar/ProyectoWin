using AccesoDatos.DataBase;
using Entidades.UbigeoZona;
using System;
using System.Data;

namespace LogicaNegocios.UbigeoZonas
{
    public class ClsUbigeoZonaLn
    {
        #region Variables Privadas
        private ClsDataBase ObjDataBase = null;
        #endregion

        #region Metodo Index
        public void Index(ref ClsUbigeoZona ObjUbigeoZona)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoZona",
                NombreSP = "sp_UbigeoZona_Index",
                Scalar = false
            };

            Ejecutar(ref ObjUbigeoZona);
        }
        #endregion

        #region CRUD
        public void Create(ref ClsUbigeoZona ObjUbigeoZona)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoZona",
                NombreSP = "sp_UbigeoZona_Create",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oDescripcion", "17", ObjUbigeoZona.Descripcion);
            ObjDataBase.DtParametros.Rows.Add(@"@oEstado", "4", (ObjUbigeoZona.Estado == true ?1 :0));

            Ejecutar(ref ObjUbigeoZona);
        }

        public void Read(ref ClsUbigeoZona ObjUbigeoZona)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoZona",
                NombreSP = "sp_UbigeoZona_Read",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oIdUbigeoZona", "4", ObjUbigeoZona.IdUbigeoZona);

            Ejecutar(ref ObjUbigeoZona);
        }

        public void Update(ref ClsUbigeoZona ObjUbigeoZona)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoZona",
                NombreSP = "sp_UbigeoZona_Update",
                Scalar = false
            };
            
            ObjDataBase.DtParametros.Rows.Add(@"@oIdUbigeoZona", "4", ObjUbigeoZona.IdUbigeoZona);
            ObjDataBase.DtParametros.Rows.Add(@"@oDescripcion", "17", ObjUbigeoZona.Descripcion);
            ObjDataBase.DtParametros.Rows.Add(@"@oEstado", "4", (ObjUbigeoZona.Estado == true ? 1 : 0));

            Ejecutar(ref ObjUbigeoZona);
        }

        public void Delete(ref ClsUbigeoZona ObjUbigeoZona)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoZona",
                NombreSP = "sp_UbigeoZona_Delete",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oIdUbigeoZona", "4", ObjUbigeoZona.IdUbigeoZona);

            Ejecutar(ref ObjUbigeoZona);
        }
        #endregion

        #region Metodo Privado
        private void Ejecutar(ref ClsUbigeoZona ObjUbigeoZona)
        {
            ObjDataBase.CRUD(ref ObjDataBase);

            if (ObjDataBase.MensajeErrorDB == null)
            {
                if (ObjDataBase.Scalar)
                {
                    ObjUbigeoZona.ValorScalar = ObjDataBase.ValorScalar;
                }
                else
                {
                    ObjUbigeoZona.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    if (ObjUbigeoZona.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in ObjUbigeoZona.DtResultados.Rows)
                        {
                            ObjUbigeoZona.IdUbigeoZona = item["IdUbigeoZona"].ToString();
                            ObjUbigeoZona.Descripcion = item["Descripcion"].ToString();
                            ObjUbigeoZona.Estado = Convert.ToBoolean(item["Estado"]);
                        }
                    }
                }
            }
            else
            {
                ObjUbigeoZona.MensajeError = ObjDataBase.MensajeErrorDB;
            }
        }
        #endregion
    }
}
