using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public GameObject wallButtons;
    public GameObject wallKeys;
    public GameObject father;
    private int rows = 3;
    private int columns = 6;
    private float sizeButton = 6f;
    private float sizekeys = 1.8f;
    private GameObject[,] board;

    private float x;
    private float y;
    private float z;

    void Awake()
    {
        x = father.transform.position.x;
        y = father.transform.position.y;
        z = father.transform.position.z;
    }

    void Start()
    {
        initialzeDoard();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void initialzeDoard()
    {
        board = new GameObject[rows, columns];

        for (int r = 0; r < rows; r++){
            for (int c = 0; c < columns; c++){

                if (r == 0 && c == 0)
                {
                    board[r, c] = Instantiate(wallButtons, new Vector3(x + sizeButton / 2f, y, z + sizeButton / 2f), Quaternion.identity);
                    board[r, c].transform.Rotate(Vector3.right, 90f);
                }
                else
                {
                    if (r == 0 && c == 5)
                    {
                        board[r, c] = Instantiate(wallButtons, new Vector3(x + 1.5f * sizeButton + (columns - 2) * sizekeys, y, z + sizeButton / 2f), Quaternion.identity);
                        board[r, c].transform.Rotate(Vector3.right, 90f);
                    }
                    else
                    {
                        if ((c >= 1) && (c <= columns - 2))
                        {
                            //Debug.Log("hola" + c);
                            board[r, c] = Instantiate(wallKeys, new Vector3(x + sizeButton + (c - 1) * sizekeys + sizekeys / 2f, y, z + r * sizekeys + sizekeys / 2f), Quaternion.identity);
                            board[r, c].transform.Rotate(Vector3.right, 90f);
                        }
                      
                    }
                }
            
            }
        }
    }
}