using KatherinePorras_FINBANK.Acceso_Dato.transacciones;
using KatherinePorras_FINBANK.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KatherinePorras_FINBANK.Acceso_Dato.query;
using System.Threading.Tasks;

namespace KatherinePorras_FINBANK.Negocio
{
    public class CotizacionBss:ABaseBss
    {

        private sfb_usuarioDOA _sfb_usuarioDAO = new sfb_usuarioDOA();
        private sfb_amortizacionDAO _sfb_amortizacionDao= new sfb_amortizacionDAO();
        public ModeloCotizacion _GestionCotizacion(int idusuario) {
            return _sfb_amortizacionDao.ObtenerDatosCabeceraCotizacion(idusuario); ;
        }
        public List<ModeloSeleccionCatalogo> _TraerSucursal() {

            return _sfb_amortizacionDao.ObtenerDatosSucursal();
        }

        public List<ModeloSeleccionCatalogo> _TraerInteres()
        {

            return _sfb_amortizacionDao.ObtenerDatosInteres();
        }

        public List<ModeloSeleccionCatalogo> _TraerAmortizacion()
        {

            return _sfb_amortizacionDao.ObtenerDatosAmortizacion();
        }
        public ModeloCalculoAmortizacion _RealizarCalculoAmortizacion(ModeloCotizacion _modelosolicitud)
        {
            ModeloCalculoAmortizacion _tb_modelocaluloamortizacion = new ModeloCalculoAmortizacion();
            var _ModelInteresAnual=_sfb_amortizacionDao.ObtenerDatosInteres().Where(x => x.Value == _modelosolicitud.idinteres.ToString());
            switch (_modelosolicitud.idamortizacion)
            {
                case 1 :
                    if (_ModelInteresAnual.Count() > 0) {
                        double interesMesual =(double) ((_ModelInteresAnual.First().Monto / 12)/100);
                        var elevacion = (Math.Pow((1 + interesMesual), _modelosolicitud.plazo));
                        var PrimeraCuota = (_modelosolicitud.monto) * ((elevacion) *interesMesual)
                                                                      / ((elevacion)-1);
                        _tb_modelocaluloamortizacion.primeracuota = PrimeraCuota;
                        _tb_modelocaluloamortizacion.interes = _ModelInteresAnual.First().Monto;
                        _tb_modelocaluloamortizacion.ListaDatosAmortizacion = new List<ModeloTablaAmortizacion>();
                        var _montodeuda = _modelosolicitud.monto;
                        for (int i = 0; i < _modelosolicitud.plazo; i++) {

                            var _montoActual = _montodeuda;
                            _tb_modelocaluloamortizacion
                                .ListaDatosAmortizacion
                                .Add(new ModeloTablaAmortizacion
                                {
                                    mumeroPago = (i + 1),
                                    cuota = Math.Round(PrimeraCuota,2),
                                    interes = Math.Round((_montoActual * interesMesual),2),
                                    capital = Math.Round((PrimeraCuota - (_montoActual * interesMesual)),2),
                                    Saldo= Math.Round((_montoActual -(PrimeraCuota - (_montoActual * interesMesual))),2)

                                });
                            _montodeuda = _montoActual - (PrimeraCuota - (_montoActual * interesMesual));

                        }


                    }
           
                    break;
                case 2 :

                    if (_ModelInteresAnual.Count() > 0)
                    {
                        double interesMesual = (double)((_ModelInteresAnual.First().Monto / 12) / 100);
                        var capital = (_modelosolicitud.monto) / (_modelosolicitud.plazo);
                        var interes = (_modelosolicitud.monto) * (interesMesual);
                        var PrimeraCuota = capital + interes;
                        _tb_modelocaluloamortizacion.primeracuota = PrimeraCuota;
                        _tb_modelocaluloamortizacion.interes = _ModelInteresAnual.First().Monto;
                        _tb_modelocaluloamortizacion.ListaDatosAmortizacion = new List<ModeloTablaAmortizacion>();
                        var _montodeuda = _modelosolicitud.monto;

                        for (int i = 0; i < _modelosolicitud.plazo; i++)
                        {

                            var _montoActual = _montodeuda;
                            _tb_modelocaluloamortizacion
                                .ListaDatosAmortizacion
                                .Add(new ModeloTablaAmortizacion
                                {
                                    mumeroPago = (i + 1),
                                    capital = Math.Round((capital), 2),
                                    Saldo = Math.Round((_montoActual - capital), 2),
                                    cuota = Math.Round(capital + (_montoActual * interesMesual), 2),
                                    interes = Math.Round((_montoActual * interesMesual), 2),

                                });
                            _montodeuda = _montoActual - capital;

                        }


                    }

                    break;
               
            }
            _tb_modelocaluloamortizacion.Pagototal = Math.Round(((_tb_modelocaluloamortizacion.ListaDatosAmortizacion.Select(b => b.interes).Sum())+_modelosolicitud.monto),2);
            _tb_modelocaluloamortizacion.primeracuota = Math.Round(_tb_modelocaluloamortizacion.primeracuota, 2);
            return _tb_modelocaluloamortizacion;
        }

        public int _GestionGuardarAmortizacion(ModeloCotizacion _modelosolicitud , ModeloCalculoAmortizacion _modeloAmortizacion)
        {

            return _sfb_amortizacionDao.GuardadoDatosAmortizacion(_modelosolicitud, _modeloAmortizacion);
        }
    }
}