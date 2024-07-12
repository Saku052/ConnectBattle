using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCommand : MonoBehaviour
{
    Color32 color_blue = new Color32(88, 132, 203, 255);

    private bool readyToAttack() {

        int x = MapControl.xy[0];
        int y = MapControl.xy[1];

        bool buttonSelected = MapControl.selected_button != null;
        bool mapSelected = Map.GameMap[x, y] == Map.map.Selected;

        return buttonSelected && mapSelected;
    }


    public void CrackAttack() {
        // get x and y from button number
        int x = MapControl.xy[0];
        int y = MapControl.xy[1];

        // if a button is selected than attack
        if (readyToAttack())
        {
            Map.GameMap[x, y] = Map.map.A;
            MapControl.selected_button.GetComponent<Image>().color = color_blue;

            // activate crack attack
            StatusController.statusController.CrackAttack();

            // start enemy turn
            TurnCommand.turnCommand.EnemyTurn();
        }
    }

    public void burstAttack() {
        // get x and y from button number  
        int x = MapControl.xy[0];
        int y = MapControl.xy[1];

        // if a button is selected than attack
        if (readyToAttack()) {
            
            Map.GameMap[x, y] = Map.map.A;
            MapControl.selected_button.GetComponent<Image>().color = color_blue;

            // activate burst attack
            StatusController.statusController.BurstAttack();

            // start enemy turn
            TurnCommand.turnCommand.EnemyTurn();
        }
    }
}
