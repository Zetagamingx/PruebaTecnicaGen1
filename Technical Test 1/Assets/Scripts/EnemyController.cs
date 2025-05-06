using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private UIManager uiManager;
    private EnemySpawnManagerController EnemySpawnManagerController;
    public Material[] materialColor;

    void Start()
    {
        uiManager = FindFirstObjectByType<UIManager>();
        EnemySpawnManagerController = FindFirstObjectByType<EnemySpawnManagerController>();
       
    }

    void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(Deactivate( gameObject, 22f));
    }

    IEnumerator Deactivate(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (obj.activeInHierarchy)
        {
            uiManager.enemiesOnScreen -= 1;
            obj.SetActive(false);
        }
    }

    
    void Update()
    {
        
    }

    public void ChooseColor(int colorPick)
    {
        if (materialColor != null)
        {
            Renderer rend = gameObject.GetComponent<Renderer>();
            if (rend != null)
            {

                switch (colorPick)
                    {
                        case 0:
                        rend.material = materialColor[0];
                        break;

                        case 1:
                        rend.material = materialColor[1];
                        break;

                        case 2:
                        rend.material = materialColor[2];
                        break;
                    
                    }
            }
        } 
            
    }
    public void AttackObject()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            uiManager.enemiesOnScreen -= 1;
            gameObject.SetActive(false);

        }
    }
}
