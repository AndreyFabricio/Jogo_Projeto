using UnityEngine;
//Script para controlar as ações do personagem jogador
public class Test_Character : MonoBehaviour {

    //Variável que vai definir a velocidade de movimento do jogador
    [SerializeField]
    private float moveSpeed;

    //Recebe o controlador de animações do jogador
    private Animator anima;
    //Variável que define se o jogador está se movendo ou não
    private bool playerMoving;
    //Variável que irá receber o último movimento feito pelo jogador
    private Vector2 lastMove;
    //Variável que recebe o Rigidbody2D do jogador
    private Rigidbody2D myRigidBody;
    //Variável que irar definir como o jogador irá se mover
    private Vector2 moveVelocity;

    // Inicialização de variáveis
    private void Start () {

        //Inicializa a variável de animação
        anima = GetComponent<Animator>();
        //Inicializada a variável Rigidbody2D
        myRigidBody = GetComponent<Rigidbody2D>();

	}

    // Atualiza a cada frame fixo
    private void FixedUpdate () {
         
        //Chama a classe que lida com movimento
         HandleMovement();

	}
    
    //Classe que lida com o movimento do jogador de acordo com o que foi recebido pelo Input
    private void HandleMovement()
    {
        //Vetor que armazena a cada frame fixo os valores do Input
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        //Se o valor recebido por moveInput não for zero
        if (moveInput != Vector2.zero)
        {
            //Define a velocidade do movimento
            moveSpeed = 10f;
            //Define enemyMoving como true
            playerMoving = true;
            //enemyLastMove recebe o valor do Input
            lastMove = moveInput;
            //Move o personagem para a posição indicada pelo Input
            //O personagem irá se mover de acordo com o moveSpeed, o Input e fixedDeltaTime
            myRigidBody.MovePosition(myRigidBody.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
            //Define o eixo horizontal da animação
            anima.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            //Define o eixo vertical da animação
            anima.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            //Define para o Animator que o jogador está se movendo
            //Inicia a animação de acordo com o movimento
            anima.SetBool("PlayerMoving", playerMoving);
            //Define qual o último movimento horizontal (para parar o personagem de acordo com o movimento)
            anima.SetFloat("LastMoveX", lastMove.x);
            //Define qual o último movimento vertical (para parar o personagem de acordo com o movimento)
            anima.SetFloat("LastMoveY", lastMove.y);

        } else
        {
            //Se o valor do Input for 0 (sem movimento)
            if (moveInput == Vector2.zero)
            {
                //Define que o jogador está parado
                playerMoving = false;
                //Define a velocidade como 0
                moveSpeed = 0f;
                //Define para o Animator que o jogador está parado
                //Inicia a animação de acordo com o último movimento
                anima.SetBool("PlayerMoving", playerMoving);

            }
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {

            //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GetComponent<Collider2D>());

        }

    }

}
