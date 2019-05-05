using KatherinePorras_FINBANK.Acceso_Dato.transacciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KatherinePorras_FINBANK.Modelo;
namespace KatherinePorras_FINBANK.Acceso_Dato.query
{
   
    public class sfb_amortizacionDAO: ABaseDAO
    {
        public ModeloCotizacion ObtenerDatosCabeceraCotizacion(int id)
        {


            var _usuario = ctx.SFB_USUARIO.Where(x => x.SFB_USU_ID.Equals(id));
            if (_usuario.Count() > 0)
            {
                var _modeloCotizacion = _usuario.ToList()
                                         .Select(x => new ModeloCotizacion
                                                {
                                                   idusuario =x.SFB_USU_ID,
                                                   nombre= x.SFB_USU_NOMBRE +" "+x.SFB_USU_APELLIDO,
                                                   cedula=x.SFB_USU_CEDULA,
                                                   Mail=x.SFB_USU_USUARIO
                                                });
                return _modeloCotizacion.FirstOrDefault();
            }
            else
            {
                return null;
            }


        }

        public List<ModeloSeleccionCatalogo> ObtenerDatosSucursal()
        {

            var _sucursal = ctx.SFB_SUCURSAL;
            if (_sucursal.Count() > 0)
            {
                var _modeloSucursal= _sucursal.ToList()
                                         .Select(x => new ModeloSeleccionCatalogo
                                         {
                                             Text=x.SFB_SUC_DESCRIPCION,
                                             Value=x.SFB_SUC_ID.ToString()
                                         });
                return _modeloSucursal.ToList();
            }
            else
            {
                return null;
            }

        }

        public List<ModeloSeleccionCatalogo> ObtenerDatosInteres()
        {

            var _interes = ctx.SFB_INTERES;
            if (_interes.Count() > 0)
            {
                var _modeloInteres = _interes.ToList()
                                         .Select(x => new ModeloSeleccionCatalogo
                                         {
                                             Text = x.SFB_INT_DESCRIPCION,
                                             Value = x.SFB_INT_ID.ToString()
                                             , Monto = x.SFB_INT_VALOR
                                         });
                return _modeloInteres.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<ModeloSeleccionCatalogo> ObtenerDatosAmortizacion()
        {

            var _amortizacion = ctx.SFB_AMORTIZACION;
            if (_amortizacion.Count() > 0)
            {
                var _modeloAmortizacion = _amortizacion.ToList()
                                         .Select(x => new ModeloSeleccionCatalogo
                                         {
                                             Text = x.SFB_AMO_DESCRIPCION,
                                             Value = x.SFB_AMO_ID.ToString()
                                         });
                return _modeloAmortizacion.ToList();
            }
            else
            {
                return null;
            }
        }
    }
}