using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        ////PC上の矢印キーによる操作
        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }


        ////スマホ上のタップによる操作

        for (int i = 0; i < Input.touchCount; i++)
        {
            var id = Input.touches[i].fingerId;
            var pos = Input.touches[i].position;
            Debug.LogFormat("{0} - x:{1}, y:{2}", id, pos.x, pos.y);
        }

        foreach (Touch t in Input.touches)
        {
            var id = t.fingerId;

            switch (t.phase)
            {
                case TouchPhase.Began:
                    if (Input.touches[1] <= 0 && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                    if (Input.touches[1] <= 0 && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }

                    Debug.LogFormat("{0}:いまタッチした", id);
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    Debug.LogFormat("{0}:タッチしている", id);
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:

                    if (Input.touches[1] <= 0 && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                    if (Input.touches[1] <= 0 && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }


                    Debug.LogFormat("{0}:いま離された", id);
                    break;
            }
        }

    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}