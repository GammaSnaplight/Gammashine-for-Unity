using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace Snaplight
{
    public static class Behaviour
    {
        private static readonly HashSet<IInput> _inputUpdate = new();
        private static readonly HashSet<IControl> _controlUpdate = new();
        private static readonly HashSet<IUnder> _underUpdate = new();
        private static readonly HashSet<IUnderFixed> _underFixedUpdate = new();

        public static void Playback(IBehavioral behavioral)
        {
            switch (behavioral)
            {
                case IInput input:
                    _inputUpdate.Add(input);
                    break;
                case IControl control:
                    _controlUpdate.Add(control);
                    break;
                case IUnder under:
                    _underUpdate.Add(under);
                    break;
                case IUnderFixed underFixed:
                    _underFixedUpdate.Add(underFixed);
                    break;
                default:
                    break;
            }
        }

        public static void Shutdown(IBehavioral behavioral)
        {
            switch (behavioral)
            {
                case IInput input:
                    _inputUpdate.Remove(input);
                    break;
                case IControl control:
                    _controlUpdate.Remove(control);
                    break;
                case IUnder under:
                    _underUpdate.Remove(under);
                    break;
                case IUnderFixed underFixed:
                    _underFixedUpdate.Remove(underFixed);
                    break;
                default:
                    break;
            }
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Collection()
        {
            PlayerLoopSystem defaultSystems = PlayerLoop.GetDefaultPlayerLoop();

            PlayerLoopSystem input = new()
            {
                subSystemList = null,
                updateDelegate = Inputted,
                type = typeof(IInput)
            };

            PlayerLoopSystem control = new()
            {
                subSystemList = null,
                updateDelegate = Controlled,
                type = typeof(IControl)
            };

            PlayerLoopSystem under = new()
            {
                subSystemList = null,
                updateDelegate = Under,
                type = typeof(IUnder)
            };

            PlayerLoopSystem @fixed = new()
            {
                subSystemList = null,
                updateDelegate = Fixed,
                type = typeof(IUnderFixed)
            };

            PlayerLoopSystem loopInput = AddSystem<PreUpdate>(in defaultSystems, input);
            PlayerLoopSystem loopControl = AddSystem<PreUpdate>(in loopInput, control);
            PlayerLoopSystem loopUnder = AddSystem<Update>(in loopControl, under);
            PlayerLoopSystem loopFixed = AddSystem<FixedUpdate>(in loopUnder, @fixed);
            PlayerLoop.SetPlayerLoop(loopFixed);
            //PlayerLoopSystem loopWithSuperLateUpdate = AddSystem<PreLateUpdate>(in defaultSystems, input);
            //PlayerLoopSystem loopWithEarlyAndSuperLateUpdate = AddSystem<PreUpdate>(in loopWithSuperLateUpdate, control);
            //PlayerLoop.SetPlayerLoop(loopWithEarlyAndSuperLateUpdate);

            static PlayerLoopSystem AddSystem<T>(in PlayerLoopSystem loopSystem, PlayerLoopSystem systemToAdd) where T : struct
            {
                PlayerLoopSystem newPlayerLoop = new()
                {
                    loopConditionFunction = loopSystem.loopConditionFunction,
                    type = loopSystem.type,
                    updateDelegate = loopSystem.updateDelegate,
                    updateFunction = loopSystem.updateFunction
                };

                List<PlayerLoopSystem> newSubSystemList = new();

                foreach (PlayerLoopSystem subSystem in loopSystem.subSystemList)
                {
                    newSubSystemList.Add(subSystem);

                    if (subSystem.type == typeof(T))
                        newSubSystemList.Add(systemToAdd);
                }

                newPlayerLoop.subSystemList = newSubSystemList.ToArray();
                return newPlayerLoop;
            }
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Inputted()
        {
            using HashSet<IInput>.Enumerator e = _inputUpdate.GetEnumerator();
            while (e.MoveNext())
            {
                e.Current?.InputUpdate();
            }
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Controlled()
        {
            using HashSet<IControl>.Enumerator e = _controlUpdate.GetEnumerator();
            while (e.MoveNext())
            {
                e.Current?.ControlUpdate();
            }
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Under()
        {
            using HashSet<IUnder>.Enumerator e = _underUpdate.GetEnumerator();
            while (e.MoveNext())
            {
                e.Current?.UnderUpdate();
            }
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Fixed()
        {
            using HashSet<IUnderFixed>.Enumerator e = _underFixedUpdate.GetEnumerator();
            while (e.MoveNext())
            {
                e.Current?.UnderFixedUpdate();
            }
        }
    }
}
