using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ScoreController : MonoBehaviour
{

    //スコアを保持するための関数
    private int score = 0;

    //スコア表示するテキスト
    private GameObject ScoreText;

    // Use this for initialization
    void Start()
    {
        //シーン中のScoreTextオブジェクトを取得
        this.ScoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        // タグによって得点を変える
        if (tag == "SmallStarTag")
        {
            this.score += 10;
        }
        else if (tag == "LargeStarTag")
        {
            this.score += 20;
        }
        else if (tag == "SmallCloudTag")
        {
            this.score += 30;
        }
        else if (tag == "LargeCloudTag")
        {
            this.score += 40;
        }

    //ScorerTextにスコアを表示
    this.ScoreText.GetComponent<Text>().text = Convert.ToString(score);

    }
}
