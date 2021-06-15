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

    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
}
