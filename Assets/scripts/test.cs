using UnityEngine; 
public class test : MonoBehaviour 
{ 
        ScreenDamage script;
        void Start() 
        { 
                script = GetComponent<ScreenDamage>(); 
        } 
     
         void Update() 
        { 
                // decrease health  
                if (Input.GetKeyDown(KeyCode.A)) { 
                         script.CurrentHealth -= 10f; 
                } 

                // increase health  
                if (Input.GetKeyDown(KeyCode.D)) { 
                        script.CurrentHealth += 10f; 
                } 

                //get current health  
                if (Input.GetKeyDown(KeyCode.Space)) { 
                        Debug.Log(script.CurrentHealth); 
                } 
        } 
 }