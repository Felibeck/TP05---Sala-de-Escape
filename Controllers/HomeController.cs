using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP05_SalaDeEscape.Models;

namespace TP05_SalaDeEscape.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        return View();
    }
    public IActionResult Jugar()
    {
        Nivel niveles = new Nivel();
        niveles.InicializarNivel1();
        HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
        ViewBag.pista = niveles.pistas[0];
        return View();
    }


    public IActionResult Nivel1(string rta)
    {
        Nivel niveles = Objeto.StringToObject<Nivel>(HttpContext.Session.GetString("niveles")) ;
        if(niveles.comprobarRespuesta(rta, niveles.numNivel))
        {
            HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
            return View("Nivel2");
        }else return View();
    }

    public IActionResult Nivel2(string rta)
    {
        Nivel niveles = Objeto.StringToObject<Nivel>(HttpContext.Session.GetString("niveles"));
        niveles.InicializarNivel2();
        if(!niveles.verificarAvance(2))
        {
            return View("Jugar");
        }
        HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
        ViewBag.pista = niveles.pistas[1];

        if(niveles.comprobarRespuesta(rta, niveles.numNivel))
        {
            HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
            return View("Nivel3");
        }else return View();
    }

     public IActionResult Nivel3(string rta)
    {
        Nivel niveles = Objeto.StringToObject<Nivel>(HttpContext.Session.GetString("niveles"));
        niveles.InicializarNivel3();
        if(!niveles.verificarAvance(3))
        {
            return View("Jugar");
        }
        HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
        ViewBag.pista = niveles.pistas[2];

        if(niveles.comprobarRespuesta(rta, niveles.numNivel))
        {
            HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
            return View("Nivel4");
        }else return View();
    }

         public IActionResult Nivel4(string[] rta)
    {
        Nivel niveles = Objeto.StringToObject<Nivel>(HttpContext.Session.GetString("niveles"));
        niveles.InicializarNivel4();
        if(!niveles.verificarAvance(4))
        {
            return View("Jugar");
        }
        HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
        ViewBag.pista = niveles.pistas[3];


        string resp = "";
        for (int i = 0; i < rta.Length; i++)
        {
        resp += rta[i];

        if (i < rta.Length - 1)
        {
        resp += ",";
        }
        }
        
        if(niveles.comprobarRespuesta(resp, niveles.numNivel))
        {
            HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
            return View("Nivel5");
        }else return View();
    }

     public IActionResult Nivel5(string rta)
    {
        Nivel niveles = Objeto.StringToObject<Nivel>(HttpContext.Session.GetString("niveles"));
        niveles.InicializarNivel5();
        if(!niveles.verificarAvance(5))
        {
            return View("Jugar");
        }
        HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
        ViewBag.pista = niveles.pistas[4];

        if(niveles.comprobarRespuesta(rta, niveles.numNivel))
        {
            HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
            return View("Ganar");
        }else return View();
    }
    public IActionResult Ganar()
    {
        return View();
    }

    public IActionResult Tutorial()
    {
        return View();
    }
    public IActionResult Creditos()
    {
        return View();
    }
}
