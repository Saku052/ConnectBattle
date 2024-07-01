using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnCommandEnemy : MonoBehaviour
{

    [SerializeField] private Animator playerTurnAnimator;
    [SerializeField] private Animator enemyTurnAnimator;

    [SerializeField] private Button crackButton;
    [SerializeField] private Button burstButton;

    //enemyTurnEndAnimation
    public void endEfunction() {
        EnemyCommand.enemyCommand.Attack();
        enemyTurnAnimator.SetBool("EnemyTurn", false);
        
        Debug.Log("endEfunction");
    }

    public void playerTurnInitAnimation() {
        playerTurnAnimator.SetBool("PlayerTurn", true);

        Debug.Log("endEBfunction");
    }
}
