using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script para definir a ordem em que um objeto irá ficar na camada
//Serve de apoio ao script Obstacle.cs
public class LayerSorter : MonoBehaviour {
    //Variável que recebe o sprite
    private SpriteRenderer parentRenderer;
    //Variável que recebe os obstacles
    private List <Obstacle> obstacles = new List<Obstacle>();

	//Inicialização de variáveis
	void Start () {
        //Inicializa parentRenderer com o sprite
        parentRenderer = transform.parent.GetComponent<SpriteRenderer>();

	}
	
    //Quando o personagem jogador aciona uma colisão
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Testa se a tag do objeto da colisão é "Obstacle"
        if (collision.tag == "Obstacle")
        {
            //Cria uma variável "o" na lista de "obstacles"
            //A variável "o" recebe o sprite da colisão
            Obstacle o = collision.GetComponent<Obstacle>();
            //Chama a classe "FadeOut()" para alterar o sprite
            o.FadeOut();

            //Testa se o sprite é o único obstáculo
            //Caso não seja o único obstáculo, testa se o obstáculo está numa posição menor no sortingOrder 
            if (obstacles.Count == 0 || o.MySpriteRenderer.sortingOrder - 1 < parentRenderer.sortingOrder)
                //Define a sortingOrder maior como a sortingOrder de "o" -1
                { parentRenderer.sortingOrder = o.MySpriteRenderer.sortingOrder - 1; }
            //Adiciona o sprite da colisão a lista de "obstacles"
            obstacles.Add(o);
                        
        }
    }

    //Quando o personagem jogador sai de uma colisão
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Se a tag da colisão for "Obstacle"
        if (collision.tag == "Obstacle")
        {
            //A variável "o" recebe o sprite da colisão
            Obstacle o = collision.GetComponent<Obstacle>();
            //Chama a classe FadeIn() para alterar o sprite
            o.FadeIn();
            //Remove "o" da lista de "obstacles"
            obstacles.Remove(o);

            //Se o sprite for o único obstáculo
            if (obstacles.Count == 0)
                //Define a ordem do obstáculo na layer como 200
                { parentRenderer.sortingOrder = 200; }
            else
            //Se o sprite não for o único obstáculo
            {
                //Organiza a lista "obstacles"
                obstacles.Sort();
                //Define a ordem na lista "obstacles"
                parentRenderer.sortingOrder = 
                    obstacles[0].MySpriteRenderer.sortingOrder - 1;

            }

        }

    }
    
}
