// Copyright 2019 谭杰鹏. All Rights Reserved //https://github.com/JiepengTan 

namespace GamesTan {
    /// 框架内部信息 取值范围 [0~ 1000)
    public enum EEvent {
        // room 
        OnRoomListRefresh = 100,
        OnRoomPlayerListRefresh = 101,
        OnRoomKickOut = 102,
        
        // 服务器创建关卡完成
        OnServerConnect = 200,//连接到目标战斗服务器
        OnServerGameCreate = 201,//战斗服务器创建战斗完成
        
        // 关卡加载
        OnSimulationAwake = 300,//类似 DoAwake
        OnLevelLoadProgress = 301,//开始加载地图 本地load progress
        OnLevelLoadDone= 302,    //地图加载完成
        OnServerLoadingProgress= 303,//Server notify load progress
        OnServerAllPlayerFinishedLoad= 304,//Server notify all user finished load
        OnSimulationStart= 305,//类似 DoStart
        
        // video
        VideoLoadProgress= 400,
        VideoLoadDone= 401,
        
        // 断线重连
        ReconnectLoadProgress= 410,//重连进度
        ReconnectLoadDone= 411,//重连完成
        // 追帧
        PursueFrameProcess= 420,//追帧进度
        PursueFrameDone= 421,//追帧进度
        
        // Fighting 
        OnPlayerPing= 500,
        OnServerFrame= 501,
        OnServerMissFrame= 502,
        OnServerGameDone= 503, // 服务器下发 游戏结束
        OnRollBack= 504,
        
        //数据
        OnServerPlayerStatusChanged= 600, //全局状态改变
        OnServerPlayerPropertyChanged= 601,// 玩家属性变化
        OnGamePlayerPropertyChange= 602,// 游戏中 玩家属性变化 
        
        //游戏状态
        OnGameStart= 700,
        OnGamePause= 701,
        OnGameResume= 702,
        OnGameWin= 703,
        OnGameFailed= 704,
        
        // 玩家战斗事件
        OnFightHitInfo = 800, //攻击伤害
        
    }
}