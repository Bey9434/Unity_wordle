using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class wordle : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;

    [SerializeField]
    private TMPro.TextMeshProUGUI _AnswerResult;

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

    [System.Serializable]   //Json形式のファイルを読み込み
    private class Wordlist  //Json形式のデータを格納するためのデータ構造を定義
    {
        public List<string> words; //_EnglishListFileのなかで定義しているwordsという英単語の名前空間をString型のListとして扱う
    }

    [SerializeField]
    private UnityEngine.TextAsset _EnglishListFile;//EnglishList.jsonをアタッチ。UnityRngine.TextAsset型の変数。Jsonやtxtファイルを扱うことができる
    private Wordlist _wordList;
    private int _randomlist;
    private int _randomcount;

    [SerializeField]
    private bool _blockInput = false;


    private void Awake()
    {
        _rows = GetComponentsInChildren<Row>();
        _maxtrycount = _rows.Length;
        LoadJson();
        GameReset();
    }
    private void LoadJson()
    {
        _wordList = JsonUtility.FromJson<Wordlist>(_EnglishListFile.text);
        //EnglishListFile.textをWordlist型に定義している。
        //JsonUtility.FromJsonは、Unityの標準機能で、JSON形式の文字列を指定した型のオブジェクトに変換するもの。
        _randomcount = _wordList.words.Count;
    }

    /*void Update()
    {
        if (!_inputField.isFocused)
        {
            _inputField.Select();
            _inputField.ActivateInputField();
        }
    }*/

    public void OnInputEnded()
    {
        if (_blockInput) return;

        _text = _inputField.text.ToLower();
        _inputField.text = "";

        if (!_wordList.words.Contains(_text)) return;//wordsの要素内の単語以外の文字列をはじく。
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
        _blockInput = true;
        _trycount = 0;
        _correctcount = 0;
        _AnswerResult.text = "Answer:"+ _textAnswer;
        Invoke("GameReset", 3.0f); //3秒後にGameResetを呼び出す。
    
    }

    private void GameReset()
    {
        _blockInput = false;
        _AnswerResult.text = "";
        foreach (Row row in _rows) row.GameReset();　//Rowというオブジェクトの属性を帯びたrowという文字定義し_rowsの配列の各要素をループさせる。
        int index = Random.Range(0, _randomcount);
        _textAnswer = _wordList.words[index].ToUpper();

    }

}

   

