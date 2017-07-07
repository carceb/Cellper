using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cellper
{
    public class CFallaCelular
    {
        public CFallaCelular()
        {

        }

        public CFallaCelular(int _fallaCelularID, string _nombreFallaCelular)
        {
            this._fallaCelularID = _fallaCelularID;
            this._nombreFallaCelular = _nombreFallaCelular;
        }

        private int _fallaCelularID;
        private string _nombreFallaCelular;

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

        public string NombreFallaCelular
        {
            get
            {
                return _nombreFallaCelular;
            }

            set
            {
                _nombreFallaCelular = value;
            }
        }
    }
}