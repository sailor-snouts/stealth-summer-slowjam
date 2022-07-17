using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Runtime.Credit
{
    public class CreditRole
    {
        [field: SerializeField] public string Role { get; set; }
        [field: SerializeField] public List<string> Names { get; set; }

        public CreditRole(string role, List<string> names)
        {
            Role = role;
            Names = names;
        }
    }
}