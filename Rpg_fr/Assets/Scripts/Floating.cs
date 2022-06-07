using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floating 
{
    public bool active;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duraction;
    public float lastShown;

    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        go.SetActive(active);

    }

    public void UpdateFloating()
    {
        if (!active)
            return;

        if (Time.time - lastShown > duraction)
            Hide();

        go.transform.position += motion * Time.deltaTime;

        
    }
}
