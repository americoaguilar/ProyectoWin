using System.Data;

namespace Entidades.UbigeoEstado
{
    public class ClsUbigeoEstado
    {
        #region Atributos Privados
        private string _idUbigeoEstado;
        private string _descripcion;
        private string _idUbigeoPais;
        private bool _estado;
        private string _usuario;

        // Atributos de Manejo de la Base de Datos
        private int _codigoError;
        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;
        #endregion

        #region Atributos Publicos
        public string IdUbigeoEstado { get => _idUbigeoEstado; set => _idUbigeoEstado = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string IdUbigeoPais { get => _idUbigeoPais; set => _idUbigeoPais = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public int CodigoError { get => _codigoError; set => _codigoError = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }
        #endregion
    }
}
