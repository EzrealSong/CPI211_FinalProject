
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 50f;
    public bool objectdead = false;
    private float time = 2f;

    public GameWInUI gameWIn;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            if(this.gameObject.tag == "Boss")
            {
                this.gameObject.GetComponent<Animator>().Play("Death");
                Destroy(gameObject, time);
                gameWIn.Setup();

            }
            objectdead = true;
            this.GetComponent<NavMeshAgent>().Stop();
            Die();
        }
    }
    void Die()
    {
        //play death animation
        this.gameObject.GetComponent<Animator>().Play("Death");

        Destroy(gameObject, time);
    }

}
