using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float max = 14f;
    [SerializeField] float min = 1f;
    [SerializeField] float ScreenWidthInUnits = 16f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x;
        Debug.Log(Input.mousePosition.x / Screen.width * ScreenWidthInUnits);
        x = Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        Vector2 PaddlePos = new Vector2(transform.position.x, transform.position.y);
        PaddlePos.x = Mathf.Clamp(x, min, max);
        transform.position = PaddlePos;
    }
}
