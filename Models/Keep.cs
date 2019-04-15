namespace keepr.Models
{
  public class Keep // HELPER MODEL
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int Views { get; set; }
    public int Keeps { get; set; }
    public int Shares { get; set; }
    public bool Private { get; set; }
  }
}