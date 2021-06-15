using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    [SerializeField] Text w_oneText = null;
    [SerializeField] Text w_twoText = null;
    [SerializeField] Text w_threeText = null;
    [SerializeField] Text w_fourText = null;

    [SerializeField] Text b_oneText = null;
    [SerializeField] Text b_twoText = null;
    [SerializeField] Text b_threeText = null;
    [SerializeField] Text b_fourText = null;

    [SerializeField] Text blackText = null;
    [SerializeField] Text whiteText = null;

    [SerializeField] Text w_four_red = null;
    [SerializeField] Text w_four_par = null;
    [SerializeField] Text w_four_gre = null;
    [SerializeField] Text w_four_yel = null;

    [SerializeField] Text w_thr_red = null;
    [SerializeField] Text w_thr_par = null;
    [SerializeField] Text w_thr_gre = null;
    [SerializeField] Text w_thr_yel = null;

    [SerializeField] Text w_two_red = null;
    [SerializeField] Text w_two_par = null;
    [SerializeField] Text w_two_gre = null;
    [SerializeField] Text w_two_yel = null;

    [SerializeField] Text w_one_red = null;
    [SerializeField] Text w_one_par = null;
    [SerializeField] Text w_one_gre = null;
    [SerializeField] Text w_one_yel = null;



    [SerializeField] Text b_four_red = null;
    [SerializeField] Text b_four_par = null;
    [SerializeField] Text b_four_gre = null;
    [SerializeField] Text b_four_yel = null;

    [SerializeField] Text b_thr_red = null;
    [SerializeField] Text b_thr_par = null;
    [SerializeField] Text b_thr_gre = null;
    [SerializeField] Text b_thr_yel = null;

    [SerializeField] Text b_two_red = null;
    [SerializeField] Text b_two_par = null;
    [SerializeField] Text b_two_gre = null;
    [SerializeField] Text b_two_yel = null;

    [SerializeField] Text b_one_red = null;
    [SerializeField] Text b_one_par = null;
    [SerializeField] Text b_one_gre = null;
    [SerializeField] Text b_one_yel = null;

    [SerializeField] Text B_Point = null;
    [SerializeField] Text W_Point = null;
    [SerializeField] Text Win = null;

    int w_red = Reversi.w_four;
    int w_par = Reversi.w_three;
    int w_gre = Reversi.w_two;
    int w_yel = Reversi.w_one;

    int b_red = Reversi.b_four;
    int b_par = Reversi.b_three;
    int b_gre = Reversi.b_two;
    int b_yel = Reversi.b_one;

    int whitePoint = 0;
    int blackPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        Point();
    }

    public void Point()
    {
        w_oneText.text = "黄の数：" + Reversi.w_one;
        w_twoText.text = "緑の数：" + Reversi.w_two;
        w_threeText.text = "紫の数：" + Reversi.w_three;
        w_fourText.text = "赤の数：" + Reversi.w_four;

        b_oneText.text = "黄の数：" + Reversi.b_one;
        b_twoText.text = "緑の数：" + Reversi.b_two;
        b_threeText.text = "紫の数：" + Reversi.b_three;
        b_fourText.text = "赤の数：" + Reversi.b_four;

        blackText.text = "駒：" + Reversi.black;
        whiteText.text = "駒：" + Reversi.white;
        Count();
        blackPoint += Reversi.black;
        whitePoint += Reversi.white;
        B_Point.text = "黒の点：" +blackPoint;
        W_Point.text = "白の点：" + whitePoint;
        if(blackPoint > whitePoint)
        {
            Win.text = "黒の勝ち";
        }
        else if (blackPoint < whitePoint)
        {
            Win.text = "白の勝ち";
        }
        else { Win.text = "引き分け"; }
    }

    public void Count()
    {
        if(w_red >= 4)
        {
            w_four_red.text = ""+w_red / 4;
            whitePoint += w_red / 4 * 4 * 4;
            w_red -= (w_red / 4) * 4;
            if (w_red >= 3)
            {
                w_thr_red.text = "" + w_red / 3;
                whitePoint += w_red / 3 * 3 * 4;
                w_red -= (w_red / 3) * 3;
                if (w_red >= 2)
                {
                    w_one_red.text = "" + w_red / 2;
                    whitePoint += w_red / 2 * 2 * 4;
                }
            }
        }
        if (w_par >= 4)
        {
            w_four_par.text = "" + w_par / 4;
            whitePoint += w_par / 2 * 4 * 3;
            w_par -= (w_par / 4) * 4;
            if (w_par >= 3)
            {
                w_thr_par.text = "" + w_par / 3;
                whitePoint += w_par / 2 * 3 * 3;
                w_par -= (w_par / 3) * 3;
                if (w_par >= 2)
                {
                    whitePoint += w_par / 2 * 2 * 3;
                    w_one_par.text = "" + w_par / 2;

                }
            }

        }
        if (w_gre >= 4)
        {
            w_four_gre.text = "" + w_gre / 4;
            whitePoint += w_gre / 2 * 4 * 2;
            w_gre -= (w_gre / 4) * 4;
            if (w_gre >= 3)
            {
                w_thr_gre.text = "" + w_gre / 3;
                whitePoint += w_gre / 2 * 3 * 2;
                w_gre -= (w_gre / 3) * 3;
                if (w_gre >= 2)
                {
                    whitePoint += w_gre / 2 * 2 * 2;
                    w_one_gre.text = "" + w_gre / 2;

                }
            }
        }
        if (w_yel >= 4)
        {
            w_four_yel.text = "" + w_yel / 4;
            whitePoint += w_yel / 2 * 4;
            w_yel -= (w_yel / 4) * 4;
            if (w_yel >= 3)
            {
                w_thr_yel.text = "" + w_yel / 3;
                whitePoint += w_yel / 2 * 3;
                w_yel -= (w_yel / 3) * 3;
                if (w_yel >= 2)
                {
                    whitePoint += w_yel / 2 * 2;
                    w_one_yel.text = "" + w_yel / 2;

                }

            }
        }
        if (b_red >= 4)
        {
            b_four_red.text = "" + b_red / 4;
            blackPoint += b_red / 4 * 4 * 4;
            b_red -= (b_red / 4) * 4;
            if (b_red >= 3)
            {
                b_thr_red.text = "" + b_red / 3;
                blackPoint += b_red / 4 * 3 * 4;
                b_red -= (b_red / 3) * 3;
                if (b_red >= 2)
                {
                    blackPoint += b_red / 4 * 2 * 4;
                    b_one_red.text = "" + b_red / 2;

                }
            }
        }
        if (b_par >= 4)
        {
            b_four_par.text = "" + b_par / 4;
            blackPoint += b_par / 4 * 4 * 3;
            b_par -= (b_par / 4) * 4;
            if (b_par >= 3)
            {
                b_thr_par.text = "" + b_par / 3;
                blackPoint += b_par / 4 * 3 * 3;
                b_par -= (b_par / 3) * 3;
                if (b_par >= 2)
                {
                    blackPoint += b_par / 4 * 2 * 3;
                    b_one_par.text = "" + b_par / 2;

                }
            }
        }
        if (b_gre >= 4)
        {
            b_four_gre.text = "" + b_gre / 4;
            blackPoint += b_gre / 4 * 4 * 2;
            b_gre -= (b_gre / 4) * 4;
            if (b_gre >= 3)
            {
                b_thr_gre.text = "" + b_gre / 3;
                blackPoint += b_gre / 4 * 3 * 2;
                b_gre -= (b_gre / 3) * 3;
                if (b_gre >= 2)
                {
                    blackPoint += b_gre / 4 * 2 * 2;
                    b_one_gre.text = "" + b_gre / 2;

                }
            }
        }
        if (b_yel >= 4)
        {
            b_four_yel.text = "" + b_yel / 4;
            blackPoint += b_yel / 4 * 4;
            b_yel -= (b_yel / 4) * 4;
            if (b_yel >= 3)
            {
                b_thr_yel.text = "" + b_yel / 3;
                blackPoint += b_yel / 4 * 3;
                b_yel -= (b_yel / 3) * 3;
                if (b_yel >= 2)
                {
                    blackPoint += b_yel / 4 * 2;
                    b_one_yel.text = "" + b_yel / 2;

                }
            }
        }
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
}
