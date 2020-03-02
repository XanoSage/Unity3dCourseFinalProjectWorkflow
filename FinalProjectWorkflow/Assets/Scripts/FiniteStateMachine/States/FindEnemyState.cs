using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FSM
{
    public class FindEnemyState : BaseState<AISharedContexts>
    {
        private SpawnPoint _humanSpawnPoint;
        public FindEnemyState(AISharedContexts sharedContext) : base(sharedContext) {
        }
        public override void OnStateEnter() {
            base.OnStateEnter();

            FindClosestSpawnPoint();
            Debug.Log($"[{GetType().Name}][OnStateEnter] OK");
        }

        public override void Execute() {
            //while target is Null - Find Target
            Debug.Log($"[{GetType().Name}][Execute] OK");
            CheckHumanPoint();
        }

        private float _distanceEpsilon = 2f;
        private void CheckHumanPoint() {
            var distance = Vector3.Distance(_humanSpawnPoint.transform.position, _sharedContext.Human.transform.position);
            if (distance < _distanceEpsilon) {
                FindNextPoint();
            }
        }

        private void FindClosestSpawnPoint() {
            _humanSpawnPoint = MainGameDataHolder.HumanSpawnPoints.GetNearestPosition(_sharedContext.Human.transform.position);
            _sharedContext.MotionBehaviour.SetTarget(_humanSpawnPoint.transform.position);
        }

        private void FindNextPoint() {
            _humanSpawnPoint = MainGameDataHolder.AmminitionSpawnPoints.GetRandomSpawnPointExceptCurrent(_sharedContext.Human.transform.position);
            _sharedContext.MotionBehaviour.SetTarget(_humanSpawnPoint.transform.position);
        }
    }
}