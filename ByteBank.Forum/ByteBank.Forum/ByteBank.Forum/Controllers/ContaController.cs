﻿using ByteBank.Forum.Models;
using ByteBank.Forum.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ByteBank.Forum.Controllers
{
    public class ContaController : Controller
    {
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(ContaRegistrarViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var dbContext = new IdentityDbContext<UsuarioAplicacao>();
                var novoUsuario = new UsuarioAplicacao();

                novoUsuario.Email = modelo.Email;
                novoUsuario.UserName = modelo.UserName;
                novoUsuario.NomeCompleto = modelo.NomeCompleto;

                dbContext.Users.Add(novoUsuario);
                dbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View();
        }



    }
}