using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Bonfire.Combat
{
    //IEventSystemHandlerを継承させる
    public interface IAttackDamage : IEventSystemHandler
    {
        void OnDamaged(AttackInfo attackInfo);
    }
}