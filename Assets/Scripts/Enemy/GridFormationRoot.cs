using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFormationRoot : MonoBehaviour {

    public float screenRight,screenLeft;
    public float movementHorizontalSpeed;

    private GameObject[,] gridEnemy;
    public static GridFormationRoot instance;
    private bool right;

    public int sizeX, sizeY;

    private void Awake()
    {
        instance = this;
    }


    public void CreateGrid(GameObject enemy)
    {
        gridEnemy = new GameObject[sizeX, sizeY];
        for (int x = 0; x < gridEnemy.GetLength(0); x++)
        {
            for (int y = 0; y < gridEnemy.GetLength(1); y++)
            {
                Vector3 pos = new Vector3(transform.position.x+ x-sizeX/2, transform.position.y -y - sizeY / 2, 0);
                gridEnemy[x, y] = Instantiate(enemy);
                gridEnemy[x, y].transform.SetParent(this.transform);                
                gridEnemy[x, y].transform.localPosition = pos ;
                gridEnemy[x, y].GetComponent<Enemy>().cordGrid = pos;
            }
        }
        //Debug.Log("Create Grid with Enemys");
    }
    void Update ()
    {
        GridMovement();  
    }

    public void GridMovement()
    {
        Vector3 rightVect = new Vector3(screenRight, transform.position.y, transform.position.z);
        Vector3 leftVect = new Vector3(screenLeft, transform.position.y, transform.position.z);
        if (right)
            transform.position = Vector3.MoveTowards(transform.position, rightVect, movementHorizontalSpeed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, leftVect, movementHorizontalSpeed * Time.deltaTime);

        if (transform.position == leftVect) right = true;
        else if (transform.position == rightVect) right = false;
    }
}
