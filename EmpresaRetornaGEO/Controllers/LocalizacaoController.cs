
using Microsoft.AspNetCore.Mvc;
using EmpresaRetornaGEO.Model;
using EmpresaRetornaGEO.Domain;
using System;
using System.Collections.Generic;


namespace EmpresaRetornaGEO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacaoController : ControllerBase
    {
        [HttpGet]
        public coordenada Get(string endereco)
        {
            coordenada obj = new coordenada();

            if (!string.IsNullOrEmpty(endereco))
            {   
                Random rnd = new Random();
                obj.latitude = rnd.Next(-99, 99).ToString() + ',' + rnd.Next(99999).ToString();
                obj.longitude = rnd.Next(-99, 99).ToString() + ',' + rnd.Next(99999).ToString();
                obj.error = "";                
            }
            else
            {
                obj.error = "Endereço vazio ou incorreto!";
            }

            return obj;

        }


        [HttpPost]        
        public string PostRetornaDistancia(List<coordenada> Coordenadas)
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
