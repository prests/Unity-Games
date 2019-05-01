using UnityEngine;

public class WaterMoving : MonoBehaviour {

    //Unity Related
    public GameObject topWater;
    public GameObject bottomWater;
    public GameObject powerButton;
    public GameObject drainButton;
    public Material on;
    public Material off;
    public ParticleSystem topPipe;
    public ParticleSystem bottomPipe;

    //Technical Variables
    private bool powerButtonStatus = false;
    private bool drainButtonStatus = false;
    private bool isEmpty = true;
    public float flowInRateTop;
    public float flowOutRateTop;
    public float length;
    public float width;
    public float height;


	void Start () {
        topWater.SetActive(false);
        bottomWater.SetActive(false);
        topPipe.Stop();
        bottomPipe.Stop();
        powerButton.GetComponent<MeshRenderer>().material = off;
        drainButton.GetComponent<MeshRenderer>().material = off;
        topWater.transform.localScale = new Vector3(topWater.GetComponent<Renderer>().bounds.size.x, 0, topWater.GetComponent<Renderer>().bounds.size.z);
        bottomWater.transform.localScale = new Vector3(bottomWater.GetComponent<Renderer>().bounds.size.x, 0, bottomWater.GetComponent<Renderer>().bounds.size.z);
    }
	
	// Update is called once per frame
	void Update () {

        //Checks for clicking
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is down");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.name == "Power Button")
                {
                    Debug.Log("It's working!");
                    if (powerButtonStatus)
                    {
                        powerButton.GetComponent<MeshRenderer>().material = off;
                        powerButtonStatus = false;
                    }
                    else
                    {
                        powerButton.GetComponent<MeshRenderer>().material = on;
                        powerButtonStatus = true;
                    }
                }
                else
                {
                    Debug.Log("nopz");
                }

                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.name == "Drain Button")
                {
                    Debug.Log("It's working!");
                    if (drainButtonStatus)
                    {
                        drainButton.GetComponent<MeshRenderer>().material = off;
                        drainButtonStatus = false;
                    }
                    else
                    {
                        drainButton.GetComponent<MeshRenderer>().material = on;
                        drainButtonStatus = true;
                    }
                }
                else
                {
                    Debug.Log("nopz");
                }
            }
            else
            {
                Debug.Log("No hit");
            }
            Debug.Log("Mouse is down");
        }

        //Checks If Water In Tank
        if (topWater.GetComponent<Renderer>().bounds.size.y < flowOutRateTop)
        {
            topWater.SetActive(false);
            isEmpty = true;
        }

        //Checks Power Status
        if (powerButtonStatus)
        {
            isEmpty = false;
            topWater.SetActive(true);
            topWater.transform.localScale = new Vector3(topWater.GetComponent<Renderer>().bounds.size.x, topWater.GetComponent<Renderer>().bounds.size.y + flowInRateTop, topWater.GetComponent<Renderer>().bounds.size.z);
            topPipe.Play();
        }
        else
        {
            topPipe.Stop();
        }

        //Checks Drain Status
        if (drainButtonStatus && !isEmpty)
        {
            bottomWater.SetActive(true);
            bottomPipe.Play();
            topWater.transform.localScale = new Vector3(topWater.GetComponent<Renderer>().bounds.size.x, topWater.GetComponent<Renderer>().bounds.size.y - flowOutRateTop, topWater.GetComponent<Renderer>().bounds.size.z);
            bottomWater.transform.localScale = new Vector3(bottomWater.GetComponent<Renderer>().bounds.size.x, bottomWater.GetComponent<Renderer>().bounds.size.y + flowOutRateTop, bottomWater.GetComponent<Renderer>().bounds.size.z);
        }
        else
        {
            bottomPipe.Stop();
        }
    }
}
