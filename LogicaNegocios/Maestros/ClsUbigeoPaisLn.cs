using AccesoDatos.DataBase;
using Entidades.UbigeoPais;
using System;
using System.Data;

namespace LogicaNegocios.UbigeoPais
{
    public class ClsUbigeoPaisLn
    {
        #region Variables Privadas
        private ClsDataBase ObjDataBase = null;
        #endregion

        #region Metodo Index
        public void Index(ref ClsUbigeoPais ObjUbigeoPais)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoPais",
                NombreSP = "sp_UbigeoPais_Index",
                Scalar = false
            };

            Ejecutar(ref ObjUbigeoPais);
        }
        #endregion

        #region CRUD
        public void Create(ref ClsUbigeoPais ObjUbigeoPais)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoPais",
                NombreSP = "sp_UbigeoPais_Create",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oDescripcion", "17", ObjUbigeoPais.Descripcion);
            ObjDataBase.DtParametros.Rows.Add(@"@oEstado", "4", (ObjUbigeoPais.Estado == true ?1 :0));
            ObjDataBase.DtParametros.Rows.Add(@"@oUsuario", "17", ObjUbigeoPais.Usuario);

            Ejecutar(ref ObjUbigeoPais);
        }

        public void Read(ref ClsUbigeoPais ObjUbigeoPais)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoPais",
                NombreSP = "sp_UbigeoPais_Read",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oIdUbigeoPais", "17", ObjUbigeoPais.IdUbigeoPais);

            Ejecutar(ref ObjUbigeoPais);
        }

        public void Update(ref ClsUbigeoPais ObjUbigeoPais)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoPais",
                NombreSP = "sp_UbigeoPais_Update",
                Scalar = false
            };
            
            ObjDataBase.DtParametros.Rows.Add(@"@oIdUbigeoPais", "17", ObjUbigeoPais.IdUbigeoPais);
            ObjDataBase.DtParametros.Rows.Add(@"@oDescripcion", "17", ObjUbigeoPais.Descripcion);
            ObjDataBase.DtParametros.Rows.Add(@"@oEstado", "4", (ObjUbigeoPais.Estado == true ? 1 : 0));
            ObjDataBase.DtParametros.Rows.Add(@"@oUsuario", "17", ObjUbigeoPais.Usuario);

            Ejecutar(ref ObjUbigeoPais);
        }

        public void Delete(ref ClsUbigeoPais ObjUbigeoPais)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "UbigeoPais",
                NombreSP = "sp_UbigeoPais_Delete",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oIdUbigeoPais", "17", ObjUbigeoPais.IdUbigeoPais);
            ObjDataBase.DtParametros.Rows.Add(@"@oUsuario", "17", ObjUbigeoPais.Usuario);

            Ejecutar(ref ObjUbigeoPais);
        }
        #endregion

        #region Metodo Privado
        private void Ejecutar(ref ClsUbigeoPais ObjUbigeoPais)
        {
            ObjDataBase.CRUD(ref ObjDataBase);

            if (ObjDataBase.MensajeErrorDB == null)
            {
                if (ObjDataBase.Scalar)
                {
                    ObjUbigeoPais.ValorScalar = ObjDataBase.ValorScalar;
                }
                else
                {
                    ObjUbigeoPais.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    if (ObjUbigeoPais.DtResultados.Rows.Count == 1
                        && ObjUbigeoPais.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-"
                        && ObjUbigeoPais.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "0")
                    {
                        foreach (DataRow item in ObjUbigeoPais.DtResultados.Rows)
                        {
                            ObjUbigeoPais.IdUbigeoPais = item["IdUbigeoPais"].ToString();
                            ObjUbigeoPais.Descripcion = item["Descripcion"].ToString();
                            ObjUbigeoPais.Estado = Convert.ToBoolean(item["Estado"]);
                        }
                    }
                }
            }
            else
            {
                ObjUbigeoPais.MensajeError = ObjDataBase.MensajeErrorDB;
            }
        }
        #endregion
    }
}
