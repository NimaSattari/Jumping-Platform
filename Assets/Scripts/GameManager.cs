using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject player;
    [SerializeField] GameObject Platform;
    private float minX = -2f, MaxX = 2f, minY = -4.5f, MaxY = -3.2f;
    private bool lerpCamera;
    private float lerpTime = 1.5f;
    private float lerpX;
    private void Awake()
    {
        MakeInstance();
        CreateInitialPlatforms();
    }
    private void Update()
    {
        if (lerpCamera)
        {
            LerpTheCamera();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void CreateInitialPlatforms()
    {
        Vector3 temp = new Vector3(Random.Range(minX, minX + 1.2f), Random.Range(minY, MaxY), 0);
        Instantiate(Platform, temp, Quaternion.identity);
        temp.y += 3f;
        Instantiate(player, temp, Quaternion.identity);
        temp = new Vector3(Random.Range(MaxX, MaxX - 1.2f), Random.Range(minY, MaxY), 0);
        Instantiate(Platform, temp, Quaternion.identity);
    }
    void LerpTheCamera()
    {
        float x = Camera.main.transform.position.x;
        x = Mathf.Lerp(x, lerpX, lerpTime * Time.deltaTime);
        Camera.main.transform.position = new Vector3(x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        if (Camera.main.transform.position.x >= (lerpX - 0.07f))
        {
            lerpCamera = false;
        }
    }
    public void CreateNewPlatformandLerp(float lerpPosition)
    {
        CreateNewPlatform();
        lerpX = lerpPosition + MaxX;
        lerpCamera = true;
    }
    void CreateNewPlatform()
    {
        float cameraX = Camera.main.transform.position.x;
        float newMaxX = (MaxX * 2) + cameraX;
        Instantiate(Platform, new Vector3(Random.Range(newMaxX, newMaxX - 1.2f), Random.Range(MaxY, MaxY - 1.2f), 0), Quaternion.identity);

    }
}
