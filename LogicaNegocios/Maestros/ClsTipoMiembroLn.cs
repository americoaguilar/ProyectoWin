using AccesoDatos.DataBase;
using Entidades.TipoMiembro;
using System;
using System.Data;

namespace LogicaNegocios.TipoMiembro
{
    public class ClsTipoMiembroLn
    {
        #region Variables Privadas
        private ClsDataBase ObjDataBase = null;
        #endregion

        #region Metodo Index
        public void Index(ref ClsTipoMiembro ObjTipoMiembro)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "TipoMiembro",
                NombreSP = "sp_TipoMiembro_Index",
                Scalar = false
            };

            Ejecutar(ref ObjTipoMiembro);
        }
        #endregion

        #region CRUD
        public void Create(ref ClsTipoMiembro ObjTipoMiembro)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "TipoMiembro",
                NombreSP = "sp_TipoMiembro_Create",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oDescripcion", "17", ObjTipoMiembro.Descripcion);
            ObjDataBase.DtParametros.Rows.Add(@"@oEstado", "4", (ObjTipoMiembro.Estado == true ?1 :0));
            ObjDataBase.DtParametros.Rows.Add(@"@oUsuario", "17", ObjTipoMiembro.Usuario);

            Ejecutar(ref ObjTipoMiembro);
        }

        public void Read(ref ClsTipoMiembro ObjTipoMiembro)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "TipoMiembro",
                NombreSP = "sp_TipoMiembro_Read",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oIdTipoMiembro", "17", ObjTipoMiembro.IdTipoMiembro);

            Ejecutar(ref ObjTipoMiembro);
        }

        public void Update(ref ClsTipoMiembro ObjTipoMiembro)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "TipoMiembro",
                NombreSP = "sp_TipoMiembro_Update",
                Scalar = false
            };
            
            ObjDataBase.DtParametros.Rows.Add(@"@oIdTipoMiembro", "17", ObjTipoMiembro.IdTipoMiembro);
            ObjDataBase.DtParametros.Rows.Add(@"@oDescripcion", "17", ObjTipoMiembro.Descripcion);
            ObjDataBase.DtParametros.Rows.Add(@"@oEstado", "4", (ObjTipoMiembro.Estado == true ? 1 : 0));
            ObjDataBase.DtParametros.Rows.Add(@"@oUsuario", "17", ObjTipoMiembro.Usuario);

            Ejecutar(ref ObjTipoMiembro);
        }

        public void Delete(ref ClsTipoMiembro ObjTipoMiembro)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "TipoMiembro",
                NombreSP = "sp_TipoMiembro_Delete",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oIdTipoMiembro", "17", ObjTipoMiembro.IdTipoMiembro);
            ObjDataBase.DtParametros.Rows.Add(@"@oUsuario", "17", ObjTipoMiembro.Usuario);

            Ejecutar(ref ObjTipoMiembro);
        }
        #endregion

        #region Metodo Privado
        private void Ejecutar(ref ClsTipoMiembro ObjTipoMiembro)
        {
            ObjDataBase.CRUD(ref ObjDataBase);

            if (ObjDataBase.MensajeErrorDB == null)
            {
                if (ObjDataBase.Scalar)
                {
                    ObjTipoMiembro.ValorScalar = ObjDataBase.ValorScalar;
                }
                else
                {
                    ObjTipoMiembro.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    if (ObjTipoMiembro.DtResultados.Rows.Count == 1
                        && ObjTipoMiembro.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-"
                        && ObjTipoMiembro.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "0")
                    {
                        foreach (DataRow item in ObjTipoMiembro.DtResultados.Rows)
                        {
                            ObjTipoMiembro.IdTipoMiembro = item["IdTipoMiembro"].ToString();
                            ObjTipoMiembro.Descripcion = item["Descripcion"].ToString();
                            ObjTipoMiembro.Estado = Convert.ToBoolean(item["Estado"]);
                        }
                    }
                }
            }
            else
            {
                ObjTipoMiembro.MensajeError = ObjDataBase.MensajeErrorDB;
            }
        }
        #endregion
    }
}
