using System;
using System.Collections.Generic;
using EmpresaRetornaGEO.Model;
using EmpresaRetornaGEO.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaRetornaGEO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotaController : ControllerBase
    {
        [HttpPost]
        public string PostRetornaRota(List<coordenada> Coordenadas)
        {
            if (Coordenadas.Count > 1 && Coordenadas.Count < 3)
            {
                var decDistancia = Calculo.Distance(Convert.ToDouble(Coordenadas[0].latitude), Convert.ToDouble(Coordenadas[0].longitude), Convert.ToDouble(Coordenadas[1].latitude), Convert.ToDouble(Coordenadas[1].longitude), 'K');
                return Math.Round(decDistancia, 2).ToString();
            }
            else
            {
                //throw new ArgumentException("Parametro incorreto!");
                return "Coordenadas vazias ou incorretas!";

            }
        }
    }
}
