using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CellState
{
    Black = 0,
    White = 1,
    None = -1,
    PutNone = -2,
}

public enum PokerState
{
    Wait = 0,
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
}

public class Cell : MonoBehaviour
{
    [SerializeField]
    private CellState _cellState = CellState.None;
    [SerializeField]
    private PokerState _pokerState = PokerState.One;

    [SerializeField] Image m_image = null;
    [SerializeField] Image p_image = null;
    [SerializeField] Image point = null;
    [SerializeField] Text num_text = null;

    //配列の座標
    private int row;
    private int column;

    private GameObject reversi;

    void Start()
    {
        OnCellStateChanged();
        OnPokerStateChanged();
    }

    public void GetCoordinate(int r, int c)
    {
        row = r;
        column = c;
    }

    private void OnValidate()
    {
        OnCellStateChanged();
        OnPokerStateChanged();

    }

    public CellState CellState
    {
        get => _cellState;
        set
        {
            _cellState = value;
            OnCellStateChanged();
        }
    }

    public PokerState PorkerState
    {
        get => _pokerState;
        set
        {
            _pokerState = value;
            OnPokerStateChanged();
        }
    }
    private void OnCellStateChanged()
    {
        if (_cellState == CellState.None)
        {
            point.color = Color.clear;
            p_image.color = Color.clear;
            m_image.color = Color.green;
        }
        if (_cellState == CellState.White)
        {
            point.color = Color.clear;
            p_image.color = Color.white;
            m_image.color = Color.green;

        }
        if (_cellState == CellState.Black)
        {
            OnPokerStateChanged();
            p_image.color = Color.black;
            m_image.color = Color.green;
        }
        if (_cellState == CellState.PutNone)
        {
            m_image.color = Color.yellow;
        }
    }

    private void OnPokerStateChanged()
    {
        if(_cellState == CellState.White || _cellState == CellState.None)
        {
            point.color = Color.clear;
            return;
        }
        if (_pokerState == PokerState.One)
        {
            point.color = new Color(255f / 255f, 255f / 255f, 0f / 255f);
        }
        else if (_pokerState == PokerState.Two)
        {
            point.color = new Color(0f / 255f, 128f / 255f, 0f / 255f);
        }
        else if (_pokerState == PokerState.Three)
        {
            point.color = new Color(204f / 255f, 153f / 255f, 255f / 255f);
        }
        else if (_pokerState == PokerState.Four)
        {
            point.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
        }
        else
        {
            point.color = new Color(255f / 255f, 255f / 255f, 0f / 255f);
            _pokerState = PokerState.One;
        }                
    }

    public void Put()
    {
        reversi = GameObject.Find("Reversi");
        if (this.CellState == CellState.PutNone)
        {         
            ReverseAll();            
            if (!(this.CellState == CellState.None || this.CellState == CellState.PutNone))
            {
                reversi.GetComponent<Reversi>().TrunChenge();
                reversi.GetComponent<Reversi>().AllCheck();
            } 
        }
        else
        {
            if (!reversi.GetComponent<Reversi>().Pass())
            {
                Debug.Log("パス判定");
                reversi.GetComponent<Reversi>().TrunChenge();
            }
        }

    }

    public void PutAll()
    {
        reversi = GameObject.Find("Reversi");
        if (this.CellState == CellState.None)
        {
            reversi.GetComponent<Reversi>().PutCheck(row, column, 1, 0);  //右方向
            reversi.GetComponent<Reversi>().PutCheck(row, column, -1, 0); //左方向
            reversi.GetComponent<Reversi>().PutCheck(row, column, 0, -1); //上方向
            reversi.GetComponent<Reversi>().PutCheck(row, column, 0, 1);  //下方向
            reversi.GetComponent<Reversi>().PutCheck(row, column, 1, -1); //右上方向
            reversi.GetComponent<Reversi>().PutCheck(row, column, -1, -1);//左上方向
            reversi.GetComponent<Reversi>().PutCheck(row, column, 1, 1);  //右下方向
            reversi.GetComponent<Reversi>().PutCheck(row, column, -1, 1); //左下方向
        }
        
    }

    void ReverseAll()
    {
        reversi.GetComponent<Reversi>().ReverseCheck(row, column, 1, 0);  //右方向
        reversi.GetComponent<Reversi>().ReverseCheck(row, column, -1, 0); //左方向
        reversi.GetComponent<Reversi>().ReverseCheck(row, column, 0, -1); //上方向
        reversi.GetComponent<Reversi>().ReverseCheck(row, column, 0, 1);  //下方向
        reversi.GetComponent<Reversi>().ReverseCheck(row, column, 1, -1); //右上方向
        reversi.GetComponent<Reversi>().ReverseCheck(row, column, -1, -1);//左上方向
        reversi.GetComponent<Reversi>().ReverseCheck(row, column, 1, 1);  //右下方向
        reversi.GetComponent<Reversi>().ReverseCheck(row, column, -1, 1); //左下方向
    }

}
