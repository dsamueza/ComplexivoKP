﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KatherinePorras_FINBANK.Acceso_Dato.transacciones;
using KatherinePorras_FINBANK.Infraestructra;
using KatherinePorras_FINBANK.Modelo;
namespace KatherinePorras_FINBANK.Negocio
{

    public  class UsuarioBSS
    {

        private sfb_usuarioDOA _usuarioDao = new sfb_usuarioDOA();
        private EnviaMail _enviarmail = new EnviaMail();
        /// <summary>
        /// Valida el usuario . Recupera el estado que tiene en ese momento el usuario logeado.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contraseña"></param>
        /// <returns>
        /// Retorna 1 si el usuario esta permito para ingresar.
        /// Retorna 2 si el usuario o contraseña no son correctas.
        /// Retorna 3 si el usuario no se encuentra activo.
        /// </returns>
        public int ValidarUsuario(string usuario, string contraseña) {

            var _modeloObtenidoUsuario= _usuarioDao.UsuarioValido(usuario,contraseña);
            if (_modeloObtenidoUsuario != null) {
               
                return _modeloObtenidoUsuario.estado == VariableConstante.usuarioActivo ? 1 : 3;
            }
            return 2;
        }

        public int CrearUsuario(RegistroUsuarioModelo _modeloRegistroUsuario)
        {
            var _insertoUsuario = _usuarioDao.InsertarUsuario(_modeloRegistroUsuario);
            if (_insertoUsuario==1)
            {
                _enviarmail.MailConfirmacion(_modeloRegistroUsuario.USUARIO, "Pruebas");


                return 1;
            }
            else {

            return _insertoUsuario;
            }
            
        }
    }
}