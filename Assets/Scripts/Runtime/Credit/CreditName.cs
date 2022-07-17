using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Runtime.Credit
{
    [Serializable]
    public class CreditName
    {
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField] public List<string> Roles { get; set; }
        
        public CreditName(string name, List<string> roles)
        {
            Name = name;
            Roles = roles;
        }
    }
}