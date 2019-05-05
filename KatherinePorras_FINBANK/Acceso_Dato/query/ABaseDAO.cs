using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KatherinePorras_FINBANK.Acceso_Dato.@base;
using KatherinePorras_FINBANK.Infraestructra;
namespace KatherinePorras_FINBANK.Acceso_Dato.transacciones
{
    public abstract class ABaseDAO
    {
       public KP_finbankEntities ctx = new KP_finbankEntities();
    }
}