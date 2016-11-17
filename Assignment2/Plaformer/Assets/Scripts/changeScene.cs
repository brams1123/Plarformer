using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

	public void SceneChanger(int changeTheScene)
    {
        SceneManager.LoadScene(changeTheScene);
    }
}
