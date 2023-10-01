using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;





public class wordle : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;

    [SerializeField]
    private string _text;

    [SerializeField]
    private string _textAnswer;

    [SerializeField]
    private int k;

    [SerializeField]
    private Row[] _rows;




    [SerializeField]
    private int _correct;

    [SerializeField]
    private int _trycount;
    private int _maxtrycount;
    private int _correctcount;



    // Start is called before the first frame update



    void Start()

    {
        _textAnswer = "UHAGE";
        _maxtrycount = _rows.Length;

        
    }

    private void Awake()
    {

        _rows = GetComponentsInChildren<Row>();
        
        

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

            for (k = 0; k < 5; k++)
            {

                char C = _text[k];


                if (C == _textAnswer[k])
                {
                    int i = k + 1;
                    Debug.Log(i + "番目の文字列が一致している");
                    _rows[_trycount].Setcharacter(k, _text[k]);
                    _rows[_trycount].Setcolor(k, Color.green);
                    _correctcount++;
                    continue;
                }

                if (_textAnswer.Contains(C))
                {
                    Debug.Log(C + "はどっかで一致している");
                    _rows[_trycount].Setcharacter(k, _text[k]);
                    _rows[_trycount].Setcolor(k, Color.yellow); 
                    continue;
                }

                    Debug.Log("何も一致していない");
                    _rows[_trycount].Setcharacter(k, _text[k]);
                    _rows[_trycount].Setcolor(k, Color.white);

            }
        }

        _trycount++;


        if (_maxtrycount > _trycount && _correctcount < 5)
        {
            
            _correctcount =0;
            Debug.Log(_correctcount);
        }
        if(_trycount == 6 && _correctcount < 5)
        {
            Debug.Log("失敗しました");
            _trycount = 0;
            GameOver();

        }
        if (_maxtrycount >= _trycount && _correctcount == 5)
        {
            Debug.Log("やるやん");
            GameOver();

        }   
        
    }

    private void GameOver()
    {
        _trycount = 0;
        _correctcount = 0;
        Invoke("GameReset", 3.0f); //3秒後にGameResetを呼び出す。
    
    }

    private void GameReset()
    {

        foreach (Row row in _rows) row.GameReset();　//Rowというオブジェクトの属性を帯びたrowという文字定義し_rowsの配列の各要素をループさせる。

    }

}

   

