using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bonfire.Combat
{
    using UnityEngine;
    
    public class AttackInfo {
        [SerializeField] public Transform attacker = null;
        [SerializeField] public int attackCount = 0;
        [SerializeField] public int weaponDamage = 1;
    }
}