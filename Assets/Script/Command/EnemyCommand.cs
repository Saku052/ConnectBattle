using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCommand : MonoBehaviour
{
    
    [SerializeField] private GameObject buttonPanel;
    public void Attack()
    {
        // get x and y from the AI function
        int[] xy = EnemyAI();
        int x = xy[0];
        int y = xy[1];

        // get button number
        int button_number = Map.GetButtonNumber(x, y);

        // if a button is None than attack
        if (Map.GameMap[x, y] == Map.map.None)
        {
            Map.GameMap[x, y] = Map.map.B;
            buttonPanel.transform.GetChild(button_number).GetComponent<Image>().color = new Color32(203, 88, 88, 255);

            StatusController.statusController.AttackB();
        }
    }


    private int[] EnemyAI()
    {
        // make socreMap
        int[,] scoreMap = new int[Map.GameMap.GetLength(0), Map.GameMap.GetLength(1)];

        // for loop scoreMap
        for (int i = 0; i < scoreMap.GetLength(0); i++){
            for (int j = 0; j < scoreMap.GetLength(1); j++){
                if (Map.GameMap[i, j] == Map.map.None)  // if GameMap is Nne
                {
                    Map.GameMap[i, j] = Map.map.B;  // put B

                    scoreMap[i, j] = 1;

                    if (GameController.CheckStone(Map.map.B, 5, i, j))
                        scoreMap[i, j] += 1000;
                    
                    else if (GameController.CheckStone(Map.map.B, 4, i, j))
                        scoreMap[i, j] += 40;
                    
                    else if (GameController.CheckStone(Map.map.B, 3, i, j))
                        scoreMap[i, j] += 15;

                    else if (GameController.CheckStone(Map.map.B, 2, i, j))
                        scoreMap[i, j] += 5;

                    Map.GameMap[i, j] = Map.map.None;  // remove B

                    Map.GameMap[i, j] = Map.map.A;  // put A

                    if (GameController.CheckStone(Map.map.A, 5, i, j))
                        scoreMap[i, j] += 100;
                    
                    else if (GameController.CheckStone(Map.map.A, 4, i, j))
                        scoreMap[i, j] += 80;

                    else if (GameController.CheckStone(Map.map.A, 3, i, j))
                        scoreMap[i, j] += 30;

                    else if (GameController.CheckStone(Map.map.A, 2, i, j))
                        scoreMap[i, j] += 10;
                    
                    Map.GameMap[i, j] = Map.map.None;  // remove A
                }
                else
                {
                    scoreMap[i, j] = 0;
                }
            }
        }

        // select random max score
        int[] maxXY = new int[2];
        int maxScore = 0;
        List<int[]> maxXYList = new List<int[]>();
        for (int i = 0; i < scoreMap.GetLength(0); i++){
            for (int j = 0; j < scoreMap.GetLength(1); j++){
                if (scoreMap[i, j] > maxScore)
                {
                    maxScore = scoreMap[i, j];
                    maxXYList.Clear();
                    maxXYList.Add(new int[] {i, j});
                }
                else if (scoreMap[i, j] == maxScore)
                {
                    maxXYList.Add(new int[] {i, j});
                }
            }
        }

        // show scoreMap in desending order
        string scoreMapString = "";
        for (int i = 0; i < scoreMap.GetLength(0); i++){
            for (int j = 0; j < scoreMap.GetLength(1); j++){
                scoreMapString += scoreMap[i, j] + " ";
            }
            scoreMapString += "\n";
        }


        // select random maxXY
        int randomIndex = Random.Range(0, maxXYList.Count);
        maxXY = maxXYList[randomIndex];

        return maxXY;
    }



    // make an instance of this class
    public static EnemyCommand enemyCommand;

    private void Awake()
    {
        if (enemyCommand == null)   enemyCommand = this;
        else                        Destroy(this);
    }

}
