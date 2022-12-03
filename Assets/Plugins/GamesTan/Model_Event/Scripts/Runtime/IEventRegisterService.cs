// Copyright 2019 谭杰鹏. All Rights Reserved //https://github.com/JiepengTan 

using System;

namespace GamesTan {
    public interface IEventRegisterService  {

        void RegisterEvent(object obj) ;
        void UnRegisterEvent(object obj) ;

        void DealEvent<TEnum, TDelegate>(string prefix, int ignorePrefixLen,
            Action<TEnum, TDelegate> callBack, object obj)
            where TDelegate : Delegate
            where TEnum : struct;

    }
}