using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarController : MonoBehaviour
{

	Image image;
	GameObject Player;
	Balloon balloon;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
		Player = transform.parent.parent.gameObject.GetComponent<OwnerIdentifier>().Owner;
		balloon = Player.GetComponent<Balloon>();
    }

    // Update is called once per frame
    void Update()
    {
		
        image.fillAmount = balloon.volume/balloon.maxVolume;
		Debug.Log(image.fillAmount);
    }
}
