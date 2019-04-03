using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC {

    private Transform target;
    [SerializeField]
    private float enemySpeed;
    private Vector2 direction;
    //Recebe o controlador de animações do jogador
    private Animator enemyAnimator;
    //Variável que define se o jogador está se movendo ou não
    private bool enemyMoving;

    private void Start()
    {

        enemyAnimator = GetComponent<Animator>();

    }

    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }

    private void Update()
    {

        FollowTarget();

    }

    private void FollowTarget()
    {
        
        if (target != null)
        {
            
            direction = (target.transform.position - transform.position).normalized;

            enemyMoving = true;

            transform.position = 
                Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);

            //Define o eixo horizontal da animação
            enemyAnimator.SetFloat("EnemyMoveX", direction.x);
            //Define o eixo vertical da animação
            enemyAnimator.SetFloat("EnemyMoveY", direction.y);
            //Define para o Animator que o jogador está se movendo
            //Inicia a animação de acordo com o movimento
            enemyAnimator.SetBool("EnemyMoving", enemyMoving);

        }
        else
        {

            enemyMoving = false;
            //Define qual o último movimento horizontal (para parar o personagem de acordo com o movimento)
            enemyAnimator.SetFloat("EnemyLastMoveX", direction.x);
            //Define qual o último movimento vertical (para parar o personagem de acordo com o movimento)
            enemyAnimator.SetFloat("EnemyLastMoveY", direction.y);//Define para o Animator que o jogador está se movendo
            //Inicia a animação de acordo com o movimento
            enemyAnimator.SetBool("EnemyMoving", enemyMoving);

        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Jogador")
        {

           // Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        }

    }

}
