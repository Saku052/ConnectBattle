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
        // Wait 0.5 seconds
        StartCoroutine(StartMainTurn());
    }


    // Wait 0.5 seconds
    IEnumerator StartMainTurn()
    {
        yield return new WaitForSeconds(0.5f);

        // set playerTurnAnimator to true
        playerTurnAnimator.SetFloat(Animator.StringToHash("PlayerFloat"), 1);
        // set enemyTurnAnimator to false
        enemyTurnAnimator.SetFloat(Animator.StringToHash("EnemyFloat"), -1);

        yield return new WaitForSeconds(2.5f);
        enemyTurnAnimator.SetFloat(Animator.StringToHash("EnemyFloat"), -1.1f);

        // enable buttons
        crackButton.interactable = true;
        burstButton.interactable = true;
    }

    // Wait 0.5 seconds
    IEnumerator StartEnemyTurn()
    {
        // disable buttons
        crackButton.interactable = false;
        burstButton.interactable = false;

        yield return new WaitForSeconds(0.5f);

        // set playerTurnAnimator to false
        playerTurnAnimator.SetFloat(Animator.StringToHash("PlayerFloat"), -1);
        // set enemyTurnAnimator to true
        enemyTurnAnimator.SetFloat(Animator.StringToHash("EnemyFloat"), 1);
       
        yield return new WaitForSeconds(2.5f);
        playerTurnAnimator.SetFloat(Animator.StringToHash("PlayerFloat"), -1.1f);


        // TODO : delete here
        // start player turn
        yield return new WaitForSeconds(3.0f);
        // Enemy attacks player
        EnemyCommand.enemyCommand.Attack();
        PlayerTurn();
    }


    // Player's turn
    public void PlayerTurn()
    {
        // set playerTurn to true
        StartCoroutine(StartMainTurn());
    }

    // Enemy's turn
    public void EnemyTurn()
    {
        // set playerTurn to false
        StartCoroutine(StartEnemyTurn());
    }





    private void Awake()
    {
        if (turnCommand == null)
            turnCommand = this;
        else
            Destroy(this.gameObject);
    }
}
