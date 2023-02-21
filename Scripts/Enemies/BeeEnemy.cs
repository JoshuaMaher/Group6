
using UnityEngine;

public class BeeEnemy : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform enemy;
    [SerializeField] private Animator anima;

    [Header("Idle")]
    [SerializeField] private float timeIdle;
    private float idleTimer;

    [Header("Movement")]
    [SerializeField] private float speed;
    private Vector3 initialScale;
    private bool movingLeft;
    


    private void Awake()
    {
        initialScale = enemy.localScale;
    }

    private void OnDisable()
    {
        anima.SetBool("moving", false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                Moving(-1);
            else
                ChangeDirection();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                Moving(1);
            else
                ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        anima.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if(idleTimer > timeIdle)
            movingLeft=!movingLeft;
    }

    private void Moving(int _direction)
    {
        idleTimer = 0;
        anima.SetBool("moving", true);

        //FACE IN THE RIGHT DIRECTION
        enemy.localScale = new Vector3(Mathf.Abs(initialScale.x) * _direction, initialScale.y, initialScale.z);

        //MOVE IN THE RIGHT DIRECTION
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }



}
