using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cellper
{
    public class CReparacionEquipo
    {
        public CReparacionEquipo()
        {
        }

        public CReparacionEquipo(int _reparacionEquipoID, int _recepcionEquipoID, int _inventarioID, int _cantidadItem, int _tecnicoID, int _estatusEquipoID, string _observacionReparacionEquipo)
        {
            this._reparacionEquipoID = _reparacionEquipoID;
            this._recepcionEquipoID = _recepcionEquipoID;
            this._inventarioID = _inventarioID;
            this._cantidadItem = _cantidadItem;
            this._tecnicoID = _tecnicoID;
            this._estatusEquipoID = _estatusEquipoID;
            this._observacionReparacionEquipo = _observacionReparacionEquipo;
        }

        private int _reparacionEquipoID;
        private int _recepcionEquipoID;
        private int _inventarioID;
        private int _cantidadItem;
        private int _tecnicoID;
        private int _estatusEquipoID;
        private string _observacionReparacionEquipo;

        public int ReparacionEquipoID
        {
            get
            {
                return _reparacionEquipoID;
            }

            set
            {
                _reparacionEquipoID = value;
            }
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

        public string ObservacionReparacionEquipo
        {
            get
            {
                return _observacionReparacionEquipo;
            }

            set
            {
                _observacionReparacionEquipo = value;
            }
        }
    }
}