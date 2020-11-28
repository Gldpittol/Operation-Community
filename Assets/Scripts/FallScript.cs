using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallScript : MonoBehaviour
{

    public float speed;

    public float posX;
    public float posY;

    //public float timet;
    private void OnDisable()
    {
        transform.localPosition = new Vector2(posX, posY);
    }

    private void OnEnable()
    {
        transform.localPosition = new Vector2(posX, posY);
        StartCoroutine(DelayedDisable());
    }

    void Update()
    {
        //timet += Time.deltaTime;
        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - (speed * Time.deltaTime));
    }

    public IEnumerator DelayedDisable()
    {
        StaticVariables.youWin = 1;
        StaticVariables.SaveGame();
        yield return new WaitForSeconds(17f);
        Instantiate(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().transitionImage, new Vector3(0f, 0f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
        transform.parent.gameObject.SetActive(false);
    }
}
