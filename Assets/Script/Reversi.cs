using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reversi : MonoBehaviour
{
    [SerializeField]
    private Text trunText = null;

    [SerializeField]
    private Text blackText = null;
    [SerializeField]
    private Text whiteText = null;

    [SerializeField]
    private int _rows = 1;　//X

    [SerializeField]
    private int _columns = 1; //Y

    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup = null;

    [SerializeField]
    private Cell _cellPrefab = null;

    Cell[,] _cells;


    //false = 黒 true = 白
    bool trun = false;
    // Start is called before the first frame update
    void Start()
    {
        _cells = new Cell[_rows, _columns];
        var parent = _gridLayoutGroup.gameObject.transform;
        //縦の方が多いとき,横を基準にする
        if (_columns < _rows)
        {
            _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            _gridLayoutGroup.constraintCount = _columns;
        }
        //横の方が多いとき,縦を基準にする
        else
        {
            _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            _gridLayoutGroup.constraintCount = _rows;
        }
        //CellPrefabをfor文で回す
        for (var r = 0; r < _rows; r++)
        {
            for (var c = 0; c < _columns; c++)
            {
                var cell = Instantiate(_cellPrefab);
                cell.transform.SetParent(parent);
                _cells[r, c] = cell;
                cell.GetCoordinate(r, c);
                if (r==3&&c==3 || r==4&&c==4)
                {
                    _cells[r, c].CellState = CellState.Black;
                }
                if (r == 4 && c == 3 || r == 3 && c == 4)
                {
                    _cells[r, c].CellState = CellState.White;
                }
            }
        }

    }

    private void Update()
    {
        NoneReset();
        AllCheck();
    }

    public void ReverseCheck(int r,int c,int directionR, int directionC)
    {
        //確認する座標
        int r_check = r + directionR;
        int c_check = c + directionC;
        if (r_check<0||r_check>=_rows||c_check<0||c_check>=_columns)
        {
            return;
        }
        
        CellState flag = CellState.None;
        if (!trun)//黒のターン
        {
            flag = CellState.Black;
            
        }
        else if(trun) //白のターン
        {
            flag = CellState.White;
        }
        if (_cells[r_check,c_check].CellState == flag)
        {
            return;
        }
        while (r < _rows && r >= 0 &&  c < _columns && c >= 0)
        {
            if (r_check < 0 || r_check >= _rows || c_check < 0 || c_check >= _columns)
            {
                return;
            }
            //自分の駒だった場合
            if (_cells[r_check, c_check].CellState == flag)
            {
                //ひっくり返す
                int r_check2 = r + directionR, c_check2 = c + directionC;
                while (!(r_check2 == r_check && c_check2 == c_check))
                {
                    _cells[r_check2, c_check2].CellState = flag;
                    r_check2 += directionR;
                    c_check2 += directionC;           
                }
                _cells[r, c].CellState = flag;
                break;

            }
            //空欄だった場合
            else if (_cells[r_check, c_check].CellState == CellState.None || _cells[r_check, c_check].CellState == CellState.PutNone)
            {
                //挟んでいないので処理を終える
                break;
            }

            //確認座標を次に進める
            r_check += directionR;
            c_check += directionC;
        }
    }

    public void PutCheck(int r, int c, int directionR, int directionC)
    {

        //確認する座標
        int r_check = r + directionR;
        int c_check = c + directionC;
        if (r_check < 0 || r_check >= _rows || c_check < 0 || c_check >= _columns)
        {
            return;
        }
        if (_cells[r, c].CellState == CellState.Black || _cells[r, c].CellState == CellState.White)
        {
            return;
        }

        CellState flag = CellState.None;
        if (!trun)//黒のターン
        {
            flag = CellState.Black;

        }
        else if (trun) //白のターン
        {
            flag = CellState.White;
        }
        if (_cells[r_check, c_check].CellState == flag)
        {
            return;
        }
        while (r < _rows && r >= 0 && c < _columns && c >= 0)
        {
            if (r_check < 0 || r_check >= _rows || c_check < 0 || c_check >= _columns)
            {
                return;
            }
            //自分の駒だった場合
            if (_cells[r_check, c_check].CellState == flag)
            {
                _cells[r, c].CellState = CellState.PutNone;
                break;
            }
            //空欄だった場合
            else if (_cells[r_check, c_check].CellState == CellState.None || _cells[r_check, c_check].CellState == CellState.PutNone)
            {
                //挟んでいないので処理を終える
                break;
            }

            //確認座標を次に進める
            r_check += directionR;
            c_check += directionC;
        }
    }


    public void TrunChenge()
    {
        if (trun)
        {
            trunText.text = "黒のターン";
            trun = false;
        }
        else if(!trun)
        {
            trunText.text = "白のターン";
            trun = true;
        }
    }

    /// <summary>
    /// 白黒それぞれの数を表示する関数
    /// </summary>
    public void AllCheck()
    {
        int blackCount=0;
        int whiteCount = 0;
        for (int r = 0; r < _rows; r++)
        {
            for (int c = 0; c < _columns; c++)
            {
                _cells[r, c].PutNoneCheck();
                if(_cells[r,c].CellState == CellState.Black)
                {
                    blackCount++;
                }
                else if(_cells[r, c].CellState == CellState.White)
                {
                    whiteCount++;
                }
            }
        }
        blackText.text = "黒：" + blackCount;
        whiteText.text = "白：" + whiteCount;
    }
    public void NoneReset()
    {
        for (int r = 0; r < _rows; r++)
        {
            for (int c = 0; c < _columns; c++)
            {
                if (_cells[r,c].CellState == CellState.PutNone)
                {
                    _cells[r, c].CellState = CellState.None;
                }
            }
        }
    }

    /// <summary>
    ///リロードする関数
    /// </summary>
    public void ReLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
