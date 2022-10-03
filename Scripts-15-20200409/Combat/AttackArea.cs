using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Bonfire.Combat
{
    public class AttackArea : MonoBehaviour
    {
        AttackInfo attackInfo = null;
        public int attackCount = 0;

        AttackAreaActivator attackAreaActivator = null;

        private void Start()
        {
            attackAreaActivator = transform.root.GetComponent<AttackAreaActivator>();
            attackAreaActivator.SetAttackArea();
        }

        void setAttackInfo()
        {
            attackInfo = new AttackInfo();
            attackInfo.attacker = transform.root;
            attackInfo.attackCount = attackCount;
            attackInfo.weaponDamage = 20;
        }
        private void OnTriggerEnter(Collider other)
        {
            setAttackInfo();

            // Debug.Log(string.Format("Hit: {0}: send damage", transform.root.ToString()));

            ExecuteEvents.Execute<IAttackDamage>(
                target: other.gameObject,
                eventData: null,
                functor: (reciever, eventData) => reciever.OnDamaged(attackInfo)
            );
        }
    }

}