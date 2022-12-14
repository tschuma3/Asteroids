using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Timer control
    const float timerSeconds = 2;
    Timer timer;

    /// <summary>
    /// Occurs at the beginning of running
    /// </summary>
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = timerSeconds;
        timer.Run();
    }

    /// <summary>
    /// Occurs every frame
    /// </summary>
    void Update()
    {
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// Adds force to the bullet
    /// </summary>
    /// <param name="forceDirection"></param>
    public void ApplyForce (Vector2 forceDirection)
    {
        const float forceMagnitude = 3;
        GetComponent<Rigidbody2D>().AddForce(forceMagnitude * forceDirection, ForceMode2D.Impulse);
    }
}
