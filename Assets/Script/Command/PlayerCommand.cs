using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCommand : MonoBehaviour
{
    
    public void CrackAttack()
    {
        // get x and y from button number  
        int x = MapControl.xy[0];
        int y = MapControl.xy[1];

        // if a button is selected than attack
        if ((MapControl.selected_button != null) &&
            (Map.GameMap[x, y] == Map.map.Selected))
        {
            Map.GameMap[x, y] = Map.map.A;
            MapControl.selected_button.GetComponent<Image>().color = new Color32(88, 132, 203, 255);

            // activate crack attack
            StatusController.statusController.CrackAttack();

            DamageAnimationCommand.damageAnimationCommand.DamageAnima();

            // start enemy turn
            TurnCommand.turnCommand.EnemyTurn();
        }
    }

    public void burstAttack()
    {
        // get x and y from button number  
        int x = MapControl.xy[0];
        int y = MapControl.xy[1];

        // if a button is selected than attack
        if ((MapControl.selected_button != null) &&
            (Map.GameMap[x, y] == Map.map.Selected))
        {
            
            Map.GameMap[x, y] = Map.map.A;
            MapControl.selected_button.GetComponent<Image>().color = new Color32(88, 132, 203, 255);

            // activate burst attack
            StatusController.statusController.BurstAttack();

            // start enemy turn
            TurnCommand.turnCommand.EnemyTurn();
        }
    }
}
