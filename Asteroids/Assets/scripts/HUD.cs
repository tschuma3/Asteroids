using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class takes care of the heads up display (HUD) for the game
/// </summary>
public class HUD : MonoBehaviour
{
    //Saved for ease of access
    [SerializeField]
    Text text;
    float elaspedSeconds = 0;
    bool shipQuestionMark = true;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //Timer is based off if the ship is still alive
        if (shipQuestionMark != false)
        {
            elaspedSeconds += Time.deltaTime;
            text.text = "" + (int)elaspedSeconds;
            text.text.ToString();
        }
    }

    /// <summary>
    /// Stops the game timer
    /// </summary>
    public void StopGameTimer()
    {
        shipQuestionMark = false;
    }
}
