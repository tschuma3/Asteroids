using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An asteroid
/// </summary>
public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite greenasteroid;
    [SerializeField]
    Sprite magentaasteroid;
    [SerializeField]
    Sprite whiteasteroid;
    [SerializeField]
    GameObject prefabAsteroid;

    //Saved for ease of access
    const float MinImpulseForce = 1f;
    const float MaxImpulseForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Randomly pick a sprite to be the asteroid
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int asteroidColor = Random.Range(0, 3);
        if (asteroidColor == 0)
        {
            spriteRenderer.sprite = greenasteroid;
        }
        else if (asteroidColor == 1)
        {
            spriteRenderer.sprite = magentaasteroid;
        }
        else
        {
            spriteRenderer.sprite = whiteasteroid;
        }
    }

    public void AsteroidInitialize(Direction direction, Vector3 location)
    {
        //Saved for ease of access 
        float angle = Random.Range(0, Mathf.Deg2Rad * 30);

        //The impulse force goes up                
        if (direction == Direction.Up)
        {
            //Applies an impulse force to get the asteroid moving
            angle += 75 * Mathf.Deg2Rad;
        }
        //The impulse force goes right
        else if (direction == Direction.Left)
        {
            //Applies an impulse force to get the asteroid moving
            angle += 165 * Mathf.Deg2Rad;
        }
        //The impulse force goes down
        else if (direction == Direction.Down)
        {
            //Applies an impulse force to get the asteroid moving
            angle += 255 * Mathf.Deg2Rad;
        }
        //The impulse force goes left
        else
        {
            //Applies an impulse force to get the asteroid moving
            angle = -15 * Mathf.Deg2Rad;
        }

        //Gets the asteroid to start moving
        StartMoving(angle);
        gameObject.transform.position = location;
    }

    /// <summary>
    /// Takes care of collisions with the asteroid
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Saved for ease of access
        float colliderRadius;
        float gameObjX = gameObject.transform.localScale.x / 2;
        float gameObjY = gameObject.transform.localScale.y / 2;
        Vector3 scale = new Vector3(gameObjX, gameObjY, 0);
        float angle = Random.Range(0, Mathf.PI * 2);

        //Collisions between the asteroid and bullet
        if (collision.gameObject.tag == "Bullet")
        {
            //Destroys the bullet
            AudioManager.Play(AudioClipName.AsteroidHit);
            Destroy(collision.gameObject);

            if (gameObjX < 0.5)
            {
                Destroy(gameObject);
            }
            else
            { 
                //Cuts the collider in half
                colliderRadius = GetComponent<CircleCollider2D>().radius / 2;

                //Instantiate the half asteroids and get it moving
                Instantiate(gameObject).transform.localScale = scale;
                Instantiate(gameObject).transform.localScale = scale;
                StartMoving(angle);

                //Destroys the bigger asteroid
                Destroy(gameObject);
            }
        }
    }

    public void StartMoving (float angle)
    {
        //Applies an impulse force to get the asteroid moving
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
    }
}


