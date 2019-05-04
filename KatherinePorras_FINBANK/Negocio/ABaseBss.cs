using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KatherinePorras_FINBANK.Infraestructra;
namespace KatherinePorras_FINBANK.Negocio
{
    public abstract class ABaseBss
    {

        public Encriptacion _encriptacion = new Encriptacion();
        public EnviaMail _enviarmail = new EnviaMail();
    }
}