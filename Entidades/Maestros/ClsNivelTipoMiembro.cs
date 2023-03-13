using System.Data;

namespace Entidades.NivelTipoMiembro
{
    public class ClsNivelTipoMiembro
    {
        #region Atributos Privados
        private string _idNivelTipoMiembro;
        private string _descripcion;
        private bool _estado;
        private string _usuario;

        // Atributos de Manejo de la Base de Datos
        private int _codigoError;
        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;
        #endregion

        #region Atributos Publicos
        public string IdNivelTipoMiembro { get => _idNivelTipoMiembro; set => _idNivelTipoMiembro = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public int CodigoError { get => _codigoError; set => _codigoError = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }
        #endregion
    }
}
