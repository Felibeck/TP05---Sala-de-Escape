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
        return RedirectToAction("Nivel1");
    }
    public IActionResult Nivel1()
    {
        Nivel niveles = Objeto.StringToObject<Nivel>(HttpContext.Session.GetString("niveles")) ;
        if(niveles.numNivel != 1)
        {
            return View("Nivel"+niveles.numNivel);
        }
        ViewBag.pista = niveles.pistas[0];
        return View();
    }
    [HttpPost]
    public IActionResult Nivel1(string rta)
    {
        Nivel niveles = Objeto.StringToObject<Nivel>(HttpContext.Session.GetString("niveles")) ;
        ViewBag.pista = niveles.pistas[0];

        if(niveles.comprobarRespuesta(rta, niveles.numNivel))
        {
            HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
            return RedirectToAction("Nivel2");
        }else return View ();
    }


 public IActionResult Nivel2()
    {
        Nivel niveles = Objeto.StringToObject<Nivel>(HttpContext.Session.GetString("niveles")) ;
        if(niveles.numNivel != 2)
        {
            return View("Nivel"+niveles.numNivel);
        }
        niveles.InicializarNivel2();
        ViewBag.pista = niveles.pistas[1];
        return View();
    }

    [HttpPost]
    public IActionResult Nivel2(string rta)
    {
        Nivel niveles = Objeto.StringToObject<Nivel>(HttpContext.Session.GetString("niveles"));
        HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
        ViewBag.pista = niveles.pistas[1];
        niveles.InicializarNivel2();
        if(niveles.comprobarRespuesta(rta.ToUpper(), niveles.numNivel))
        {
            HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
            return RedirectToAction("Nivel3");
        }else return View ();
    }


    public IActionResult Nivel3()
    {
        Nivel niveles = Objeto.StringToObject<Nivel>(HttpContext.Session.GetString("niveles")) ;
        if(niveles.numNivel != 3)
        {
            return View("Nivel"+niveles.numNivel);
        }
        niveles.InicializarNivel3();
        ViewBag.pista = niveles.pistas[2];
        return View();
    }

    [HttpPost]
     public IActionResult Nivel3(string rta)
    {
        Nivel niveles = Objeto.StringToObject<Nivel>(HttpContext.Session.GetString("niveles"));
        HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
        ViewBag.pista = niveles.pistas[2];
        niveles.InicializarNivel3();
        if(niveles.comprobarRespuesta(rta, niveles.numNivel))
        {
            HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
            return RedirectToAction("Nivel4");
        }else return View();
    }

public IActionResult Nivel4(string err ="")
    {
        Nivel niveles = Objeto.StringToObject<Nivel>(HttpContext.Session.GetString("niveles")) ;
        if (err=="mfdfkghfdgkjfkjhgf") niveles.PaseDeSala();
        if(niveles.numNivel != 4)
        {
            return View("Nivel"+niveles.numNivel);
        }
        HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
        niveles.InicializarNivel4();
        ViewBag.pista = niveles.pistas[3];
        return View();
    }

    [HttpPost]

         public IActionResult Nivel4(string[] rta)
    {
        Nivel niveles = Objeto.StringToObject<Nivel>(HttpContext.Session.GetString("niveles"));
        niveles.InicializarNivel4();
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
            return RedirectToAction("Nivel5");
        }else return View("Nivel4");
    }


    public IActionResult Nivel5()
    {
        Nivel niveles = Objeto.StringToObject<Nivel>(HttpContext.Session.GetString("niveles")) ;
        niveles.InicializarNivel5();
        if(niveles.numNivel != 5)
        {
            return View("Nivel"+niveles.numNivel);
        }
        ViewBag.pista = niveles.pistas[4];
        return View();
    }

    [HttpPost]
     public IActionResult Nivel5(string rta)
    {
        Nivel niveles = Objeto.StringToObject<Nivel>(HttpContext.Session.GetString("niveles"));
        niveles.InicializarNivel5();
        HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
        ViewBag.pista = niveles.pistas[4];

        if(niveles.comprobarRespuesta(rta, niveles.numNivel))
        {
            HttpContext.Session.SetString("niveles", Objeto.ObjectToString(niveles));
            return RedirectToAction("Ganar");
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
