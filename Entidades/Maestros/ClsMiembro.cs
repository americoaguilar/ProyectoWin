using System.Data;

namespace Entidades.Miembro
{
    public class ClsMiembro
    {
        #region Atributos Privados
        private string _idMiembro;
        private string _idCard;
        private string _nombre;
        private string _idTipoMiembro;
        private bool _estado;

        // Atributos de Manejo de la Base de Datos
        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;
        #endregion

        #region Atributos Publicos
        public string IdMiembro { get => _idMiembro; set => _idMiembro = value; }
        public string IdCard { get => _idCard; set => _idCard = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string IdTipoMiembro { get => _idTipoMiembro; set => _idTipoMiembro = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }
        #endregion
    }
}
