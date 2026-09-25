using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Application.DTOs
{
    public record CreateClientRequest(string Dni, string Name, string LastName, string Mail, string PassWordHash, string Address, string Phone);
}
