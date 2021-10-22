using System.Collections.Generic;

namespace Domain.Users
{
    public class AccessRole
    {
        public string                 Name       { get; set; }
        public IEnumerable<Privilege> Privileges { get; set; }
    }
}
