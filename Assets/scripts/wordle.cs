using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class wordle : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;

    [SerializeField]
    private string _text;

    [SerializeField]
    private string _textAnswer;


    // Start is called before the first frame update
    void Start()
    {
        _textAnswer = "UHAGE";
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    public void OnInputEnded()
    {
        _text = _inputField.text;
        _text = _text.ToUpper();


        if (_text.Length < 5)
        {
            Debug.Log("5文字の単語も打てねえのか");
            return;

        }
        else
        {

            for (int k = 0; k < 5; k++)
            {
                char C = _text[k];

                if (C == _textAnswer[k])
                {
                    int i = k + 1;
                    Debug.Log(i + "番目の文字列が一致している");
                    continue;
                }

                if (_textAnswer.Contains(C))
                {
                    Debug.Log(C + "はどっかで一致している");
                    continue;
                }

                Debug.Log("何も一致していない");



            }
        }
    
    }

}
