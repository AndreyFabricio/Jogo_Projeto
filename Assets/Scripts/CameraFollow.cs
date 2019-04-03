using System;
using UnityEngine;

//Script para fazer a câmera seguir o jogador
//Necessita do GameHandler para o zoom, interagindo com esse Script
public class CameraFollow : MonoBehaviour {

    //Cria a variável câmera
    private Camera myCamera;
    //Cria uma Func para a posição da câmera
    private Func<Vector3> GetCameraFollowPositionFunc;
    //Cria uma Func para o zoom da câmera
    private Func<float> GetCameraZoomFunc;

    //Inicializa GetcameraFollowPositionFunc e GetCameraZoomFunc
    public void Setup(Func<Vector3> GetcameraFollowPositionFunc, Func<float> GetCameraZoomFunc)
    {

        this.GetCameraFollowPositionFunc = GetcameraFollowPositionFunc;
        this.GetCameraZoomFunc = GetCameraZoomFunc;

    }

    private void Start()
    {
        //Inicializa myCamera com o componente ligado a câmera na cena
        myCamera = transform.GetComponent<Camera>();

    }

    //Inicializa GetCameraFollowPositionFunc através de uma função
    public void SetGetCameraFollowPositionFunc(Func<Vector3> GetcameraFollowPositionFunc)
    {

        this.GetCameraFollowPositionFunc = GetcameraFollowPositionFunc;

    }

    //Chama a classe HandleMovement() que define o movimento da câmera
    //Chama a classe HandleZoom() que define o zoom da câmera com o script GameHandler
    void FixedUpdate () {

        HandleMovement();
        HandleZoom();

    }

    //Classe que controla o movimento da câmera
    private void HandleMovement()
    {
        //Vetor que pega a posição atual da câmera
        Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();
        //Define a posição "z" como 0
        cameraFollowPosition.z = transform.position.z;
        //Vetor para definir a direção que a câmera deve ir
        Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
        //Variável para definir a distância atual entre a câmera e o alvo da câmera
        float distance = Vector3.Distance(cameraFollowPosition, transform.position);
        //Variável para definir a velocidade da câmera
        float cameraMoveSpeed = 4f;

        //Se a distância entre o alvo e a câmera for maior que 0
        if (distance > 0)
        {
            //Move a câmera em direção ao alvo de acordo com a velocidade da câmera
            Vector3 newCameraPosition = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;
            //Calcula a distância depois que se moveu em direção ao alvo
            float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraFollowPosition);

            //Se a distância após se mover for maior que a distância entre a câmera e o alvo
            //Define a posição da câmera de acordo com a posição atual
            if (distanceAfterMoving > distance) { newCameraPosition = cameraFollowPosition; }

            //Transform da câmera recebe a posição atual da câmera
            transform.position = newCameraPosition;

        }

    }

    //Classe que controla o zoom da câmera
    private void HandleZoom()
    {
        //Zoom da câmera recebe os valores da Func GetCameraZoomFunc()
        float cameraZoom = GetCameraZoomFunc();
        //Calcula a diferença entre o zoom da câmera e o zoom atual
        float cameraZoomDifference = cameraZoom - myCamera.orthographicSize;
        //Define a velocidade do zoom
        float cameraZoomSpeed = 1f;

        //Define o zoom
        myCamera.orthographicSize += cameraZoomDifference * cameraZoomSpeed * Time.deltaTime;
        
        //Testa se a câmera ainda pode dar zoom e define a câmera
        if (cameraZoomDifference != 0){ myCamera.orthographicSize = cameraZoom; }

    }

}
