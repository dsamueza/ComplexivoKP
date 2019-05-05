using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KatherinePorras_FINBANK.Modelo
{
    public class ModeloTablaAmortizacion
    {
        public int mumeroPago { get; set; }
        public double cuota { get; set; }
        public double interes { get; set; }
        public double capital { get; set; }
        public double Saldo { get; set; }
    }
}