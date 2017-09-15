using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour 
{
    [SerializeField]
    public string NextScene;

    private int Health;
    private int Crystal;
    private static Game game;
    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Text crystalText;

    public List<string> gemNames = new List<string>();
    public List<Sprite> gemSprites = new List<Sprite>();

    public void AddSprites(Sprite s)
    {
        gemSprites.Add(s);
    }

    void Awake()
    {
        game = this;
        Health = 5;
    }

    public void AddGemName(string g)
    {
        gemNames.Add(g);
    }

    public void SubstractHealth(int g)
    {
        Health -= g;
    }

    public void AddCrystal(int c)
    {
        Crystal += c;
    }

    public int GetHealth()
    {
        return Health;
    }

    public int GetCrystal()
    {
        return Crystal;
    }

    public static Game GetGame()
    {
        return game;
    }

    public List<string> GetGemNames()
    {
        return gemNames;
    }

    void Update()
    {
        healthText.text = "x "+ Health.ToString();
        crystalText.text = "x "+Crystal.ToString();
        if(gemNames.Contains("Yellow") && gemNames.Contains("Green") && gemNames.Contains("Red") && gemNames.Contains("Blue") && gemNames.Contains("Dark"))
        {
            Crystal++;
            gemNames.Remove("Yellow");
            gemNames.Remove("Red");
            gemNames.Remove("Green");
            gemNames.Remove("Blue");
            gemNames.Remove("Dark");
        }
    }
}
