using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Maestros
{
    public class ClsIglesia
    {
        #region Atributos Privados
        private int _id;
        private string _descripcion;
        private int _idZona;
        private int _idCiudad;
        private int _idEstado;
        private byte _estado;

        // Atributos de Manejo de la Base de Datos
        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;
        #endregion

        #region Atributos Publicos
        public int Id { get => _id; set => _id = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public int IdZona { get => _idZona; set => _idZona = value; }
        public int IdCiudad { get => _idCiudad; set => _idCiudad = value; }
        public int IdEstado { get => _idEstado; set => _idEstado = value; }
        public byte Estado { get => _estado; set => _estado = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }
        #endregion
    }
}
