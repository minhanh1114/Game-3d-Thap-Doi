using UnityEngine;

public class Enemy : MonoBehaviour
{
    private string currentState = "IdleState";
    private Transform target;

    public float chaseRange = 5;
    public float attackRange = 10;
    public float speed = 3;

    public int health;
    public int maxHealth;

    public Animator animator;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.gameOver)
        {
            animator.enabled = false;
            this.enabled = false;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if(currentState == "IdleState")
        {
            if (distance < chaseRange)
                currentState = "ChaseState";
        }
        else if(currentState == "ChaseState")
        {
            //play the run animation
            animator.SetTrigger("chase");
            animator.SetBool("isAttacking", false);

            if(distance < attackRange)
                currentState = "AttackState";

            //di chuyển  về phía nhân vật
            if(target.position.x > transform.position.x)
            {
                //move right (phải)
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                //move left(trái)
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.identity;
                
            }

        }
        else if(currentState == "AttackState")
        {
            animator.SetBool("isAttacking", true);

            if (distance > attackRange)
                currentState = "ChaseState";
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        currentState = "ChaseState";

        if(health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //play a die animation
        animator.SetTrigger("isDead");
      
        //disable the script and the collider
        GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, 3);
        this.enabled = false;
    }
    
}
