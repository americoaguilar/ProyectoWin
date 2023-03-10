using AccesoDatos.DataBase;
using Entidades.Habitacion;
using System;
using System.Data;

namespace LogicaNegocios.Habitacion
{
    public class ClsHabitacionLn
    {
        #region Variables Privadas
        private ClsDataBase ObjDataBase = null;
        #endregion

        #region Metodo Index
        public void Index(ref ClsHabitacion ObjHabitacion)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Habitacion",
                NombreSP = "[dbo].[sp_Habitacion_Index]",
                Scalar = false
            };

            Ejecutar(ref ObjHabitacion);
        }
        #endregion

        #region CRUD
        public void Create(ref ClsHabitacion ObjHabitacion)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Habitacion",
                NombreSP = "[dbo].[sp_Categorias_Create]",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@Numero", "17", ObjHabitacion.Numero);
            ObjDataBase.DtParametros.Rows.Add(@"@Detalle", "17", ObjHabitacion.Detalle);
            ObjDataBase.DtParametros.Rows.Add(@"@Precio", "6", ObjHabitacion.Precio);
            ObjDataBase.DtParametros.Rows.Add(@"@IdEstadoHabitacion", "4", ObjHabitacion.IdEstadoHabitacion);
            ObjDataBase.DtParametros.Rows.Add(@"@IdPiso", "4", ObjHabitacion.IdPiso);
            ObjDataBase.DtParametros.Rows.Add(@"@IdCategoria", "4", ObjHabitacion.IdCategoria);
            ObjDataBase.DtParametros.Rows.Add(@"@Estado", "1", ObjHabitacion.Estado);

            Ejecutar(ref ObjHabitacion);
        }

        public void Read(ref ClsHabitacion ObjHabitacion)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Habitacion",
                NombreSP = "[dbo].[sp_Categorias_Read]",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@IdHabitacion", "4", ObjHabitacion.IdHabitacion);

            Ejecutar(ref ObjHabitacion);
        }

        public void Update(ref ClsHabitacion ObjHabitacion)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Habitacion",
                NombreSP = "[dbo].[sp_Categorias_Delete]",
                Scalar = false
            };
            
            ObjDataBase.DtParametros.Rows.Add(@"@Idcategoria", "4", ObjHabitacion.IdHabitacion);
            ObjDataBase.DtParametros.Rows.Add(@"@Numero", "17", ObjHabitacion.Numero);
            ObjDataBase.DtParametros.Rows.Add(@"@Detalle", "17", ObjHabitacion.Detalle);
            ObjDataBase.DtParametros.Rows.Add(@"@Precio", "6", ObjHabitacion.Precio);
            ObjDataBase.DtParametros.Rows.Add(@"@IdEstadoHabitacion", "4", ObjHabitacion.IdEstadoHabitacion);
            ObjDataBase.DtParametros.Rows.Add(@"@IdPiso", "4", ObjHabitacion.IdPiso);
            ObjDataBase.DtParametros.Rows.Add(@"@IdCategoria", "4", ObjHabitacion.IdCategoria);
            ObjDataBase.DtParametros.Rows.Add(@"@Estado", "1", ObjHabitacion.Estado);
            Ejecutar(ref ObjHabitacion);
        }

        public void Delete(ref ClsHabitacion ObjHabitacion)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Habitacion",
                NombreSP = "[dbo].[sp_IndexCategorias]",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@IdHabitacion", "4", ObjHabitacion.IdHabitacion);

            Ejecutar(ref ObjHabitacion);
        }
        #endregion

        #region Metodo Privado
        private void Ejecutar(ref ClsHabitacion ObjHabitacion)
        {
            ObjDataBase.CRUD(ref ObjDataBase);

            if (ObjDataBase.MensajeErrorDB == null)
            {
                if (ObjDataBase.Scalar)
                {
                    ObjHabitacion.ValorScalar = ObjDataBase.ValorScalar;
                }
                else
                {
                    ObjHabitacion.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    if (ObjHabitacion.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in ObjHabitacion.DtResultados.Rows)
                        {
                            ObjHabitacion.IdHabitacion = Convert.ToByte(item["IdHabitacion"].ToString());
                            ObjHabitacion.Numero = item["Numero"].ToString();
                            ObjHabitacion.Detalle = item["Detalle"].ToString();
                            ObjHabitacion.Precio = Convert.ToDecimal(item["Precio"].ToString());
                            ObjHabitacion.IdEstadoHabitacion = Convert.ToByte(item["IdEstadoHabitacion"].ToString());
                            ObjHabitacion.IdPiso = Convert.ToByte(item["IdPiso"].ToString());
                            ObjHabitacion.IdCategoria = Convert.ToByte(item["IdCategoria"].ToString());
                            ObjHabitacion.Estado = Convert.ToBoolean(item["Estado"].ToString());
                            ObjHabitacion.FechaCreacion = Convert.ToDateTime(item["FechaCreacion"].ToString());
                        }
                    }
                }
            }
            else
            {
                ObjHabitacion.MensajeError = ObjDataBase.MensajeErrorDB;
            }
        }
        #endregion
    }
}
