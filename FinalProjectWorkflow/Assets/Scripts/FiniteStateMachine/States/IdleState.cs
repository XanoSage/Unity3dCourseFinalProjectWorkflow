using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{

    public class IdleState : BaseState<AISharedContexts>
    {
        public IdleState(AISharedContexts sharedContext) : base(sharedContext) {
        }

        public override void OnStateEnter() {
            base.OnStateEnter();
            Debug.Log($"[{GetType().Name}][OnStateEnter] OK");
        }
        public override void Execute() {
            Debug.Log($"[{GetType().Name}][Execute] OK");
            if (_sharedContext.IsWeaponExist) {
                if (_sharedContext.IsWeaponClipEmpty) {
                    _stateSwitcher.Switch(typeof(FindWeaponState));
                }
                else {
                    _stateSwitcher.Switch(typeof(FindEnemyState));
                }
                //trying to find enemy
                //
            }
            else {
                _stateSwitcher.Switch(typeof(FindWeaponState));
            }
        }
    }
}