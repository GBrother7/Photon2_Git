using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<Panels> panels;

    public void ShowPanel(int id)
    {
        foreach(var i in panels)
        {
            if (i.id == id)
                i.Panel.OpenPanel();
            else
                i.Panel.ClosePanel();
        }
    }
    


   
}

[System.Serializable]
public class Panels
{
    public int id;
    public Panel Panel;
}
