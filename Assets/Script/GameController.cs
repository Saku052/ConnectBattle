using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameController
{ 

    // check if same color stones are connected
    public static bool CheckStone(Map.map color, int num)
    {
        // initialize the count
        int count = 0;

        // side by side
        for (int i = 0; i < 10; i++){
            for (int j = 0; j < 10; j++)
            {
                if (Map.GameMap[i, j] == Map.map.None || Map.GameMap[i, j] != color)
                    count = 0;
                else
                    count++;

                // when count is num
                if (count == num)
                {
                    
                    if (color == Map.map.A)
                    {
                        Debug.Log("A wins!");
                    }
                    else if (color == Map.map.B)
                    {
                        Debug.Log("B wins!");
                    }

                    return true;
                }
            }
        }

        // initialize the count
        count = 0;

        // up and down
        for (int i = 0; i < 10; i++){
            for (int j = 0; j < 10; j++)
            {
                if (Map.GameMap[j, i] == Map.map.None || Map.GameMap[j, i] != color)
                    count = 0;
                else
                    count++;

                // when count is num
                if (count == num)
                {

                    if (color == Map.map.A)
                    {
                        Debug.Log("A wins!");
                    }
                    else if(color == Map.map.B)
                    {
                        Debug.Log("B wins!");
                    }

                    return true;
                }
            }
        }

        // initialize the count
        count = 0;

        // diagnol (right)
        for (int i = 0; i < 10; i++)
        {
            // up movement count
            int up = 0;

            for (int j = i; j < 10; j++)
            {
                //squaresの値が空のとき
                if (Map.GameMap[j, up] == Map.map.None || Map.GameMap[j, up] != color)
                    count = 0;
                else
                    count++;

                // when count is num
                if (count == num)
                {
                    if (color == Map.map.A)
                    {
                        Debug.Log("A wins!");
                    }
                    else if (color == Map.map.B)
                    {
                        Debug.Log("B wins!");
                    }

                    return true;
                }

                up++;
            }
        }

        // initialize the count
        count = 0;

        // diagnol (left)
        for (int i = 0; i < 10; i++)
        {
            // down movement count
            int down = 9;

            for (int j = i; j < 10; j++)
            {
                if (Map.GameMap[j, down] == Map.map.None || Map.GameMap[j, down] != color)
                    count = 0;
                else
                    count++;

                // when count is num
                if (count == num)
                {
                    if (color == Map.map.A)
                    {
                        Debug.Log("A wins!");
                    }
                    else if (color == Map.map.B)
                    {
                        Debug.Log("B wins!");
                    }

                    return true;
                }

                down--;
            }
        }

        //まだ判定がついていないとき
        return false;
    }
}
