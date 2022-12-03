using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;

namespace GamesTan.ECS.Game {
    public partial class MapData : IContext {
        public Dictionary<int2,int> pos2Type = new Dictionary<int2, int>();

        public const int ETypeNone = 0;
        public const int ETypeWall = 1;
        public const int ETypePlayer = 2;
        public const int ETypeEnemy = 3;
        public const int ETypeItem = 4;
        public const int ETypeExit = 5;
        public const int ETypeOutWall = 6;


        public bool IsNone(int2 pos) =>GetTile(pos) == ETypeNone;
        public bool IsWall(int2 pos) => GetTile(pos) == ETypeWall;
        public bool IsPlayer(int2 pos) => GetTile(pos) == ETypePlayer;
        public bool IsItem(int2 pos) =>GetTile(pos) == ETypeItem;
        public bool IsEnemy(int2 pos) => GetTile(pos) == ETypeEnemy;

        public bool IsNone(int val) => val == ETypeNone;
        public bool IsWall(int val) => val == ETypeWall;
        public bool IsPlayer(int val) => val == ETypePlayer;
        public bool IsItem(int val) => val == ETypeItem;
        public bool IsEnemy(int val) => val == ETypeEnemy;
        
        public void SetNone(int2 pos) => SetTile(pos,ETypeNone) ;
        public void SetWall(int2 pos) => SetTile(pos,ETypeWall) ;
        public void SetPlayer(int2 pos) => SetTile(pos,ETypePlayer);
        public void SetItem(int2 pos) =>SetTile(pos,ETypeItem) ;
        public void SetEnemy(int2 pos) => SetTile(pos,ETypeEnemy) ;
        

        public bool IsOutWall(int val) => val == ETypeOutWall;
        public bool IsOutWall(int2 pos) => GetTile(pos) == ETypeOutWall;
        public void SetOutWall(int2 pos) => SetTile(pos,ETypeOutWall) ;
        
        public int GetTile(int x, int y ) => pos2Type[new int2(x, y)];
        public int GetTile(int2 pos) => pos2Type[pos];
        public void SetTile(int2 pos, int type) => pos2Type[pos] = type;
        public void SetTile(int x, int y, int type) => pos2Type[new int2(x, y)] = type;
        public bool IsTile(int2 pos, int type) => pos2Type[pos] == type;
        public bool IsTile(int x, int y, int type) => pos2Type[new int2(x, y)] == type;
        public bool IsExit(int2 pos) =>  IsTile(pos,ETypeExit);

        public void ResetMap() {
            for (int x = 0; x < GameDefine.MapSizeX; x++) {
                for (int y = 0; y < GameDefine.MapSizeY; y++) {
                    pos2Type[new int2(x, y)] = ETypeOutWall;
                }
            }
            for (int x = 1; x < GameDefine.MapSizeX-1; x++) {
                for (int y = 1; y < GameDefine.MapSizeY-1; y++) {
                    pos2Type[new int2(x, y)] = ETypeNone;
                }
            }
        }

        public bool CanMove(int2 pos) => IsNone(pos)|| IsItem(pos)|| IsExit(pos) ;

        public void MoveTo(int type, int2 srcPos, int2 dstPos) {
            SetTile(srcPos,ETypeNone); 
            SetTile(dstPos,type);
        }
    }
}