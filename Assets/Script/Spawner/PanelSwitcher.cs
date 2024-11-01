using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class PanelSwitcher:MonoBehaviour {

    [SerializeField] protected GameObject panel;

    protected void NonActivePanel(GameObject panel) 
    {
        panel.SetActive(false);
    }

    protected void ActivePanel(GameObject panel) 
    {
        panel.SetActive(true);
    }
}
