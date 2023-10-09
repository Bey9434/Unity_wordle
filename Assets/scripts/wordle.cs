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

    [System.Serializable]   //Json�`���̃t�@�C����ǂݍ���
    private class Wordlist  //Json�`���̃f�[�^���i�[���邽�߂̃f�[�^�\�����`
    {
        public List<string> words; //_EnglishListFile�̂Ȃ��Œ�`���Ă���words�Ƃ����p�P��̖��O��Ԃ�String�^��List�Ƃ��Ĉ���
    }

    [SerializeField]
    private UnityEngine.TextAsset _EnglishListFile;//EnglishList.json���A�^�b�`�BUnityRngine.TextAsset�^�̕ϐ��BJson��txt�t�@�C�����������Ƃ��ł���
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
        //EnglishListFile.text��Wordlist�^�ɒ�`���Ă���B
        //JsonUtility.FromJson�́AUnity�̕W���@�\�ŁAJSON�`���̕�������w�肵���^�̃I�u�W�F�N�g�ɕϊ�������́B
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

        if (!_wordList.words.Contains(_text)) return;//words�̗v�f���̒P��ȊO�̕�������͂����B
        _text = _text.ToUpper();


        if (_text.Length < 5)
        {
            Debug.Log("5�����̒P����łĂ˂��̂�");
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
                    Debug.Log(i + "�Ԗڂ̕����񂪈�v���Ă���");
                    _rows[_trycount].Setcharacter(k, _text[k]);
                    _rows[_trycount].Setcolor(k, Color.green);
                    _correctcount++;
                    continue;
                }

                if (_textAnswer.Contains(C))
                {
                    Debug.Log(C + "�͂ǂ����ň�v���Ă���");
                    _rows[_trycount].Setcharacter(k, _text[k]);
                    _rows[_trycount].Setcolor(k, Color.yellow); 
                    continue;
                }

                    Debug.Log("������v���Ă��Ȃ�");
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
            Debug.Log("���s���܂���");
            _trycount = 0;
            GameOver();

        }
        if (_maxtrycount >= _trycount && _correctcount == 5)
        {
            Debug.Log("�����");
            GameOver();

        }   
        
    }

    private void GameOver()
    {
        _blockInput = true;
        _trycount = 0;
        _correctcount = 0;
        _AnswerResult.text = "Answer:"+ _textAnswer;
        Invoke("GameReset", 3.0f); //3�b���GameReset���Ăяo���B
    
    }

    private void GameReset()
    {
        _blockInput = false;
        _AnswerResult.text = "";
        foreach (Row row in _rows) row.GameReset();�@//Row�Ƃ����I�u�W�F�N�g�̑�����тт�row�Ƃ���������`��_rows�̔z��̊e�v�f�����[�v������B
        int index = Random.Range(0, _randomcount);
        _textAnswer = _wordList.words[index].ToUpper();

    }

}

   

