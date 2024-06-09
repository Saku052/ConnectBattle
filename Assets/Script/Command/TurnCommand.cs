using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnCommand : MonoBehaviour
{   
    // get animation
    [SerializeField] private Animator playerTurnAnimator;
    [SerializeField] private Animator enemyTurnAnimator;

    // get button
    [SerializeField] private Button crackButton;
    [SerializeField] private Button burstButton;


    // Controll Who's turn it is
    public static TurnCommand turnCommand;


    public void Start()
    {
        // set playerTurnAnimator to true
        playerTurnAnimator.SetBool("PlayerTurn", true);

        // Wait 0.5 seconds
        StartCoroutine(StartMainTurn());
    }


    // Wait 0.5 seconds
    IEnumerator StartMainTurn()
    {
        
        


        yield return new WaitForSeconds(1.0f);

        
    }

    // function when main character animation ends
    public void endMfunction()
    {
        // set enemyTurnAnimator to false
        enemyTurnAnimator.SetBool("EnemyTurn", false);

        // enable buttons
        crackButton.interactable = true;
        burstButton.interactable = true;

        Debug.Log("endMfunction");
        
        string kuku = "";
        // 二重ループを用いたプログラムで、かけ算九九を出力
        for (int i = 1; i <= 9; i++)
        {   
            kuku += "\n";
            for (int j = 1; j <= 9; j++)
            {
                kuku += i * j + " ";
            }
        }
        Debug.Log(kuku);
    }

    // function when main character end animation ends
    public void endMBfunction()
    {
        // set enemyTurnAnimator to true
        enemyTurnAnimator.SetBool("EnemyTurn", true);

        Debug.Log("endMBfunction");
    }

    // Enemy's turn
    public void EnemyTurn()
    {
        // disable buttons
        crackButton.interactable = false;
        burstButton.interactable = false;

        // set playerTurnAnimator to false
        playerTurnAnimator.SetBool("PlayerTurn", false);
    }





    private void Awake()
    {
        if (turnCommand == null)
            turnCommand = this;
        else
            Destroy(this.gameObject);
    }
}
