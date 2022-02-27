using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using PruebaPersonal.Controllers;
using PruebaPersonal.Helpers;
using PruebaPersonal.Models;
using PruebaPersonal.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Net;

namespace TestPruebaPersonal
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetPolizasTest()
        {
            //Preparacion
            var polizaController = new PolizaController();
           

            IActionResult result = polizaController.Get("1234556");

            var okObjectResult = result as OkObjectResult;

            ApiResponse data = okObjectResult.Value as ApiResponse;           

            Assert.True(data.status.Equals(HttpStatusCode.OK));
        }

        [Test]
        public void PostPolizasTest()
        {
            //Preparacion
            var polizaController = new PolizaController();

            PolizaDto polizaDto = new()
            {
                NumeroPoliza = "66666",
                NumeroidentificacionCliente = "11442589635",
                FechaInicioPoliza = DateTime.UtcNow,
                FechaFinPoliza = DateTime.UtcNow.AddYears(1),
                NombrePlanPoliza = "Full",
                ValorMaximoCubierto = 15000000,
                IdCobertura = "6D8FD323-F251-427F-AE01-D32C78588366"
            };

            IActionResult result = polizaController.Post(polizaDto);

            var okObjectResult = result as OkObjectResult;

            ApiResponse data = okObjectResult.Value as ApiResponse;

            Assert.True(data.status.Equals(HttpStatusCode.OK));
        }
    }
}