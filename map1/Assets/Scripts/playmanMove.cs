using UnityEngine;

public class playmanMove : MonoBehaviour
{
    public float speed = 0.35f;//游戏人物移动速度
    private Vector2 dest = Vector2.zero; //人物下次移动的目的地

    private void Start()
    {
        dest = transform.position; //定义游戏人物开始不动
    }

    private void FixedUpdate()
    {
        Vector2 temp = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(temp);
        if ((Vector2)transform.position == dest)
        {
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && Valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
            }
            if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && Valid(Vector2.down))
            {
                dest = (Vector2)transform.position + Vector2.down;
            }
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && Valid(Vector2.left))
            {
                dest = (Vector2)transform.position + Vector2.left;
            }
            if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && Valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
            }
            //获取移动方向
            Vector2 dir = dest - (Vector2)transform.position;
            //把获取到的方向传给状态机
            GetComponent<Animator>().SetFloat("DirX",dir.x);
            GetComponent<Animator>().SetFloat("DirY", dir.y);
        }
    }
    //检测目的地能否到达
    private bool Valid(Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
