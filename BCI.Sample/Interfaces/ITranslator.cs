namespace BCI.SharedCores.Interfaces
{
    public interface ITranslator<Tout, Tin>
    {
        Tout Translate(Tin input);
    }
}