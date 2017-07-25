using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cellper
{
    public class CInventario
    {
        public CInventario()
        {

        }

        public CInventario(int _inventarioID, string _NombreItem, int _cantidadItem, double _costoItem, string _serialItem)
        {
            this._inventarioID = _inventarioID;
            this._NombreItem = _NombreItem;
            this._cantidadItem = _cantidadItem;
            this._costoItem = _costoItem;
            this._serialItem = _serialItem;
        }

        private int _inventarioID;
        private string _NombreItem;
        private int _cantidadItem;
        private double _costoItem;
        private string _serialItem;

        public int InventarioID
        {
            get
            {
                return _inventarioID;
            }

            set
            {
                _inventarioID = value;
            }
        }

        public string NombreItem
        {
            get
            {
                return _NombreItem;
            }

            set
            {
                _NombreItem = value;
            }
        }
        public int CantidadItem
        {
            get
            {
                return _cantidadItem;
            }

            set
            {
                _cantidadItem = value;
            }
        }
        public double CostoItem
        {
            get
            {
                return _costoItem;
            }

            set
            {
                _costoItem = value;
            }
        }

        public string SerialItem
        {
            get
            {
                return _serialItem;
            }

            set
            {
                _serialItem = value;
            }
        }
    }
}