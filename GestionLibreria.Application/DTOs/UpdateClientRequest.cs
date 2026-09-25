using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Application.DTOs
{
  public record UpdateClientRequest(string? Mail, string? PassWordHash, string? Address, string? Phone);
}
