using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    // Configuration Parameters
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;
    

    // Use this for initialization
    void Start()
    {
        waypoints = waveConfig.getWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.getMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            //The vector2 in parenthesis was added due to Unity assuming a vector3 and giving it a Z value
            //which then made the enemy not move at all. Adding vector2 forces Unity to only give it an X and Y value
            if ((Vector2)transform.position == (Vector2)targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            //Once the enemy has reached its' final waypoint, we don't want it to be left in cache eating up memory
            Destroy(gameObject);
        }
    }


}
