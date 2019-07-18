using System.ComponentModel.DataAnnotations;

namespace bugserver.Models

{
  public class Bug
  {
    public int Id { get; set; }

    [Required]
    public string Creator { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }




  }




}