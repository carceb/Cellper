using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cellper
{
    public class CTecnicos
    {
        public CTecnicos()
        {
        }

        public CTecnicos(int _tecnicoID, int _cedulaTecnico, string _nombreTecnico)
        {
            this._tecnicoID = _tecnicoID;
            this._cedulaTecnico = _cedulaTecnico;
            this._nombreTecnico = _nombreTecnico;
        }

        private int _tecnicoID;
        private int _cedulaTecnico;
        private string _nombreTecnico;

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

        public int CedulaTecnico
        {
            get
            {
                return _cedulaTecnico;
            }

            set
            {
                _cedulaTecnico = value;
            }
        }

        public string NombreTecnico
        {
            get
            {
                return _nombreTecnico;
            }

            set
            {
                _nombreTecnico = value;
            }
        }
    }
}