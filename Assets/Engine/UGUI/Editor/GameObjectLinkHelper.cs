using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace UGUIBase {
    
    [CustomEditor(typeof(GameObjectLink))]
    public class GameObjectLinkHelper : Editor {

        [MenuItem("GameObject/UGUI_Extention/AutoAttachLink &_n")]
        static void AutoAttachLink()
        {
            GameObject select = Selection.activeObject as GameObject;
            if (select == null)
            {
                Debug.LogError("[GameObjectLinkHelper] --> 请先选择一个节点");
                return;
            }

            GameObjectLink gameObjectLink;
            GameObject parentGameObject = select;
            while (true) { 
                gameObjectLink = parentGameObject.GetComponent<GameObjectLink>() as GameObjectLink;
                if (gameObjectLink != null)
                {
                    break;
                }
                if (parentGameObject.transform.parent == null)
                {
                    break;
                }
                parentGameObject = parentGameObject.transform.parent.gameObject as GameObject;
            }
            if (gameObjectLink == null)
            {
                Debug.LogError("[GameObjectLinkHelper] --> 父节点中找不到GameObjectLink组件");
                return;
            }

            foreach(var link in gameObjectLink.links)
            {
                if (link.name == select.name)
                {
                    Debug.LogError("[GameObjectLinkHelper] --> \"" + select.name + "\"已经存在于\"" + parentGameObject.name + "\"上");
                    return;
                }
            }

            gameObjectLink.links.Add(new GameObjectLink.LinkObject(select.name, select));
            Debug.Log("[GameObjectLinkHelper] --> 链接\"" + select.name + "\"至\"" + parentGameObject.name + "\"上");
        }

        public bool debugMode = false;

        public GameObject bindObject;
        public GameObjectLink gameObjectLink;
        public bool check = false;

        public void OnEnable()
        {
            check = false;

            bindObject = Selection.activeObject as GameObject;
            if (bindObject == null)
            {
                Debug.LogError("[GameObjectLinkHelper] --> 找不到绑定节点");
                return;
            }

            gameObjectLink = bindObject.GetComponent<GameObjectLink>() as GameObjectLink;
            if (gameObjectLink == null)
            {
                Debug.LogError("[GameObjectLinkHelper] --> 找不到GameObjectLink组件");
                return;
            }

            check = true;
            if (debugMode)
            {
                Debug.Log("[GameObjectLinkHelper] --> 已经存在的链接数量为" + gameObjectLink.links.Count.ToString());
            }

            checkLinkObjects();
        }

        private void checkLinkObjects()
        {
            foreach (var link in gameObjectLink.links)
            {
                if (link.go == null)
                {
                    Debug.LogError("[GameObjectLinkHelper] --> 找不到链接对象： " + link.name);
                }
            }
        }

        public void OnDisable()
        {
            check = false;
        }
    }
}
