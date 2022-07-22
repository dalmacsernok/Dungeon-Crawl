using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerData : MonoBehaviour
{
    // Start is called before the first frame update
     
    public static string PlayerName = "Dobby";
    public static string PlayMode = "Normal";
    public static string Character = "Harry";

    public void GetPlayerData(string s)
    {
        PlayerName = s;
    }

    public void GetPlayMode()
    {
        PlayMode = (EventSystem.current.currentSelectedGameObject.name).Split(' ')[2];
    }

    public void GetCharacter()
    {
        Character = (EventSystem.current.currentSelectedGameObject.name).Split(' ')[2];
    }

}
