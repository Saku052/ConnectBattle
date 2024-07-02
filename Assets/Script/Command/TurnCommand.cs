using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnCommand : MonoBehaviour
{   
    [SerializeField] private Animator playerTurnAnimator;
    [SerializeField] private Animator enemyTurnAnimator;
    [SerializeField] private Button CrackAttack;
    [SerializeField] private Button BurstAttack;

    public static TurnCommand turnCommand;

    private void Awake() {
        if (turnCommand == null)
            turnCommand = this;
        else
            Destroy(this.gameObject);
    }

    public void Start() {
        playerTurnAnimator.SetBool("PlayerTurn", true);
        StartCoroutine(pauseOneSecond());
    }

    IEnumerator pauseOneSecond() {
        yield return new WaitForSeconds(1.0f);
    }

    //playerTurnInitAnimation
    public void enemyTurnEndAnimation() {
        enemyTurnAnimator.SetBool("EnemyTurn", false);

        CrackAttack.interactable = true;
        BurstAttack.interactable = true;

        Debug.Log("initPlayer");
    }

    public void enemyTurnInitAnimation() {
        enemyTurnAnimator.SetBool("EnemyTurn", true);

        Debug.Log("endPlayer");
    }

    public void EnemyTurn() {
        CrackAttack.interactable = false;
        BurstAttack.interactable = false;

        playerTurnAnimator.SetBool("PlayerTurn", false);
    }
}
