using Microsoft.AspNetCore.Identity;

namespace ConsoleEFCore.Models
{
  public class Usuario: IdentityUser
  {
    public override string ToString()
    {
      return $"Id({Id}) - Nome({UserName})";
    }
  }
}

