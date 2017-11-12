using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelWelcome {
    public PanelWelcome()
    {
        GameObject panelWelcome = GameManager.ResourceManager.CreateUIGameObejct("UI/Panels/PanelWelcome");
        panelWelcome.transform.SetParent(GameManager.UICanvasManager.Instance.UICanvasRectTransform, false);
        panelWelcome.GetComponent<UGUIBase.GameObjectLink>().GetLinkGameObject("BtnStartGame").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnBtnStartGame);
    }

    public void OnBtnStartGame()
    {
        Debug.Log("OnBtnStartGame");
    }
}
