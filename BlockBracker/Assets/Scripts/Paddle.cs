using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float ScreenWidthInUnits = 16f;
    [SerializeField] float xMax = 15f;
    [SerializeField] float xMin = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * ScreenWidthInUnits;

        Vector2 paddlePos = new Vector2(transform.position.x , transform.position.y);

        paddlePos.x = Mathf.Clamp(mousePositionInUnits, xMin, xMax);

        transform.position = paddlePos;
    }
}
