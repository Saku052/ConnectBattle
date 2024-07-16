using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageAnimationCommand : MonoBehaviour
{
    [SerializeField] private GameObject damageAnimation;
    [SerializeField] private Animator animation;


    public void DamageAnima(int return_damage) {
        DamageTextSize(damageAnimation, return_damage);

        
        damageAnimation.transform.localPosition = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0);
        // change color of text to red
        damageAnimation.GetComponent<Text>().color = new Color32(255, 0, 0, 255);
        // change text to damage amount
        damageAnimation.GetComponent<Text>().text = return_damage.ToString();

        // activate damage animation
        animation.GetComponent<Animator>().SetTrigger("DamageTrigger");
        Debug.Log("DamageAnimation");

    }

    //　ダメージテキストの大きさをダメージの量に比例させる
    public void DamageTextSize(GameObject damageText, int damage)
    {
        // ダメージの量によってダメージテキストの大きさを変更
        if (damage < 50)
        {
            damageText.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (damage < 100)
        {
            damageText.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        }
        else if (damage < 500)
        {
            damageText.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if (damage < 1000)
        {
            damageText.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        }
        else if (damage < 5000)
        {
            damageText.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (damage < 10000)
        {
            damageText.transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
        }
        else
        {
            damageText.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        }
    }




    public void Start()
    {
        

    }

    public static DamageAnimationCommand damageAnimationCommand;
    private void Awake()
    {
        if (damageAnimationCommand == null)
        {
            damageAnimationCommand = this;
        }
    }
}
