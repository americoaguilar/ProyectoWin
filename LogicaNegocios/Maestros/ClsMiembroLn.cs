using AccesoDatos.DataBase;
using Entidades.Miembro;
using System;
using System.Data;

namespace LogicaNegocios.Miembro
{
    public class ClsMiembroLn
    {
        #region Variables Privadas
        private ClsDataBase ObjDataBase = null;
        #endregion

        #region Metodo Index
        public void Index(ref ClsMiembro ObjMiembro)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Miembro",
                NombreSP = "sp_Miembro_Index",
                Scalar = false
            };

            Ejecutar(ref ObjMiembro);
        }
        #endregion

        #region CRUD
        public void Create(ref ClsMiembro ObjMiembro)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Miembro",
                NombreSP = "sp_Miembro_Create",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oNombre", "17", ObjMiembro.IdCard);
            ObjDataBase.DtParametros.Rows.Add(@"@oIdCard", "17", ObjMiembro.Nombre);
            ObjDataBase.DtParametros.Rows.Add(@"@oIdCard", "17", ObjMiembro.IdTipoMiembro);
            ObjDataBase.DtParametros.Rows.Add(@"@oEstado", "4", (ObjMiembro.Estado == true ?1 :0));

            Ejecutar(ref ObjMiembro);
        }

        public void Read(ref ClsMiembro ObjMiembro)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Miembro",
                NombreSP = "sp_Miembro_Read",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oIdMiembro", "17", ObjMiembro.IdMiembro);

            Ejecutar(ref ObjMiembro);
        }

        public void Update(ref ClsMiembro ObjMiembro)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Miembro",
                NombreSP = "sp_Miembro_Update",
                Scalar = false
            };
            
            ObjDataBase.DtParametros.Rows.Add(@"@oIdMiembro", "17", ObjMiembro.IdMiembro);
            ObjDataBase.DtParametros.Rows.Add(@"@oNombre", "17", ObjMiembro.IdCard);
            ObjDataBase.DtParametros.Rows.Add(@"@oIdCard", "17", ObjMiembro.Nombre);
            ObjDataBase.DtParametros.Rows.Add(@"@oIdCard", "17", ObjMiembro.IdTipoMiembro);
            ObjDataBase.DtParametros.Rows.Add(@"@oEstado", "4", (ObjMiembro.Estado == true ? 1 : 0));

            Ejecutar(ref ObjMiembro);
        }

        public void Delete(ref ClsMiembro ObjMiembro)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Miembro",
                NombreSP = "sp_Miembro_Delete",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oIdMiembro", "17", ObjMiembro.IdMiembro);

            Ejecutar(ref ObjMiembro);
        }
        #endregion

        #region Metodo Privado
        private void Ejecutar(ref ClsMiembro ObjMiembro)
        {
            ObjDataBase.CRUD(ref ObjDataBase);

            if (ObjDataBase.MensajeErrorDB == null)
            {
                if (ObjDataBase.Scalar)
                {
                    ObjMiembro.ValorScalar = ObjDataBase.ValorScalar;
                }
                else
                {
                    ObjMiembro.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    if (ObjMiembro.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in ObjMiembro.DtResultados.Rows)
                        {
                            ObjMiembro.IdMiembro = item["IdMiembro"].ToString();
                            ObjMiembro.IdCard = item["IdCard"].ToString();
                            ObjMiembro.Nombre = item["Nombre"].ToString();
                            ObjMiembro.IdMiembro = item["IdMiembro"].ToString();
                            ObjMiembro.Estado = Convert.ToBoolean(item["Estado"]);
                        }
                    }
                }
            }
            else
            {
                ObjMiembro.MensajeError = ObjDataBase.MensajeErrorDB;
            }
        }
        #endregion
    }
}
