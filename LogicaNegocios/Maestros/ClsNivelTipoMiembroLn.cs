using AccesoDatos.DataBase;
using Entidades.NivelTipoMiembro;
using System;
using System.Data;

namespace LogicaNegocios.NivelesTipoMiembro
{
    public class ClsNivelTipoMiembroLn
    {
        #region Variables Privadas
        private ClsDataBase ObjDataBase = null;
        #endregion

        #region Metodo Index
        public void Index(ref ClsNivelTipoMiembro ObjNivelTipoMiembro)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "NivelTipoMiembro",
                NombreSP = "sp_NivelTipoMiembro_Index",
                Scalar = false
            };

            Ejecutar(ref ObjNivelTipoMiembro);
        }
        #endregion

        #region CRUD
        public void Create(ref ClsNivelTipoMiembro ObjNivelTipoMiembro)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "NivelTipoMiembro",
                NombreSP = "sp_NivelTipoMiembro_Create",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oDescripcion", "17", ObjNivelTipoMiembro.Descripcion);
            ObjDataBase.DtParametros.Rows.Add(@"@oEstado", "4", (ObjNivelTipoMiembro.Estado == true ?1 :0));
            ObjDataBase.DtParametros.Rows.Add(@"@oUsuario", "17", "usuario.general");

            Ejecutar(ref ObjNivelTipoMiembro);
        }

        public void Read(ref ClsNivelTipoMiembro ObjNivelTipoMiembro)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "NivelTipoMiembro",
                NombreSP = "sp_NivelTipoMiembro_Read",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oIdNivelTipoMiembro", "17", ObjNivelTipoMiembro.IdNivelTipoMiembro);

            Ejecutar(ref ObjNivelTipoMiembro);
        }

        public void Update(ref ClsNivelTipoMiembro ObjNivelTipoMiembro)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "NivelTipoMiembro",
                NombreSP = "sp_NivelTipoMiembro_Update",
                Scalar = false
            };
            
            ObjDataBase.DtParametros.Rows.Add(@"@oIdNivelTipoMiembro", "17", ObjNivelTipoMiembro.IdNivelTipoMiembro);
            ObjDataBase.DtParametros.Rows.Add(@"@oDescripcion", "17", ObjNivelTipoMiembro.Descripcion);
            ObjDataBase.DtParametros.Rows.Add(@"@oEstado", "4", (ObjNivelTipoMiembro.Estado == true ? 1 : 0));
            ObjDataBase.DtParametros.Rows.Add(@"@oUsuario", "17", "usuario.general");

            Ejecutar(ref ObjNivelTipoMiembro);
        }

        public void Delete(ref ClsNivelTipoMiembro ObjNivelTipoMiembro)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "NivelTipoMiembro",
                NombreSP = "sp_NivelTipoMiembro_Delete",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oIdNivelTipoMiembro", "17", ObjNivelTipoMiembro.IdNivelTipoMiembro);
            ObjDataBase.DtParametros.Rows.Add(@"@oUsuario", "17", "usuario.general");

            Ejecutar(ref ObjNivelTipoMiembro);
        }
        #endregion

        #region Metodo Privado
        private void Ejecutar(ref ClsNivelTipoMiembro ObjNivelTipoMiembro)
        {
            ObjDataBase.CRUD(ref ObjDataBase);

            if (ObjDataBase.MensajeErrorDB == null)
            {
                if (ObjDataBase.Scalar)
                {
                    ObjNivelTipoMiembro.ValorScalar = ObjDataBase.ValorScalar;
                }
                else
                {
                    ObjNivelTipoMiembro.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    if (ObjNivelTipoMiembro.DtResultados.Rows.Count == 1
                        && ObjNivelTipoMiembro.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-"
                        && ObjNivelTipoMiembro.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "0")
                    {
                        foreach (DataRow item in ObjNivelTipoMiembro.DtResultados.Rows)
                        {
                            ObjNivelTipoMiembro.IdNivelTipoMiembro = item["IdNivelTipoMiembro"].ToString();
                            ObjNivelTipoMiembro.Descripcion = item["Descripcion"].ToString();
                            ObjNivelTipoMiembro.Estado = Convert.ToBoolean(item["Estado"]);
                        }
                    }
                }
            }
            else
            {
                ObjNivelTipoMiembro.MensajeError = ObjDataBase.MensajeErrorDB;
            }
        }
        #endregion
    }
}
