using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Maestros
{
    public class ClsIglesiaMiembros
    {
        #region Atributos Privados
        private int _idIglesia;
        private string _idMiembro;
        private byte _estado;

        // Atributos de Manejo de la Base de Datos
        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;
        #endregion

        #region Atributos Publicos
        public int IdIglesia { get => _idIglesia; set => _idIglesia = value; }
        public string IdMiembro { get => _idMiembro; set => _idMiembro = value; }
        public byte Estado { get => _estado; set => _estado = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }
        #endregion
    }
}
