using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cellper
{
    public class CRecepcion
    {
        public CRecepcion()
        {
        }

        private int _recepcionEquipoID;
        private int _clienteID;
        private int _modeloCelularID;
        private string _imei;
        private int _fallaCelularID;
        private string _observaciones;
        private int _tecnicoID;
        private string _fechaEntrega;
        private int _tipoEquipoID;
        private int _estatusEquipoID;

        public CRecepcion(int _recepcionEquipoID, int _clienteID, int _modeloCelularID, string _imei, int _fallaCelularID, string _observaciones, int _tecnicoID, string _fechaEntrega, int _tipoEquipoID, int _estatusEquipoID)
        {
            this.RecepcionEquipoID = _recepcionEquipoID;
            this.ClienteID = _clienteID;
            this.ModeloCelularID = _modeloCelularID;
            this.Imei = _imei;
            this.FallaCelularID = _fallaCelularID;
            this.Observaciones = _observaciones;
            this.TecnicoID = _tecnicoID;
            this.FechaEntrega = _fechaEntrega;
            this._estatusEquipoID = _estatusEquipoID;

        }

        public int RecepcionEquipoID
        {
            get
            {
                return _recepcionEquipoID;
            }

            set
            {
                _recepcionEquipoID = value;
            }
        }

        public int ClienteID
        {
            get
            {
                return _clienteID;
            }

            set
            {
                _clienteID = value;
            }
        }

        public int ModeloCelularID
        {
            get
            {
                return _modeloCelularID;
            }

            set
            {
                _modeloCelularID = value;
            }
        }

        public string Imei
        {
            get
            {
                return _imei;
            }

            set
            {
                _imei = value;
            }
        }

        public int FallaCelularID
        {
            get
            {
                return _fallaCelularID;
            }

            set
            {
                _fallaCelularID = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return _observaciones;
            }

            set
            {
                _observaciones = value;
            }
        }

        public int TecnicoID
        {
            get
            {
                return _tecnicoID;
            }

            set
            {
                _tecnicoID = value;
            }
        }

        public string FechaEntrega
        {
            get
            {
                return _fechaEntrega;
            }

            set
            {
                _fechaEntrega = value;
            }
        }

        public int TipoEquipoID
        {
            get
            {
                return _tipoEquipoID;
            }

            set
            {
                _tipoEquipoID = value;
            }
        }

        public int EstatusEquipoID
        {
            get
            {
                return _estatusEquipoID;
            }

            set
            {
                _estatusEquipoID = value;
            }
        }

    }

}