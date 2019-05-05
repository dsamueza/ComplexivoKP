using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KatherinePorras_FINBANK.Modelo
{
    public class ModeloCalculoAmortizacion
    {

        public double? interes { get; set; }
        public double primeracuota { get; set; }
        public double Pagototal { get; set; }
        public List<ModeloTablaAmortizacion> ListaDatosAmortizacion;

    }
}