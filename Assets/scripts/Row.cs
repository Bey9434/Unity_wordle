using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;

public class Row : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI[] _characters;

    [SerializeField]
    private Image[] _tiles;

    [SerializeField]
    private string _testenter = "FUCKU";

   /* [SerializeField]
    private Row[] _testrows;*/


    // Start is called before the first frame update
    private void Awake()
    {
        _characters = GetComponentsInChildren<TMPro.TextMeshProUGUI>();
        _tiles = GetComponentsInChildren<Image>();
        //_testrows = GetComponentsInChildren<Row>();

    }

    public void Setcharacter(int index, char C)
    {
        _characters[index].text = C.ToString();
    }


    public void Setcolor(int index, Color color)
    {

        _tiles[index].color = color;

    }

    /*private void Start()
    {
        string word = "HELLO";
        for (int i = 0; i < word.Length; i++)
        {
           _testrows[3].Setcharacter(i, word[i]);
        }
    }*/


    public void GameReset()
    {
        foreach (TMPro.TextMeshProUGUI character in _characters) character.text = "";
        foreach (Image tile in _tiles) tile.color = Color.white;
    }
}
