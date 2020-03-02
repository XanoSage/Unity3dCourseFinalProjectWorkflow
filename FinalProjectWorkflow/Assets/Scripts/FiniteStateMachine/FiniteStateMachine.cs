using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FSM
{
    public class AISharedContexts
    {
        public HumanBehaviour Human;
        public ShootableComponent Shootable;
        public AIMotionBehaviour MotionBehaviour;

        public bool IsWeaponExist => Human.Human.IsWeaponExist;
        public bool IsWeaponClipEmpty => Human.Human.IsWeaponClipEmpty;
        public bool IsWeaponBulletEmpty => Human.Human.IsWeaponBulletEmpty;
    }

    public interface IStateSwitcher<T> where T:class
    {
        void Switch(Type nextState);
    }
    public class FiniteStateMachine<T> : IStateSwitcher<T>
        where T : class
    {
        private Dictionary<Type, BaseState<T>> _states = new Dictionary<Type, BaseState<T>>();

        private BaseState<T> _currentState;
        private BaseState<T> _previousState;
        public void InitStates(Dictionary<Type, BaseState<T>> states) {
            _states = states;
            foreach (var state in _states) {
                state.Value.InitSwitcher(this);
            }
        }

        public void AddState(BaseState<T> state) {
            var key = state.GetType();
            _states.Add(key, state);
            state.InitSwitcher(this);
        }

        public void Switch(Type nextState) {
            if (!_states.ContainsKey(nextState)) {
                return;
            }

            if (_currentState != null) {
                _currentState.OnStateExit();
            }

            _currentState = _states[nextState];
            _currentState.OnStateEnter();
        }

        public void Update() {
            if (_currentState != null) {
                _currentState.Execute();
            }
        }
        
    }
}