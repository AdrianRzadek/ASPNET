using System.ComponentModel;

namespace ASP.Repository
{
    public enum ServiceResultStatus
    {
        [Description("Błąd")]
        Error = 0,
        [Description("Sukces")]
        Succes = 1,
        [Description("Ostrzeżenie")]
        Warrnig,
        [Description("Informacja")]
        Info,
    }
    public class RepositoryServiceResult
    {
        public ServiceResultStatus Result { get; set; }
        public ICollection<String> Messages { get; set; }
        public RepositoryServiceResult()
        {
            Result = ServiceResultStatus.Succes;
            Messages = new List<string>();
        }
        public static Dictionary<string, RepositoryServiceResult> CommonResults { get; set; } = new Dictionary<string,
        RepositoryServiceResult>()
        {
            {"NotFound" , new RepositoryServiceResult() {
                Result =ServiceResultStatus.Error,
                Messages = new List<string>( new string[] { "Nie znaleziono obiektu" }) 
            } },
            {"OK" , new RepositoryServiceResult() {
            Result =ServiceResultStatus.Succes,
            Messages = new List<string>() } }
        };


    }
}