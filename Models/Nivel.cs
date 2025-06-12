namespace TP05_SalaDeEscape;
using Newtonsoft.Json;
public class Nivel
{
    [JsonProperty]
    public string[] respuestas {get; private set;}
    [JsonProperty]
    public int numNivel {get; private set;}

    [JsonProperty]
    public string[] pistas {get; private set;}
    public Nivel()
    {
        this.respuestas = new string[5];
        this.pistas = new string[5];
    }
    public void InicializarNivel1()
    {
        respuestas[0] = "erbilorgamla";
        numNivel = 1;
        pistas[0] = "Piensa al reves de como lo sueles hacer...";
        
    }

    public void InicializarNivel2()
    {
        respuestas[1] = "CERIANA";
        numNivel = 2;
        pistas[1] = "4 palabras: Barba, Lentes, Mate y HTML";
    }

       public void InicializarNivel3()
    {
        respuestas[2] = null;
        numNivel = 3;
        pistas[2] = "Gracias a mi ves todo lo que ves...";
    }

       public void InicializarNivel4()
    {
        respuestas[3] = "Fotos_Privadas.png,Contraseña_Gmail.txt,bestChatGPTPrompts.txt,troyano.bat,chatPrivado.txt";
        numNivel = 4;
        pistas[3] = "maximo 5 solo capos only caps";
    }

       public void InicializarNivel5()
    {
        respuestas[4] = "531426";
        numNivel = 5;
        pistas[4] = "Como dijo Leo: MVC = Model, View, Controller.";
    }
    //debe haber varios inicializarNivel y estos seran usados en cada action...

    public bool comprobarRespuesta(string respuesta, int nivel)
    {
        bool aux = false;
        if(respuesta == respuestas[nivel-1])
        {
            aux = true;
        }
        return aux;
    }

    
}
