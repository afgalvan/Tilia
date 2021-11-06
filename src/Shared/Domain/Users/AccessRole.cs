using System.Collections.Generic;

namespace Domain.Users
{
    public class AccessRole
    {
        public string           Name       { get; set; }
        public IList<Privilege> Privileges { get; set; }

        public void AddPrivilege(Privilege privilege)
        {
            Privileges.Add(privilege);
        }
    }
}
