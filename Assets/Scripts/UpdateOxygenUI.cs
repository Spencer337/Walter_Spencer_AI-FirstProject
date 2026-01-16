using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.UI;

public class UpdateOxygenUI : MonoBehaviour
{
    //public BBParameter<GameObject> astronautObject;
    public GameObject astronaut;
    public Text oxygenText;
    //Blackboard otherBlackboard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //otherBlackboard = astronautObject.value.GetComponent<Blackboard>();
    }

    // Update is called once per frame
    void Update()
    {
        //float n = otherBlackboard.GetVariableValue<float>("Oxygen");
        //oxygenText.text = ("Oxygen: " + n);
        
    }
}
