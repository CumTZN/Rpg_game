using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    public List<Sprite> playersSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrisces;
    public List<int> xpTable;

    public Player player;

    public FloatingManager floatingTextManager;

    public int gold;
    public int experience;


    public void ShowText(string msg, int fontsize, Color color, Vector3 position, Vector3 motion, float duraction)
    {
        floatingTextManager.Show(msg, fontsize, color, position, motion, duraction);

    }

    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += gold.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode) 
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        gold = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        Debug.Log("LoadState");
    }
}
