using System;
using System.Data;

namespace Entidades.Categoria
{
    public class ClsCategoria
    {
        #region Atributos Privados
        private byte _idCategoria;
        private string _descripcion;
        private bool _estado;
        private DateTime _fechaCreacion;

        // Atributos de Manejo de la Base de Datos
        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;
        #endregion

        #region Atributos Publicos
        public byte IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public DateTime FechaCreacion { get => _fechaCreacion; set => _fechaCreacion = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }
        #endregion
    }
}
