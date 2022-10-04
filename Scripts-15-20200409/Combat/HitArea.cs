using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bonfire.Combat
{
    public class HitArea : MonoBehaviour, IAttackDamage
    {
        PlayerStatus status = null;

        private void Start()
        {
            status = transform.parent.GetComponent<PlayerStatus>();
        }

        public void OnDamaged(AttackInfo attackInfo)
        {
            // Debug.Log("get damage");
            status.HP -= attackInfo.weaponDamage;
        }
    }

}