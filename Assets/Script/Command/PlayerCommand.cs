using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCommand : MonoBehaviour
{
    
    public void Attack()
    {
        // get x and y from button number  
        int x = MapControl.xy[0];
        int y = MapControl.xy[1];

        // if a button is selected than attack
        if ((MapControl.selected_button != null) &&
            (Map.GameMap[x, y] == Map.map.Selected))
        {
            Map.GameMap[x, y] = Map.map.A;
            MapControl.selected_button.GetComponent<Image>().color = new Color32(0, 255, 0, 255);

            // check if a wins
            if (GameController.CheckStone(Map.map.A, 5))
                Debug.Log("A wins! Yo");

            EnemyCommand.enemyCommand.Attack();
        }
    }
}
