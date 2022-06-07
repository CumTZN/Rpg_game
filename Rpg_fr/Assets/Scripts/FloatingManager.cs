using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<Floating> floatingTexts = new List<Floating>();

    private void Update()
    {
        foreach (Floating txt in floatingTexts)
            txt.UpdateFloating();
    }
    public void Show(string msg, int fontsize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        Floating floatingTexts = GetFloating();

        floatingTexts.txt.text = msg;
        floatingTexts.txt.fontSize = fontsize;
        floatingTexts.txt.color = color;

        floatingTexts.go.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingTexts.motion = motion;
        floatingTexts.duraction = duration;

        floatingTexts.Show();

    }

    private Floating GetFloating()
    {
        Floating txt = floatingTexts.Find(t => !t.active);

        if (txt == null)
        {
            txt = new Floating();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt); 
        }

        return txt;
    }
}
