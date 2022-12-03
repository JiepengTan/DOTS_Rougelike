// Copyright 2019 谭杰鹏. All Rights Reserved //https://github.com/JiepengTan 

using System;
using System.Reflection;
using GamesTan;
using GamesTanEncrypt;

namespace GamesTan {
    public class EventRegisterService : _EventRegisterService {
        public static IEventRegisterService Instance { get; protected set; }

        public EventRegisterService() {
            Instance = this;
        }
    }
}

namespace GamesTanEncrypt {
    public class _EventRegisterService : IEventRegisterService {
        public static T CreateDelegateFromMethodInfo<T>(System.Object instance, MethodInfo method) where T : Delegate {
            return Delegate.CreateDelegate(typeof(T), instance, method) as T;
        }

        public virtual void RegisterEvent(object obj) {
            DealEvent<EEvent, GlobalEventHandler>("OnEvent_", "OnEvent_".Length,
                EventUtil.AddListener, obj);
        }

        public virtual void UnRegisterEvent(object obj) {
            DealEvent<EEvent, GlobalEventHandler>("OnEvent_", "OnEvent_".Length,
                EventUtil.RemoveListener, obj);
        }

        public void DealEvent<TEnum, TDelegate>(string prefix, int ignorePrefixLen,
            Action<TEnum, TDelegate> callBack, object obj)
            where TDelegate : Delegate
            where TEnum : struct {
            if (callBack == null) return;
            var methods = obj.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic |
                                                   BindingFlags.Instance);
            foreach (var method in methods) {
                var methodName = method.Name;
                if (methodName.StartsWith(prefix)) {
                    var eventTypeStr = methodName.Substring(ignorePrefixLen);
                    if (Enum.TryParse(eventTypeStr, out TEnum eType)) {
                        try {
                            var handler = CreateDelegateFromMethodInfo<TDelegate>(obj, method);
                            callBack(eType, handler);
                        }
                        catch (Exception e) {
                            UnityEngine.Debug.LogError("methodName " + methodName + " e:" + e);
                            throw;
                        }
                    }
                }
            }
        }
    }
}