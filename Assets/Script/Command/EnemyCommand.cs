using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCommand : MonoBehaviour
{
    
    [SerializeField] private GameObject buttonPanel;
    public void Attack()
    {
        // get random number
        int num = Random.Range(0, 100);

        // get x and y from button number
        int[] xy = Map.GetXY(num+1);
        int x = xy[0];
        int y = xy[1];

        // if a button is None than attack
        if (Map.GameMap[x, y] == Map.map.None)
        {
            Map.GameMap[x, y] = Map.map.B;
            buttonPanel.transform.GetChild(num).GetComponent<Image>().color = new Color32(255, 0, 0, 255);

            // check if b wins
            if (GameController.CheckStone(Map.map.B, 3))
                Debug.Log("B wins! Yo");
        }
        else
        {
            Attack();
        }
    }





    // make an instance of this class
    public static EnemyCommand enemyCommand;

    private void Awake()
    {
        if (enemyCommand == null)   enemyCommand = this;
        else                        Destroy(this);
    }

}
