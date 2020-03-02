using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class FindWeaponState : BaseState<AISharedContexts>
    {
        private SpawnPoint _ammunitionSpawnPoint;
        public FindWeaponState(AISharedContexts sharedContext) : base(sharedContext) {
        }

        public override void OnStateEnter() {
            base.OnStateEnter();

            FindClosestSpawnPoint();
            Debug.Log($"[{GetType().Name}][OnStateEnter] OK");
        }

        public override void Execute() {
            Debug.Log($"[{GetType().Name}][Execute] OK");
            if (_sharedContext.Human.Human.IsWeaponExist) {
                _stateSwitcher.Switch(typeof(IdleState));
            }
            else {
                CheckAmmunitionPoint();
            }
            
        }

        private float _distanceEpsilon = 1f;
        private void CheckAmmunitionPoint() {
            var distance = Vector3.Distance(_ammunitionSpawnPoint.transform.position, _sharedContext.Human.transform.position);
            if (distance < _distanceEpsilon) {
                FindNextPoint();
            }
        }

        private void FindClosestSpawnPoint() {
            _ammunitionSpawnPoint = MainGameDataHolder.AmminitionSpawnPoints.GetNearestPosition(_sharedContext.Human.transform.position);
            _sharedContext.MotionBehaviour.SetTarget(_ammunitionSpawnPoint.transform.position);
        }

        private void FindNextPoint() {
            _ammunitionSpawnPoint = MainGameDataHolder.AmminitionSpawnPoints.GetRandomSpawnPointExceptCurrent(_sharedContext.Human.transform.position);
            _sharedContext.MotionBehaviour.SetTarget(_ammunitionSpawnPoint.transform.position);
        }
    }
}