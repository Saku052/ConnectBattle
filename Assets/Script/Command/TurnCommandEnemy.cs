using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnCommandEnemy : MonoBehaviour
{
    // get animation
    [SerializeField] private Animator playerTurnAnimator;
    [SerializeField] private Animator enemyTurnAnimator;

    // get button
    [SerializeField] private Button crackButton;
    [SerializeField] private Button burstButton;


    // function when enemy animation ends
    public void endEfunction()
    {
        // Enemy attacks player
        EnemyCommand.enemyCommand.Attack();

        enemyTurnAnimator.SetBool("EnemyTurn", false);
        Debug.Log("endEfunction");
    }

    // function when enemy end animation ends
    public void endEBfunction()
    {

        // set playerTurnAnimator to true
        playerTurnAnimator.SetBool("PlayerTurn", true);

        Debug.Log("endEBfunction");
    }
}
