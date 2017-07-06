using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cellper
{
    public class CTipoCelular
    {
        public CTipoCelular()
        {

        }

        public CTipoCelular(int _tipoCelularID, string _nombreTipoCelular, int _tipoEquipoID)
        {
            this._tipoCelularID = _tipoCelularID;
            this._nombreTipoCelular = _nombreTipoCelular;
            this._tipoEquipoID = _tipoEquipoID;
        }

        private int _tipoCelularID;
        private string _nombreTipoCelular;
        private int _tipoEquipoID;

        public int TipoCelularID
        {
            get
            {
                return _tipoCelularID;
            }

            set
            {
                _tipoCelularID = value;
            }
        }

        public string NombreTipoCelular
        {
            get
            {
                return _nombreTipoCelular;
            }

            set
            {
                _nombreTipoCelular = value;
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
    }
}