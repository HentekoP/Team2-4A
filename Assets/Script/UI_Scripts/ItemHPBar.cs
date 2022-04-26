using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI使うときは忘れずに。
using UnityEngine.UI;

public class ItemHPBar : MonoBehaviour
{
    //最大HPと現在のHP。
    int maxHp = 0;
    public GameObject Item;
    int currentHp;
    //Sliderを入れる
    public Slider slider;

    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        var hp = Item.gameObject.GetComponent<hamaaa>();
        maxHp = hp.objectHP;
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    void Update()
    {
        var hp = Item.gameObject.GetComponent<hamaaa>();
        if (Input.GetButtonDown("X"))
        {
            currentHp = currentHp - 1;
        }
        Debug.Log("currentHp : " + currentHp);
        //最大HPにおける現在のHPをSliderに反映。
        //int同士の割り算は小数点以下は0になるので、
        //(float)をつけてfloatの変数として振舞わせる。
        slider.value = (float)currentHp / (float)maxHp; 
         Debug.Log("slider.value : " + slider.value);

        if (currentHp <= 0)
        {
            slider.gameObject.SetActive(false);
        }
    }
}