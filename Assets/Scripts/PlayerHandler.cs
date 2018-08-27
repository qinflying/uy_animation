using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour {
    public GameObject m_PlayerLog;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collision) {
        if (collision.tag == "Log") {
            Destroy(collision.gameObject);
            CarryMood();
        }
    }

    void CarryMood() {
        m_PlayerLog.SetActive(true);
    }
}
