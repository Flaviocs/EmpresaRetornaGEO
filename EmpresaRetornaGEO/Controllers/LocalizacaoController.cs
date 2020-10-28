
using Microsoft.AspNetCore.Mvc;
using EmpresaRetornaGEO.Model;
using System;
using System.Text;
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
            
            Random rnd = new Random();
            obj.latitude = rnd.Next(-99, 99).ToString() + ',' + rnd.Next(99999).ToString();
            obj.longitude = rnd.Next(-99, 99).ToString() + ',' + rnd.Next(99999).ToString();

            return obj;            
        }

        [HttpGet("{id}")]
        public double Get(List<coordenada> Coordenadas)
        {
            
            return Distance(Convert.ToDouble(Coordenadas[0].latitude), Convert.ToDouble(Coordenadas[0].longitude), Convert.ToDouble(Coordenadas[1].latitude), Convert.ToDouble(Coordenadas[1].longitude), 'K');
        }


        protected static double Distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double deg2radMultiplier = Math.PI / 180;
            lat1 = lat1 * deg2radMultiplier;
            lon1 = lon1 * deg2radMultiplier;
            lat2 = lat2 * deg2radMultiplier;
            lon2 = lon2 * deg2radMultiplier;

            double radius = 6378.137; // earth mean radius defined by WGS84
            double dlon = lon2 - lon1;
            double distance = Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(dlon)) * radius;

            if (unit == 'K')
            {
                return (distance);
            }
            else if (unit == 'M')
            {
                return (distance * 0.621371192);
            }
            else if (unit == 'N')
            {
                return (distance * 0.539956803);
            }
            else
            {
                return 0;
            }
        }
    }
}
