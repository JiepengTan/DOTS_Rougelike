// Copyright 2019 谭杰鹏. All Rights Reserved //https://github.com/JiepengTan 

#define DEBUG_EVENT_TRIGGER
#if UNITY_EDITOR || DEBUG_EVENT_TRIGGER
#define _DEBUG_EVENT_TRIGGER
#endif
using System;
using GamesTanEncrypt;

namespace GamesTan {
    public delegate void GlobalEventHandler(object param);

    public delegate void NetMsgHandler(object param);

    public partial class EventUtil {    
        public static void AddListener<TEnum>(TEnum type, GlobalEventHandler listener)
            where TEnum : struct {
            EventUtilImpl.AddListener((int) (object)type, listener);
        }
        public static void RemoveListener<TEnum>(TEnum type, GlobalEventHandler listener)
            where TEnum : struct {
            EventUtilImpl. RemoveListener((int) (object)type, listener);
        }

        public static void Trigger<TEnum>(TEnum type,object param = null)
            where TEnum : Enum {
            EventUtilImpl. Trigger((int) (object)type, param);
        }
        public static void RemoveAllListener(){
            EventUtilImpl. RemoveAllListener();
        }
    }
}