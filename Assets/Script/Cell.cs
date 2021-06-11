using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CellState
{
    Black = 0,
    White = 1,
    None = -1,
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
        }
        if (_cellState == CellState.White)
        {
            p_image.color = Color.white;
        }
        if (_cellState == CellState.Black)
        {
            p_image.color = Color.black;
        }
    }
    public void Put()
    {
        reversi = GameObject.Find("Reversi");
        if (this.CellState == CellState.None)
        {
            ReverseAll();
            if (!(this.CellState == CellState.None))
            {
                reversi.GetComponent<Reversi>().TrunChenge();
            } 
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
        reversi.GetComponent<Reversi>().AllCheck();
    }

}
