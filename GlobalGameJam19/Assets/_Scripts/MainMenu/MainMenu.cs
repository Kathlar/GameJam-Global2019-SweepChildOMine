using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float moveSpeed = 3;
    public string firstLevel = "Level01";

    public Camera camera;
    public List<Transform> roadToPlayMenu = new List<Transform>();
    protected Vector3 startPosition;
    protected Quaternion startRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void PlayButton()
    {
        MoveByRoad(roadToPlayMenu, false, "LoadFirstScene");
    }

    void LoadFirstScene()
    {
        LoadScene(firstLevel);
    }

    void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OptionsButton()
    {

    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
         Application.OpenURL("https://kathlar.itch.io/");
#else
         Application.Quit();
#endif
    }

    protected void MoveByRoad(List<Transform> road, bool backwards = false, string methodAfter = "")
    {
        StartCoroutine(MoveByRoadCoroutine(road, backwards, methodAfter));
    }

    protected IEnumerator MoveByRoadCoroutine(List<Transform> road, bool backwards = false, string methodAfter = "")
    {
        Transform nextPoint = null;
        if (!backwards)
        {
            for (int i = 0; i < road.Count; i++)
            {
                nextPoint = road[i];
                do
                {
                    camera.transform.position = Vector3.Lerp(camera.transform.position, nextPoint.position, Time.deltaTime * moveSpeed);
                    camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, nextPoint.rotation, Time.deltaTime * moveSpeed);
                    yield return null;
                }
                while (Vector3.Distance(camera.transform.position, nextPoint.position) > .2f);
            }
        }
        else
        {
            for (int i = road.Count-2; i >= 0; i--)
            {
                nextPoint = road[i];
                do
                {
                    camera.transform.position = Vector3.Lerp(camera.transform.position, nextPoint.position, Time.deltaTime * moveSpeed);
                    camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, nextPoint.rotation, Time.deltaTime * moveSpeed);
                    yield return null;
                }
                while (Vector3.Distance(camera.transform.position, nextPoint.position) > .2f);
            }

            do
            {
                camera.transform.position = Vector3.Lerp(camera.transform.position, startPosition, Time.deltaTime * moveSpeed);
                camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, startRotation, Time.deltaTime * moveSpeed);
                yield return null;
            }
            while (Vector3.Distance(camera.transform.position, startPosition) > .2f);
        }

        if (methodAfter != "") Invoke(methodAfter, .01f);
    }
}
