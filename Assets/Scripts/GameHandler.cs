using UnityEngine;
//Script que serve como mediador de scripts do jogo
public class GameHandler : MonoBehaviour
{
    //importa a câmera
    public CameraFollow cameraFollow;
    //Importa o alvo da câmera
    public Transform playerTransform;
    //define zoom inicial
    private float zoom = 10f;

    private void Start()
    {
        //Configura o script cameraFollow
        cameraFollow.Setup(() => playerTransform.position, () => zoom);

    }

    private void Update()
    {
        //Chama a classe para controlar o zoom
        ZoomInOut();

    }

    public void ZoomInOut()
    {
        //Classe que controla o zoom usando os valores do Axis "Mouse ScrollWheel" 
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            //Quando o botão do meio do mouse é positivo diminui 2f do zoom
            zoom -= 1f;
            //Se o zoom ficar menor que 4f zoom vira 4f
            if (zoom < 4f) zoom = 4f;

        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            //Quando o botão do meio do mouse é negativo aumenta 2f do zoom
            zoom += 1f;
            //Se o zoom for maior que 20f zoom vira 20f
            if (zoom > 20f) zoom = 20f;

        }

    }

}