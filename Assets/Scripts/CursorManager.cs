using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorGunNormal;
    [SerializeField] private Texture2D cursorGunShoot;
    [SerializeField] private Texture2D cursorGunReload;
    private Vector2 neoHotsPost  = new Vector2(16, 48);

    void Start()
    {
        Cursor.SetCursor(cursorGunNormal, neoHotsPost, CursorMode.Auto);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorGunShoot, neoHotsPost, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursorGunNormal, neoHotsPost, CursorMode.Auto);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Cursor.SetCursor(cursorGunReload, neoHotsPost, CursorMode.Auto);
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            Cursor.SetCursor(cursorGunNormal, neoHotsPost, CursorMode.Auto);
        }
    }
}
