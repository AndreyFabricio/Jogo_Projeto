using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script para alterar como um sprite se comporta na layer
//O script organiza os sprites de acordo com colisões em uma lista
public class Obstacle : MonoBehaviour, IComparable<Obstacle> {

    //Define uma variável que recebe o sprite
    public SpriteRenderer MySpriteRenderer { get; set; }

    //Variável que recebe a cor original do sprite
    private Color defaultColor;
    //Variável que deixa o sprite transparente
    private Color fadedColor;

    //Classe que organiza a ordem dos sprites na lista de obstáculos
    public int CompareTo(Obstacle other)
    {
        //Testa se a ordem do MySpriteRenderer na layer é maior que do sprite testado
        if (MySpriteRenderer.sortingOrder > other.MySpriteRenderer.sortingOrder)
        { return 1; }
        //Testa se a ordem do MySpriteRenderer na layer é menor que do sprite testado
        else if (MySpriteRenderer.sortingOrder < other.MySpriteRenderer.sortingOrder)
        { return -1; }
        //Retorna 0 caso a ordem do MySpriteRenderer na layer for igual ao sprite testado
        return 0;

    }

    //Inicialização das variáveis
    void Start () {
        //Inicializa MySpriteRenderer com o sprite
        MySpriteRenderer = GetComponent<SpriteRenderer>();
        //defaultColor recebe a cor do MySpriteRenderer
        defaultColor = MySpriteRenderer.color;
        //fadedColor recebe a cor do MySpriteRenderer
        fadedColor = defaultColor;
        //Dá transparência ao fadedColor
        fadedColor.a = 0.70f;

	}
	
    //Define o sprite como transparente
	public void FadeOut(){ MySpriteRenderer.color = fadedColor; }
    //Define o sprite com a cor normal
    public void FadeIn() { MySpriteRenderer.color = defaultColor; }

}
