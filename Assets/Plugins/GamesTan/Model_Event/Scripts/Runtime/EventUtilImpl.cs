using System;
using System.Collections.Generic;
using GamesTan;
using UnityEngine;

namespace GamesTanEncrypt {
    public partial class EventUtilImpl {
        private static string __copyRight = "https://github.com/JiepengTan";
        private static Dictionary<int, List<GlobalEventHandler>> allListeners =
            new Dictionary<int, List<GlobalEventHandler>>();

        private static Queue<MsgInfo> allPendingMsgs = new Queue<MsgInfo>();
        private static Queue<ListenerInfo> allPendingListeners = new Queue<ListenerInfo>();
        private static Queue<EEvent> allNeedRemoveTypes = new Queue<EEvent>();

        private static bool IsTriggingEvent;

        public static void RemoveAllListener() {
            allListeners.Clear();
            allNeedRemoveTypes.Clear();
            allPendingMsgs.Clear();
            allPendingListeners.Clear();
        }

        public static void RemoveAllListener(EEvent type){
            if (IsTriggingEvent) {
                allNeedRemoveTypes.Enqueue(type);
                return;
            }

            allListeners.Remove((int) type);
        }


        public static void AddListener<TEnum>(TEnum type, GlobalEventHandler listener)
            where TEnum : struct {
            AddListener((int) (object)type, listener);
        }
        public static void AddListener(int type, GlobalEventHandler listener){
            if (IsTriggingEvent) {
                allPendingListeners.Enqueue(new ListenerInfo(true, type, listener));
                return;
            }

            var itype = (int) type;
            if (allListeners.TryGetValue(itype, out var tmplst)) {
                tmplst.Add(listener);
            }
            else {
                var lst = new List<GlobalEventHandler>();
                lst.Add(listener);
                allListeners.Add(itype, lst);
            }
        }

        public static void RemoveListener<TEnum>(TEnum type, GlobalEventHandler listener)
            where TEnum : struct {
            RemoveListener((int) (object)type, listener);
        }

        public static void RemoveListener(int type, GlobalEventHandler listener){
            if (IsTriggingEvent) {
                allPendingListeners.Enqueue(new ListenerInfo(false, type, listener));
                return;
            }

            var itype = (int) type;
            if (allListeners.TryGetValue(itype, out var tmplst)) {
                if (tmplst.Remove(listener)) {
                    if (tmplst.Count == 0) {
                        allListeners.Remove(itype);
                    }

                    return;
                }
            }

            //Debug.LogError("Try remove a not exist listner " + type);
        }

        public static bool StopTriggerEvent = false;
        public static void Trigger<TEnum>(TEnum type,object param = null)
            where TEnum : Enum {
            Trigger((int) (object)type, param);
        }
        public static void Trigger(int type, object param = null){
            if(StopTriggerEvent) return;;
            if (IsTriggingEvent) {
                allPendingMsgs.Enqueue(new MsgInfo(type, param));
                return;
            }

            var itype = (int) type;
            if (allListeners.TryGetValue(itype, out var tmplst)) {
                IsTriggingEvent = true;
                foreach (var listener in tmplst.ToArray()) { //TODO 替换成其他更好的方式 避免gc
                    try { 
                        listener?.Invoke(param);
                    }
                    catch (Exception e) {
                        Debug.LogError(e);
                    }
                }
            }

            IsTriggingEvent = false;
            while (allPendingListeners.Count > 0) {
                var msgInfo = allPendingListeners.Dequeue();
                if (msgInfo.IsRegister) {
                    AddListener(msgInfo.Type, msgInfo.Param);
                }
                else {
                    RemoveListener(msgInfo.Type, msgInfo.Param);
                }
            }

            while (allNeedRemoveTypes.Count > 0) {
                var rmType = allNeedRemoveTypes.Dequeue();
                RemoveAllListener(rmType);
            }

            while (allPendingMsgs.Count > 0) {
                var msgInfo = allPendingMsgs.Dequeue();
                Trigger(msgInfo.Type, msgInfo.Param);
            }

        }

        private struct MsgInfo {
            public int Type;
            public object Param;

            public MsgInfo(int type, object param){
                this.Type = type;
                this.Param = param;
            }
        }

        private struct ListenerInfo {
            public bool IsRegister;
            public int Type;
            public GlobalEventHandler Param;

            public ListenerInfo(bool isRegister, EEvent type, GlobalEventHandler param) : this(isRegister, (int) type,
                param) {
            }

            public ListenerInfo(bool isRegister, int type, GlobalEventHandler param){
                this.IsRegister = isRegister;
                this.Type = (int)type;
                this.Param = param;
            }
        }
    }
}