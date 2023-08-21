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
            Debug.Log("5•¶Žš‚Ì’PŒê‚à‘Å‚Ä‚Ë‚¦‚Ì‚©");
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
                    Debug.Log(i + "”Ô–Ú‚Ì•¶Žš—ñ‚ªˆê’v‚µ‚Ä‚¢‚é");
                    continue;
                }

                if (_textAnswer.Contains(C))
                {
                    Debug.Log(C + "‚Í‚Ç‚Á‚©‚Åˆê’v‚µ‚Ä‚¢‚é");
                    continue;
                }

                Debug.Log("‰½‚àˆê’v‚µ‚Ä‚¢‚È‚¢");



            }
        }
    
    }

}
