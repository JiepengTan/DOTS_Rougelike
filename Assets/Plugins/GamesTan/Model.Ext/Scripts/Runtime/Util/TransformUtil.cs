using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GamesTan {
    public static class TransformUtil {
        public static Vector3 RandomPos(Vector3 radius) {
            var x = Random.Range(-radius.x, radius.x);
            var y = Random.Range(-radius.y, radius.y);
            var z = Random.Range(-radius.z, radius.z);
            return new Vector3(x, y, z);
        }

        public static T GetOrAddComponent<T>(this Transform tran) where T : Component {
            return GetOrAddComponent<T>(tran.gameObject);
        }

        public static T GetOrAddComponent<T>(this GameObject go) where T : Component {
            T ret = go.GetComponent<T>();
            if (ret == null) {
                ret = go.AddComponent<T>();
            }

            return ret;
        }

        public static T GetOrAddComponent<T>(this Component go) where T : Component {
            T ret = go.GetComponent<T>();
            if (ret == null) {
                ret = go.gameObject.AddComponent<T>();
            }

            return ret;
        }

        public static T GetOrAddComponent<T>(this GameObject go, Type type) where T : Component {
            var ret = go.GetComponent<T>();
            if (ret == null) {
                var comp = go.AddComponent(type);
                ret = comp as T;
            }

            return ret;
        }

        public static Transform RecursiveFindChild(this Transform parent, string name) {
            Queue<Transform> queue = new Queue<Transform>();
            queue.Enqueue(parent);
            while (queue.Count > 0) {
                var trans = queue.Dequeue();
                if (trans.name == name) {
                    return trans;
                }

                foreach (Transform childTran in trans) {
                    queue.Enqueue(childTran);
                }
            }

            return null;
        }

        public static Transform RecursiveFindChild(this Transform parent, string name, Type targetType) {
            Queue<Transform> queue = new Queue<Transform>();
            queue.Enqueue(parent);
            while (queue.Count > 0) {
                var trans = queue.Dequeue();
                if (trans.name == name) {
                    if (targetType == typeof(GameObject)
                        || targetType == typeof(Transform))
                        return trans;
                    if (trans.gameObject.GetComponent(targetType) != null)
                        return trans;
                }

                foreach (Transform childTran in trans) {
                    queue.Enqueue(childTran);
                }
            }

            return null;
        }

        public static void RecvSetLayer(this Transform root, int layer) {
            if (root == null) return;
            var tran = root;
            var count = tran.childCount;
            root.gameObject.layer = layer;
            for (int i = 0; i < count; i++) {
                RecvSetLayer(tran.GetChild(i), layer);
            }
        }

        public static List<T> RecvGetComponents<T>(this GameObject root, bool isIncludeInactive = false,
            bool isRecvAll = false) {
            if (root == null) return null;
            return RecvGetComponents<T>(root.transform, isIncludeInactive, isRecvAll);
        }

        public static T RecvGetComponentInParent<T>(this Transform root) where T : Component {
            if (root == null) return null;
            var tran = root;
            while (tran != null) {
                var comp = tran.GetComponent<T>();
                if (comp != null)
                    return comp;
                tran = tran.parent;
            }
            return null;
        }

        public static List<T> RecvGetComponents<T>(this Transform root, bool isIncludeInactive = false,
            bool isRecvAll = false) {
            if (root == null) return null;
            var lst = new List<T>();
            _RecvGetComponents(root, lst, isIncludeInactive, isRecvAll);
            return lst;
        }

        private static void _RecvGetComponents<T>(Transform root, List<T> lst, bool isIncludeInactive = false,
            bool isRecvAll = false) {
            if (!isIncludeInactive && !root.gameObject.activeSelf) return;
            var comp = root.GetComponent<T>();
            if (comp != null) {
                lst.Add(comp);
                if (!isRecvAll) return;
            }

            foreach (Transform child in root) {
                _RecvGetComponents<T>(child, lst,isIncludeInactive,isRecvAll);
            }
        }

        public static void AttachToParent(this UnityEngine.Transform tran, Transform parent) {
            tran.SetParent(parent, false);
            tran.rotation = Quaternion.identity;
            tran.localPosition = Vector3.zero;
            tran.localScale = Vector3.one;
        }


        public static void DestroyExt(this UnityEngine.Transform trans) {
            if(trans == null) return;
            DestroyExt(trans.gameObject);
        }

        public static void DestroyExt(this UnityEngine.Object gameObject) {
            if(gameObject == null) return;
#if UNITY_EDITOR
            if (Application.isPlaying)
                UnityEngine.Object.Destroy(gameObject);
            else
                UnityEngine.Object.DestroyImmediate(gameObject);
#else
            UnityEngine.Object.Destroy(gameObject);
#endif
        }

        public static string HierarchyName(this Component comp) {
            return comp.transform.HierarchyName();
        }

        public static string HierarchyName(this GameObject go) {
            return go.transform.HierarchyName();
        }

        public static string HierarchyName(this Transform trans) {
            Stack<string> transNames = new Stack<string>();
            StringBuilder sb = new StringBuilder();
            while (trans != null) {
                transNames.Push(trans.name);
                trans = trans.parent;
            }

            while (transNames.Count > 0) {
                sb.Append(transNames.Pop());
                if (transNames.Count > 0) {
                    sb.Append("/");
                }
            }

            return sb.ToString();
        }
    }
}