using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameController
{ 

    // check if same color stones are connected
    public static bool CheckStone(Map.map color, int num, int x, int y)
    {
        // initialize the count
        int count = 0;
        // initialize the list of xy[,] coodinates where the stones are
        List<int[]> xy = new List<int[]>();

        // up and down
        for (int i = 0; i < 10; i++){
            for (int j = 0; j < 10; j++)
            {
                if (Map.GameMap[i, j] == Map.map.None || Map.GameMap[i, j] != color){
                    // empty the list
                    xy.Clear();
                    count = 0;
                }
                else
                {
                    // add xy to the list
                    xy.Add(new int[] { i, j });
                    count++;
                }

                // when count is num
                if (count == num)
                {
                    // check if x y is included in xy
                    foreach (int[] a in xy)
                    {
                        if (a[0] == x && a[1] == y)
                            return true;
                    }
                }
            }
        }

        // initialize the count
        count = 0;
        // empty the list
        xy.Clear();

        // side by side
        for (int i = 0; i < 10; i++){
            for (int j = 0; j < 10; j++)
            {
                if (Map.GameMap[j, i] == Map.map.None || Map.GameMap[j, i] != color){
                    // empty the list
                    xy.Clear();
                    count = 0;
                }
                else
                {
                    // add xy to the list
                    xy.Add(new int[] { j, i });
                    count++;
                }

                // when count is num
                if (count == num)
                {
                    // check if x y is included in xy
                    foreach (int[] a in xy)
                    {
                        if (a[0] == x && a[1] == y)
                            return true;
                    }
                }
            }
        }


        // initialize the count
        count = 0;
        // empty the list
        xy.Clear();

        // diagnol (left, upper)
        for (int i = 0; i < 10; i++)
        {
            // up movement count
            int up = 0;

            for (int j = i; j < 10; j++)
            {
                if (Map.GameMap[j, up] == Map.map.None || Map.GameMap[j, up] != color){
                    // empty the list
                    xy.Clear();
                    count = 0;
                }
                else
                {
                    // add xy to the list
                    xy.Add(new int[] { j, up });
                    count++;
                }

                // when count is num
                if (count == num)
                {
                    // check if x y is included in xy
                    foreach (int[] a in xy)
                    {
                        if (a[0] == x && a[1] == y)
                            return true;
                    }
                }

                up++;
            }
        }

        // initialize the count
        count = 0;
        // empty the list
        xy.Clear();

        // diagnol (left, down)
        for (int i = 0; i < 10; i++)
        {
            // up movement count
            int up = 0;

            for (int j = i; j < 10; j++)
            {
                if (Map.GameMap[up, j] == Map.map.None || Map.GameMap[up, j] != color){
                    // empty the list
                    xy.Clear();
                    count = 0;
                }
                else
                {
                    // add xy to the list
                    xy.Add(new int[] { up, j });
                    count++;
                }

                // when count is num
                if (count == num)
                {
                    // check if x y is included in xy
                    foreach (int[] a in xy)
                    {
                        if (a[0] == x && a[1] == y)
                            return true;
                    }
                }

                up++;
            }
        }



        // initialize the count
        count = 0;
        // empty the list
        xy.Clear();

        // diagnol (right)
        for (int i = 0; i < 10; i++)
        {
            // down movement count
            int down = 9;

            for (int j = i; j < 10; j++)
            {
                if (Map.GameMap[j, down] == Map.map.None || Map.GameMap[j, down] != color){
                    // empty the list
                    xy.Clear();
                    count = 0;
                }
                else
                {
                    // add xy to the list
                    xy.Add(new int[] { j, down });
                    count++;
                }

                // when count is num
                if (count == num)
                {
                    // check if x y is included in xy
                    foreach (int[] a in xy)
                    {
                        if (a[0] == x && a[1] == y)
                            return true;
                    }
                }

                down--;
            }
        }


        // initialize the count
        count = 0;
        // empty the list
        xy.Clear();

        // diagnol (right)
        for (int i = 9; i >= 0; i--)
        {
            // down movement count
            int down = 0;

            for (int j = i; j >= 0; j--)
            {
                if (Map.GameMap[down, j] == Map.map.None || Map.GameMap[down, j] != color){
                    // empty the list
                    xy.Clear();
                    count = 0;
                }
                else
                {
                    // add xy to the list
                    xy.Add(new int[] { down, j });
                    count++;
                }

                // when count is num
                if (count == num)
                {
                    // check if x y is included in xy
                    foreach (int[] a in xy)
                    {
                        if (a[0] == x && a[1] == y)
                            return true;
                    }
                }

                down++;
            }
        }


        //まだ判定がついていないとき
        return false;
    }
}
