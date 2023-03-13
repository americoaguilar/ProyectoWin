using AccesoDatos.DataBase;
using Entidades.UbigeoEstado;
using System;
using System.Data;

namespace LogicaNegocios.UbigeoEstados
{
    public class ClsUbigeoEstadoLn
    {
        #region Variables Privadas
        private ClsDataBase ObjDataBase = null;
        #endregion

        #region Metodo Index
        public void Index(ref ClsUbigeoEstado ObjUbigeoEstado)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoEstado",
                NombreSP = "sp_UbigeoEstado_Index",
                Scalar = false
            };

            Ejecutar(ref ObjUbigeoEstado);
        }
        #endregion

        #region CRUD
        public void Create(ref ClsUbigeoEstado ObjUbigeoEstado)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoEstado",
                NombreSP = "sp_UbigeoEstado_Create",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oDescripcion", "17", ObjUbigeoEstado.Descripcion);
            ObjDataBase.DtParametros.Rows.Add(@"@oIdUbigeoPais", "17", ObjUbigeoEstado.IdUbigeoPais);
            ObjDataBase.DtParametros.Rows.Add(@"@oEstado", "4", (ObjUbigeoEstado.Estado == true ?1 :0));
            ObjDataBase.DtParametros.Rows.Add(@"@ousuario", "17", ObjUbigeoEstado.Usuario);

            Ejecutar(ref ObjUbigeoEstado);
        }

        public void Read(ref ClsUbigeoEstado ObjUbigeoEstado)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoEstado",
                NombreSP = "sp_UbigeoEstado_Read",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oIdUbigeoEstado", "17", ObjUbigeoEstado.IdUbigeoEstado);

            Ejecutar(ref ObjUbigeoEstado);
        }

        public void Update(ref ClsUbigeoEstado ObjUbigeoEstado)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoEstado",
                NombreSP = "sp_UbigeoEstado_Update",
                Scalar = false
            };
            
            ObjDataBase.DtParametros.Rows.Add(@"@oIdUbigeoEstado", "17", ObjUbigeoEstado.IdUbigeoEstado);
            ObjDataBase.DtParametros.Rows.Add(@"@oDescripcion", "17", ObjUbigeoEstado.Descripcion);
            ObjDataBase.DtParametros.Rows.Add(@"@oIdUbigeoPais", "17", ObjUbigeoEstado.IdUbigeoPais);
            ObjDataBase.DtParametros.Rows.Add(@"@oEstado", "4", (ObjUbigeoEstado.Estado == true ? 1 : 0));
            ObjDataBase.DtParametros.Rows.Add(@"@oUsuario", "17", ObjUbigeoEstado.Usuario);

            Ejecutar(ref ObjUbigeoEstado);
        }

        public void Delete(ref ClsUbigeoEstado ObjUbigeoEstado)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoEstado",
                NombreSP = "sp_UbigeoEstado_Delete",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oIdUbigeoEstado", "17", ObjUbigeoEstado.IdUbigeoEstado);
            ObjDataBase.DtParametros.Rows.Add(@"@oUsuario", "17", ObjUbigeoEstado.Usuario);

            Ejecutar(ref ObjUbigeoEstado);
        }
        #endregion

        #region Metodo Privado
        private void Ejecutar(ref ClsUbigeoEstado ObjUbigeoEstado)
        {
            ObjDataBase.CRUD(ref ObjDataBase);

            if (ObjDataBase.MensajeErrorDB == null)
            {
                if (ObjDataBase.Scalar)
                {
                    ObjUbigeoEstado.ValorScalar = ObjDataBase.ValorScalar;
                }
                else
                {
                    ObjUbigeoEstado.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    if (ObjUbigeoEstado.DtResultados.Rows.Count == 1 
                            && ObjUbigeoEstado.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-"
                            && ObjUbigeoEstado.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "0")
                    {
                        foreach (DataRow item in ObjUbigeoEstado.DtResultados.Rows)
                        {
                            ObjUbigeoEstado.IdUbigeoEstado = item["IdUbigeoEstado"].ToString();
                            ObjUbigeoEstado.Descripcion = item["Descripcion"].ToString();
                            ObjUbigeoEstado.IdUbigeoPais = item["IdUbigeoPais"].ToString();
                            ObjUbigeoEstado.Estado = Convert.ToBoolean(item["Estado"]);
                        }
                    }
                }
            }
            else
            {
                ObjUbigeoEstado.MensajeError = ObjDataBase.MensajeErrorDB;
            }
        }
        #endregion
    }
}
