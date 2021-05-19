using UnityEngine;

public class TouchAndDrag : MonoBehaviour
{
    float deltaX;
    float deltaY;

    bool canMove = false;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case (TouchPhase.Began):
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;

                        canMove = true;
                    }
                    break;

                case (TouchPhase.Moved):
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && canMove)
                    {
                        rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                    }
                    break;

                case (TouchPhase.Ended):
                    canMove = false;
                    break;
            }
        }
    }
}
