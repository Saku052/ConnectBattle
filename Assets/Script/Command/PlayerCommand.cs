using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCommand : MonoBehaviour
{
    private Color32 color_blue = new Color32(88, 132, 203, 255);

    private int x;
    private int y;

    private void getMapControl() {
        this.x = MapControl.xy[0];
        this.y = MapControl.xy[1];
    }

    private bool readyToAttack() {

        getMapControl();

        bool buttonSelected = MapControl.selected_button != null;
        bool mapSelected = Map.GameMap[x, y] == Map.map.Selected;

        return buttonSelected && mapSelected;
    }


    public void CrackAttack() {

        if (readyToAttack())
        {
            Map.GameMap[this.x, this.y] = Map.map.A;
            MapControl.selected_button.GetComponent<Image>().color = color_blue;

            // activate crack attack
            StatusController.statusController.CrackAttack();

            // start enemy turn
            TurnCommand.turnCommand.EnemyTurn();
        }
    }

    public void burstAttack() {

        if (readyToAttack()) {
            
            Map.GameMap[this.x, this.y] = Map.map.A;
            MapControl.selected_button.GetComponent<Image>().color = color_blue;

            // activate burst attack
            StatusController.statusController.BurstAttack();

            // start enemy turn
            TurnCommand.turnCommand.EnemyTurn();
        }
    }
}
