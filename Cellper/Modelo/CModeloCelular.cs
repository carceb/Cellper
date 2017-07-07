using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cellper
{
    public class CModeloCelular
    {
        public CModeloCelular()
        {
        }

        public CModeloCelular(int _modeloCelularID, int _tipoCelularID, string _nombreModeloCelular)
        {
            this._modeloCelularID = _modeloCelularID;
            this._tipoCelularID = _tipoCelularID;
            this._nombreModeloCelular = _nombreModeloCelular;
        }

        private int _modeloCelularID;
        private int _tipoCelularID;
        private string _nombreModeloCelular;

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

        public string NombreModeloCelular
        {
            get
            {
                return _nombreModeloCelular;
            }

            set
            {
                _nombreModeloCelular = value;
            }
        }
    }
}