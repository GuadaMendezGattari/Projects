using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ejercicio.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejercicio.Controllers
{
    [Route("cliente")]
    public class ClienteController : Controller
    {
        // GET: api/values
        [HttpGet]
        [Route("listar")]
        public dynamic listarClientes()
        {
            var clientes = new List<Cliente>
            {
                new Cliente
                {
                    id = "1",
                    nombre = "Bernardo Peña",
                    correo = "google@gmail.com",
                    edad = "19"
                },
                new Cliente
                {
                    id = "2",
                    nombre = "Miguel Mantilla",
                    correo = "miguelgoogle@gmail.com",
                    edad = "23"
                }
            };

            return clientes;
        }
    }
}

