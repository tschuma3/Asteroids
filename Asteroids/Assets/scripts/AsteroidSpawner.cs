using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawner for Asteroids
/// </summary>
public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;

    float bottom;
    float top;
    float left;
    float right;

    // Start is called before the first frame update
    void Start()
    {
        //Screen control
        Vector3 bottom = new Vector3(0, ScreenUtils.ScreenBottom, 0);
        Vector3 top = new Vector3(0, ScreenUtils.ScreenTop, 0);
        Vector3 left = new Vector3(ScreenUtils.ScreenLeft, 0, 0);
        Vector3 right = new Vector3(ScreenUtils.ScreenRight, 0, 0);

        //Spawns four asteroids
        Asteroid asteroidS = prefabAsteroid.GetComponent<Asteroid>();
        GameObject asteroid = Instantiate(prefabAsteroid) as GameObject;
        GameObject asteroid0 = Instantiate(prefabAsteroid) as GameObject;
        GameObject asteroid1 = Instantiate(prefabAsteroid) as GameObject;
        GameObject asteroid2 = Instantiate(prefabAsteroid) as GameObject;
        asteroid.GetComponent<Asteroid>().AsteroidInitialize(Direction.Up, bottom);
        asteroid0.GetComponent<Asteroid>().AsteroidInitialize(Direction.Down, top);
        asteroid1.GetComponent<Asteroid>().AsteroidInitialize(Direction.Left, right);
        asteroid2.GetComponent<Asteroid>().AsteroidInitialize(Direction.Right, left);               
    }
}

