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
        respuestas[0] = "ERBILORGAMLA";
        numNivel = 1;
        pistas[0] = "Piensa al REVES de como lo sueles hacer...";
        
    }

    public void InicializarNivel2()
    {
        respuestas[1] = "CERIANA";
        pistas[1] = "4 palabras: Barba, Lentes, Mate y HTML";
    }

       public void InicializarNivel3()
    {
        respuestas[2] = null;
        pistas[2] = "Yo doy el poder...";
    }

       public void InicializarNivel4()
    {
        respuestas[3] = "Fotos_Privadas.png,Contraseña_Gmail.txt,bestChatGPTPrompts.txt,troyano.bat,chatPrivado.txt";
        pistas[3] = "Maximo 5 solo capos only caps | Selecciona los archivos que el GIT IGNORaria.";
    }
       public void PaseDeSala()
    {
        numNivel++;
    }
    
       public void InicializarNivel5()
    {
        respuestas[4] = "352416";
        pistas[4] = "Como dijo Leo: MVC = Model, View, Controller.";
    }

    public bool comprobarRespuesta(string respuesta, int nivel)
    {
        bool aux = false;
        if(respuesta == respuestas[nivel-1])
        {
            aux = true;

            numNivel++;
        }
        return aux;
    }

    
}
