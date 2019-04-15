namespace keepr.Models
{
  public class Keep // HELPER MODEL
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public int Views { get; set; }
    public int Keeps { get; set; }
    public int Shares { get; set; }
    public bool Private { get; set; }
  }
}