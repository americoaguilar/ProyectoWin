using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.General
{
    public class ClsCredencial
    {
        #region Atributos Privados
        private string _usuario;
        private string _clave;

        // Atributos de Manejo de la Base de Datos
        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;
        #endregion

        #region Atributos Publicos
        public string Usuario { get => _usuario; set => _usuario = value; }
        public string Clave { get => _clave; set => _clave = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }
        #endregion
    }
}
