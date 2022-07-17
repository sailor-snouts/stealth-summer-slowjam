using System.Collections.Generic;
using System.Linq;

namespace Scripts.Runtime.Credit
{
    public class Credits
    {
        private Dictionary<string, CreditName> ByName { get; set; } = new Dictionary<string, CreditName>();
        private Dictionary<string, CreditRole> ByRole { get; set; } = new Dictionary<string, CreditRole>();

        public Credits(IEnumerable<CreditName> credits)
        {
            foreach (var credit in credits)
            {
                if (!ByName.ContainsKey(credit.Name))
                    ByName.Add(credit.Name, credit);

                foreach (var role in credit.Roles)
                {
                    if (!ByRole.ContainsKey(role))
                        ByRole.Add(role, new CreditRole(role, new List<string>()));

                    ByRole[role].Names.Add(credit.Name);
                }
            }
        }
        
        public List<CreditName> GroupedByName()
        {
            return ByName.Values.ToList();
        }
        
        public List<CreditRole> GroupedByRole()
        {
            return ByRole.Values.ToList();
        }
    }
}