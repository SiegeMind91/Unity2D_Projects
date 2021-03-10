using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Paddle : MonoBehaviour
{

    //Configuration Parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    //Cached references
    GameSession theGameSession;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Way to debug mouse position - Can use .x, .y, or .z for different vectors*/
        //Debug.Log(Input.mousePosition.x)

        /*This lets us move our paddle with the mouse, proportionally to the screen size*/
        //Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);

        //float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        /* My first method to stop the paddle from moving off-screen
        if (mousePosInUnits < 0f)
        {
            mousePosInUnits = 0f;
        }

        if (mousePosInUnits > 16f)
        {
            mousePosInUnits = 16f;
        }

        Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y);
        transform.position = paddlePos;
        */

        //The improved method for stopping the paddle from moving off-screen
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
