
function LoadCotizacionById(idCotizacion) {
    $.blockUI({ message: "cargando..."+idCotizacion });
    $.ajax({
        type: "GET",
        url: "/Cotizacion/Get",
        // async: false,
        data: {
            id: idCotizacion
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            LoadCotizacionByIdVue(data);
            $.unblockUI();
        },
        error: function (error) {
            console.log(error);
            alert("Error! no se ha encontrado el usuario" + error);
            $.unblockUI();

        }
    });
}
Vue.component('todo-item', {
    props: ['todo'],
    template: '<li>{{ todo.text }}</li>'
})

var vue_datos;
function LoadCotizacionByIdVue(_modelo) {

    vue_datos = new Vue({
        el: '#idvue',
        data: {
            datovue: _modelo,
            estadoEnviado: false,
            validated: 0,
            interes: 0,
            primeracuota:0,
            tablaAmortizacion: null,
            totalDeuda:0
        },
        methods: {
            Chequeoformulario: function (e) {
                var control = 1;
                if (this.datovue.idsucursal > 0 && this.datovue.idinteres > 0
                    && this.datovue.idamortizacion > 0 && this.datovue.monto > 0
                    && this.datovue.plazo > 0 ) {
                    control = 0;
                }
                return control;
            },

            GuardarSolicitud: function () {
                CalcularTablaAmortizacion();
                this.estadoEnviado = true;
                

            }
        }

    })
    

}
function CalcularTablaAmortizacion(){
    $.blockUI({ message: "cargando..."  });
    $.ajax({
        type: "GET",
        url: "/Cotizacion/Calcular",
        // async: false,
        data: {
            _modeloSolicitudCliente: JSON.stringify(vue_datos.$data.datovue)
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            vue_datos.$data.tablaAmortizacion = data.ListaDatosAmortizacion;
            vue_datos.$data.interes = data.interes;
            vue_datos.$data.primeracuota = data.primeracuota;
            vue_datos.$data.totalDeuda = data.Pagototal;
            $.unblockUI();
        },
        error: function (error) {
            console.log(error);
            alert("Error! no se ha encontrado el usuario" + error);
            $.unblockUI();

        }
    });

}