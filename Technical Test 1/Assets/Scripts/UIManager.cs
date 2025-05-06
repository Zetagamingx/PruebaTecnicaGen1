using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public int enemiesOnScreen;
    public TextMeshProUGUI activeEnemies;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activeEnemies.text = " Enemigos en Pantalla " + enemiesOnScreen;
    }
}
