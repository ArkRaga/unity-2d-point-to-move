using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    public Vector2 wayToGo;
    private Vector2 target;
    private Vector2 playerPosition;

    
   
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(0f, 0f);
        playerPosition = gameObject.transform.position;
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target,step);
        if (Input.GetMouseButtonDown(1))
        {
            // Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null)
            {
                Debug.Log("Pressed secondary button.");
               // Debug.Log($"{hit.point} has been hit");
                target = new Vector2(hit.point.x, hit.point.y);
                Debug.Log(target);
            }
        }
        rb.AddForce(wayToGo * speed);
    }
}
