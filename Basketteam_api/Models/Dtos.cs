namespace Basketteam_api.Models
{
    public record CreatePlayer ( string Name, int Height, int Weight);
    public record UpdatePlayer (string Name, int Height, int Weight);
    public record Postmatchdata (int Try, int Goal, int Fault, string PlayerId);
    public record Updatematchdata (int Try, int Goal, int Fault);
}
