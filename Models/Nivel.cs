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


    public void InicializarNivel1()
    {
        
    }
    //debe haber varios inicializarNivel y estos seran usados en cada action...


    
}
