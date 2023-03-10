using AccesoDatos.DataBase;
using Entidades.Categoria;
using System;
using System.Data;

namespace LogicaNegocios.Categorias
{
    public class ClsCategoriaLn
    {
        #region Variables Privadas
        private ClsDataBase ObjDataBase = null;
        #endregion

        #region Metodo Index
        public void Index(ref ClsCategoria ObjCategoria)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Categoria",
                NombreSP = "sp_Categoria_Index",
                Scalar = false
            };

            Ejecutar(ref ObjCategoria);
        }
        #endregion

        #region CRUD
        public void Create(ref ClsCategoria ObjCategoria)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Categoria",
                NombreSP = "sp_Categoria_Create",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oDescripcion", "17", ObjCategoria.Descripcion);
            ObjDataBase.DtParametros.Rows.Add(@"@oEstado", "4", (ObjCategoria.Estado == true ?1 :0));

            Ejecutar(ref ObjCategoria);
        }

        public void Read(ref ClsCategoria ObjCategoria)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Categoria",
                NombreSP = "sp_Categoria_Read",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oIdcategoria", "4", ObjCategoria.IdCategoria);

            Ejecutar(ref ObjCategoria);
        }

        public void Update(ref ClsCategoria ObjCategoria)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Categoria",
                NombreSP = "sp_Categoria_Update",
                Scalar = false
            };
            
            ObjDataBase.DtParametros.Rows.Add(@"@oIdcategoria", "4", ObjCategoria.IdCategoria);
            ObjDataBase.DtParametros.Rows.Add(@"@oDescripcion", "17", ObjCategoria.Descripcion);
            ObjDataBase.DtParametros.Rows.Add(@"@oEstado", "4", (ObjCategoria.Estado == true ? 1 : 0));

            Ejecutar(ref ObjCategoria);
        }

        public void Delete(ref ClsCategoria ObjCategoria)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Categoria",
                NombreSP = "sp_Categoria_Delete",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@oIdcategoria", "4", ObjCategoria.IdCategoria);

            Ejecutar(ref ObjCategoria);
        }
        #endregion

        #region Metodo Privado
        private void Ejecutar(ref ClsCategoria ObjCategoria)
        {
            ObjDataBase.CRUD(ref ObjDataBase);

            if (ObjDataBase.MensajeErrorDB == null)
            {
                if (ObjDataBase.Scalar)
                {
                    ObjCategoria.ValorScalar = ObjDataBase.ValorScalar;
                }
                else
                {
                    ObjCategoria.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    if (ObjCategoria.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in ObjCategoria.DtResultados.Rows)
                        {
                            ObjCategoria.IdCategoria = Convert.ToByte(item["IdCategoria"].ToString());
                            ObjCategoria.Descripcion = item["Descripcion"].ToString();
                            ObjCategoria.Estado = Convert.ToBoolean(item["Estado"]);
                            ObjCategoria.FechaCreacion = Convert.ToDateTime(item["FechaCreacion"].ToString());
                        }
                    }
                }
            }
            else
            {
                ObjCategoria.MensajeError = ObjDataBase.MensajeErrorDB;
            }
        }
        #endregion
    }
}
