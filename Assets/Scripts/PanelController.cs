using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public List<Panel> panelList;
    void Start()
    {
        ShowPanel(panelList[0]);
    }

    public void ShowPanel(Panel panel)
    {
        foreach (var item in panelList)
        {
            item.gameObject.SetActive(item == panel);
        }
    }
}
