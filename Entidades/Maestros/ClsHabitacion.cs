using System;
using System.Data;

namespace Entidades.Habitacion
{
    public class ClsHabitacion
    {
        #region Atributos Privados
        private byte _idHabitacion;
        private string _numero;
        private string _detalle;
        private decimal _precio;
        private byte _idEstadoHabitacion;
        private byte _idPiso;
        private byte _idCategoria;
        private bool _estado;
        private DateTime _fechaCreacion;

        // Atributos de Manejo de la Base de Datos
        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;
        #endregion

        #region Atributos Publicos
        public byte IdHabitacion { get => _idHabitacion; set => _idHabitacion = value; }
        public string Numero { get => _numero; set => _numero = value; }
        public string Detalle { get => _detalle; set => _detalle = value; }
        public decimal Precio { get => _precio; set => _precio = value; }
        public byte IdEstadoHabitacion { get => _idEstadoHabitacion; set => _idEstadoHabitacion = value; }
        public byte IdPiso { get => _idPiso; set => _idPiso = value; }
        public byte IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public DateTime FechaCreacion { get => _fechaCreacion; set => _fechaCreacion = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }
        #endregion
    }
}
