using AccesoDatos.DataBase;
using Entidades.UbigeoCiudad;
using System;
using System.Data;

namespace LogicaNegocios.UbigeoCiudades
{
    public class ClsUbigeoCiudadLn
    {
        #region Variables Privadas
        private ClsDataBase ObjDataBase = null;
        #endregion

        #region Metodo Index
        public void Index(ref ClsUbigeoCiudad ObjUbigeoCiudad)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoCiudad",
                NombreSP = "sp_UbigeoCiudad_Index",
                Scalar = false
            };

            Ejecutar(ref ObjUbigeoCiudad);
        }
        #endregion

        #region CRUD
        public void Create(ref ClsUbigeoCiudad ObjUbigeoCiudad)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoCiudad",
                NombreSP = "sp_UbigeoCiudad_Create",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oDescripcion", "17", ObjUbigeoCiudad.Descripcion);
            ObjDataBase.DtParametros.Rows.Add(@"@oIdUbigeoEstado", "17", ObjUbigeoCiudad.IdUbigeoEstado);
            ObjDataBase.DtParametros.Rows.Add(@"@oEstado", "4", (ObjUbigeoCiudad.Estado == true ?1 :0));
            ObjDataBase.DtParametros.Rows.Add(@"@oUsuario", "17", ObjUbigeoCiudad.Usuario);

            Ejecutar(ref ObjUbigeoCiudad);
        }

        public void Read(ref ClsUbigeoCiudad ObjUbigeoCiudad)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoCiudad",
                NombreSP = "sp_UbigeoCiudad_Read",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oIdUbigeoCiudad", "17", ObjUbigeoCiudad.IdUbigeoCiudad);

            Ejecutar(ref ObjUbigeoCiudad);
        }

        public void Update(ref ClsUbigeoCiudad ObjUbigeoCiudad)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoCiudad",
                NombreSP = "sp_UbigeoCiudad_Update",
                Scalar = false
            };
            
            ObjDataBase.DtParametros.Rows.Add(@"@oIdUbigeoCiudad", "17", ObjUbigeoCiudad.IdUbigeoCiudad);
            ObjDataBase.DtParametros.Rows.Add(@"@oDescripcion", "17", ObjUbigeoCiudad.Descripcion);
            ObjDataBase.DtParametros.Rows.Add(@"@oIdUbigeoEstado", "17", ObjUbigeoCiudad.IdUbigeoEstado);
            ObjDataBase.DtParametros.Rows.Add(@"@oEstado", "4", (ObjUbigeoCiudad.Estado == true ? 1 : 0));
            ObjDataBase.DtParametros.Rows.Add(@"@oUsuario", "17", ObjUbigeoCiudad.Usuario);

            Ejecutar(ref ObjUbigeoCiudad);
        }

        public void Delete(ref ClsUbigeoCiudad ObjUbigeoCiudad)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoCiudad",
                NombreSP = "sp_UbigeoCiudad_Delete",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oIdUbigeoCiudad", "17", ObjUbigeoCiudad.IdUbigeoCiudad);
            ObjDataBase.DtParametros.Rows.Add(@"@oUsuario", "17", ObjUbigeoCiudad.Usuario);

            Ejecutar(ref ObjUbigeoCiudad);
        }
        #endregion

        #region Metodo Privado
        private void Ejecutar(ref ClsUbigeoCiudad ObjUbigeoCiudad)
        {
            ObjDataBase.CRUD(ref ObjDataBase);

            if (ObjDataBase.MensajeErrorDB == null)
            {
                if (ObjDataBase.Scalar)
                {
                    ObjUbigeoCiudad.ValorScalar = ObjDataBase.ValorScalar;
                }
                else
                {
                    ObjUbigeoCiudad.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    if (ObjUbigeoCiudad.DtResultados.Rows.Count == 1
                        && ObjUbigeoCiudad.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-"
                        && ObjUbigeoCiudad.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "0")
                    {
                        foreach (DataRow item in ObjUbigeoCiudad.DtResultados.Rows)
                        {
                            ObjUbigeoCiudad.IdUbigeoCiudad = item["IdUbigeoCiudad"].ToString();
                            ObjUbigeoCiudad.Descripcion = item["Descripcion"].ToString();
                            ObjUbigeoCiudad.IdUbigeoEstado = item["IdUbigeoEstado"].ToString();
                            ObjUbigeoCiudad.Estado = Convert.ToBoolean(item["Estado"]);
                        }
                    }
                }
            }
            else
            {
                ObjUbigeoCiudad.MensajeError = ObjDataBase.MensajeErrorDB;
            }
        }
        #endregion
    }
}
