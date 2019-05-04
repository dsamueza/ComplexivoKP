using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KatherinePorras_FINBANK.Modelo
{
    public class ModeloCotizacion
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string cedula { get; set;    }
        public string Mail { get; set; }
        public string solicitud { get; set; }
        public int idsucursal { get; set; }
        public int idamortizacion { get; set; }
        public int idsolicitud { get; set; }
        public int idusuario{ get; set; }
        public int idinteres { get; set; }
        public double monto { get; set; }
        public int  plazo { get; set; }
    }
}