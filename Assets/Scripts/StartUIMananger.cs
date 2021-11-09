using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

# if UNITY_EDITOR
    using UnityEditor;
# endif

[DefaultExecutionOrder(1000)]
public class StartUIMananger : MonoBehaviour
{
  
  public InputField inputName;

  public Text title;
 


  private void Start()
  {
      GameMananger.Instance.LoadScore();
      setTitle();
      
  }




  public void setTitle()
  {
      if(GameMananger.Instance.highscore != 0){
          title.text = $"Best Score: {GameMananger.Instance.highScoreName} : {GameMananger.Instance.highscore}";

      }else{
          title.text = $"Best Score: : 0";
      }


  }



  public void SetPlayerName()
  {
      GameMananger.Instance.SetPlayerName(inputName.text);
  }


  public void StartNew()
  {
      SceneManager.LoadScene(1);


  }

  public void Exit(){

      #if UNITY_EDITOR
      EditorApplication.ExitPlaymode();
      #else
        Application.Quit();
      #endif

  }






}
