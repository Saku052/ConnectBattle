using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapControl : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;

    public static int[] xy = new int[2];  // current xy
    public static GameObject selected_button; // selected button
    private int[] prev_xy = new int[2];  // previous xy
    private GameObject prev_button; // previous button
    
    // Get the button number from the button clicked
    public void ButtonClicked()
    {
        
        selected_button = eventSystem.currentSelectedGameObject;
        int button_number = int.Parse(selected_button.name.Substring(7));

        // Get x and y from button number
        xy = Map.GetXY(button_number);
        int x = xy[0];
        int y = xy[1];

        // select location if the button is empty
        if (Map.GameMap[x, y] == Map.map.None)
        {
            Map.GameMap[x, y] = Map.map.Selected;
            selected_button.GetComponent<Image>().color = new Color32(148, 204, 154, 255);
        }
        // unselect location if the button is selected
        else if (Map.GameMap[x, y] == Map.map.Selected)
        {
            Map.GameMap[x, y] = Map.map.None;
            selected_button.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }

        // when different button is clicked, unselect the previous button
        if ((prev_xy[0] != xy[0] || prev_xy[1] != xy[1]) && 
            Map.GameMap[prev_xy[0], prev_xy[1]] == Map.map.Selected)
        {
            prev_button.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Map.GameMap[prev_xy[0], prev_xy[1]] = Map.map.None;
        }

        prev_xy = xy;
        prev_button = selected_button;
    }
}


public static class Map
{
    // instance of map
    public static map[,] GameMap;
    public enum map{
        None, Selected, A, B
    }

    // create 10x10 map
    private readonly static int mapsize = 10;
    static Map()
    {
        Map.GameMap = new map[mapsize, mapsize];
    }

    // ----------
    // Identify the selected button
    // ----------

    // Get Button number from x and y
    public static int GetButtonNumber(int x, int y)
    {
        return x + y*mapsize;
    }

    // Get x and y from button number
    public static int[] GetXY(int buttonNumber)
    {
        int[] xy = new int[2];
        xy[0] = (buttonNumber-1) % mapsize;
        xy[1] = (buttonNumber-1) / mapsize;
        return xy;
    }
    
}