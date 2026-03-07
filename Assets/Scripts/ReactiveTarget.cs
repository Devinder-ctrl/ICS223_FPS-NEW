using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReactToHit()
    {

        WanderingAI enemyAI = GetComponent<WanderingAI>();
        //enemy operation on the null reference would cause a crash so if it not null change the state to dead
        if (enemyAI != null)
        {
            enemyAI.ChangeState(EnemyStates.dead);

        }
        Animator enemyAnimator = GetComponent<Animator>();
        if (enemyAnimator != null)
        {
            enemyAnimator.SetTrigger("Die");
            
        }
      //  StartCoroutine(Die());
    }
    private IEnumerator Die()
    {
       // iTween.RotateAdd(this.gameObject, new Vector3(-75, 0, 0), 1);
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    
    }

    private void DeadEvent()
    {
        Destroy(this.gameObject);
    }
}
