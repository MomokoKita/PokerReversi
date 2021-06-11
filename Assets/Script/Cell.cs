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

public class Cell : MonoBehaviour
{
    [SerializeField]
    private CellState _cellState = CellState.None;
    [SerializeField] Image m_image = null;
    [SerializeField] Image p_image = null;

    //配列の座標
    private int row;
    private int column;

    private GameObject reversi;

    void Start()
    {
        OnCellStateChanged();
    }

    public void GetCoordinate(int r, int c)
    {
        row = r;
        column = c;
    }

    private void OnValidate()
    {
        OnCellStateChanged();

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
    private void OnCellStateChanged()
    {
        if (_cellState == CellState.None)
        {
            p_image.color = Color.clear;
            m_image.color = Color.green;
        }
        if (_cellState == CellState.White)
        {
            p_image.color = Color.white;
            m_image.color = Color.green;

        }
        if (_cellState == CellState.Black)
        {
            p_image.color = Color.black;
            m_image.color = Color.green;
        }
        if (_cellState == CellState.PutNone)
        {
            Debug.Log("おけるよ");
            m_image.color = Color.yellow;
        }
    }
    public void Put()
    {
        reversi = GameObject.Find("Reversi");
        if (this.CellState == CellState.PutNone)
        {
            reversi.GetComponent<Reversi>().AllCheck();
            
            ReverseAll();            
            if (!(this.CellState == CellState.None || this.CellState == CellState.PutNone))
            {
                
                reversi.GetComponent<Reversi>().TrunChenge();
                
            } 
        }

    }

    public void PutNoneCheck()
    {
        reversi = GameObject.Find("Reversi");
        if (this.CellState == CellState.None)
        {
            PutAll();
        }
    }

    public void PutAll()
    {
        reversi.GetComponent<Reversi>().PutCheck(row,column,1,0);  //右方向
        reversi.GetComponent<Reversi>().PutCheck(row, column, -1, 0); //左方向
        reversi.GetComponent<Reversi>().PutCheck(row, column, 0, -1); //上方向
        reversi.GetComponent<Reversi>().PutCheck(row, column, 0, 1);  //下方向
        reversi.GetComponent<Reversi>().PutCheck(row, column, 1, -1); //右上方向
        reversi.GetComponent<Reversi>().PutCheck(row, column, -1, -1);//左上方向
        reversi.GetComponent<Reversi>().PutCheck(row, column, 1, 1);  //右下方向
        reversi.GetComponent<Reversi>().PutCheck(row, column, -1, 1); //左下方向
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
        reversi.GetComponent<Reversi>().AllCheck();
    }

}
