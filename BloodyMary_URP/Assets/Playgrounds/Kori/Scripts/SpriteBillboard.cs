using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    // Update is called once per frame after the camera
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
    }
}
