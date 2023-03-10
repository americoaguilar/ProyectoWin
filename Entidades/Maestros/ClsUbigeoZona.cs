using System.Data;

namespace Entidades.UbigeoZona
{
    public class ClsUbigeoZona
    {
        #region Atributos Privados
        private string _idUbigeoZona;
        private string _descripcion;
        private int _idCiudad;
        private bool _estado;

        // Atributos de Manejo de la Base de Datos
        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;
        #endregion

        #region Atributos Publicos
        public string IdUbigeoZona { get => _idUbigeoZona; set => _idUbigeoZona = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public int IdCiudad { get => _idCiudad; set => _idCiudad = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }
        #endregion
    }
}
