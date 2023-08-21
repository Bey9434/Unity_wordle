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
            Debug.Log("5�����̒P����łĂ˂��̂�");
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
                    Debug.Log(i + "�Ԗڂ̕����񂪈�v���Ă���");
                    continue;
                }

                if (_textAnswer.Contains(C))
                {
                    Debug.Log(C + "�͂ǂ����ň�v���Ă���");
                    continue;
                }

                Debug.Log("������v���Ă��Ȃ�");



            }
        }
    
    }

}
