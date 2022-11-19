using UnityEngine;
using System.Collections.Generic;
using Joint = Windows.Kinect.Joint;
using Windows.Kinect;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BodySourceViewNormal09 : MonoBehaviour
{
    public BodySourceManager bodySourceManager;
    public GameObject JointObject;
    private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();

    //public bool i = true;

    public GameObject[] obj;
    public Text win;

    public Together_Easy Together_Easy;



    public bool yes;
    public bool yes1;
    public bool yes2;
    public bool yes3;
    public bool yes4;
    public bool yes5;
    public bool yes6;
    public bool yes7;
    public bool yes8;
    public bool yes9;
    public bool yes99;
    public bool yes999;

    public GameObject[] btn;


    private void Start()
    {
        yes = false;
        yes1 = false;
        yes2 = false;
        yes3 = false;
        yes4 = false;
        yes5 = false;
        yes6 = false;
        yes7 = false;
        yes8 = false;
        yes9 = false;
        yes99 = false;
        yes999 = false;
    }

    private List<JointType> joints = new List<JointType> {
    JointType.HandLeft,
    JointType.HandRight,
    };

    private void Update()
    {


        Body[] data = bodySourceManager.GetData();
        if (data == null)
            return;

        List<ulong> trackedIds = new List<ulong>();

        foreach (var body in data)
        {
            if (body == null)
                continue;

            if (body.IsTracked)
            {
                trackedIds.Add(body.TrackingId);
            }
        }

        List<ulong> knownIds = new List<ulong>(mBodies.Keys);

        foreach (ulong trackingId in knownIds)
        {
            if (!trackedIds.Contains(trackingId))
            {
                Destroy(mBodies[trackingId]);
                mBodies.Remove(trackingId);
            }
        }

        foreach (var body in data)
        {
            if (body == null)
                continue;

            if (body.IsTracked)
            {
                if (!mBodies.ContainsKey(body.TrackingId))
                {
                    mBodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                }

                UpdateBodyObject(body, mBodies[body.TrackingId]);
            }
        }
    }

    private GameObject CreateBodyObject(ulong id)
    {
        InvokeRepeating("handMouse", 1, 0.2f);
        GameObject body = new GameObject("Body:" + id);
        body.transform.localScale = new Vector3(1, 1f, 1);
        body.transform.localPosition = new Vector3(0, 0, 0);

        foreach (JointType joint in joints)
        {
            GameObject newJoint = Instantiate(JointObject);
            newJoint.name = joint.ToString();
            newJoint.transform.parent = body.transform;
        }

        if (body.transform.GetChild(0).gameObject.name == "HandLeft") { body.transform.GetChild(0).gameObject.SetActive(false); }
        if (body.transform.GetChild(1).gameObject.name == "HandLeft") { body.transform.GetChild(1).gameObject.SetActive(false); }

        return body;
    }

    private void UpdateBodyObject(Body body, GameObject bodyObject)
    {
        foreach (JointType joint in joints)
        {
            Joint sourceJoint = body.Joints[joint];
            Vector3 targetPosition = GetVector3FromJoint(sourceJoint);

            Transform jointObject = bodyObject.transform.Find(joint.ToString());
            jointObject.position = targetPosition;
        }
    }

    private Vector3 GetVector3FromJoint(Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, 0);
    }

    void handMouse()
    {

        try
        {
            if (GameObject.Find("HandRight").transform.position.y <= 2.16 && GameObject.Find("HandRight").transform.position.y >= 1.64)
            {

                if (GameObject.Find("HandRight").transform.position.x >= -6.81 && GameObject.Find("HandRight").transform.position.x <= -6.02)
                {

                    obj[0].SetActive(true);
                    obj[9].SetActive(false);
                    yes = true;
                }
                if (GameObject.Find("HandRight").transform.position.x >= -5.2 && GameObject.Find("HandRight").transform.position.x <= -4.87)
                {
                    obj[1].SetActive(true);
                    obj[10].SetActive(false);
                    yes1 = true;



                }
                if (GameObject.Find("HandRight").transform.position.x >= -4.18 && GameObject.Find("HandRight").transform.position.x <= -3.83)
                {
                    obj[2].SetActive(true);
                    obj[11].SetActive(false);
                    yes2 = true;



                }
                if (GameObject.Find("HandRight").transform.position.x >= -3 && GameObject.Find("HandRight").transform.position.x <= -2.76)
                {
                    obj[3].SetActive(true);
                    obj[12].SetActive(false);
                    yes3 = true;




                }
                if (GameObject.Find("HandRight").transform.position.x >= -2 && GameObject.Find("HandRight").transform.position.x <= 1.37)
                {
                    obj[4].SetActive(true);
                    obj[13].SetActive(false);
                    yes4 = true;



                }



            }
            else if (GameObject.Find("HandRight").transform.position.y <= 0.74 && GameObject.Find("HandRight").transform.position.y >= 0.45)
            {

                if (GameObject.Find("HandRight").transform.position.x >= -6.81 && GameObject.Find("HandRight").transform.position.x <= -6.02)
                {
                    obj[5].SetActive(true);
                    obj[14].SetActive(false);


                    yes5 = true;

                }

                if (GameObject.Find("HandRight").transform.position.x >= -2 && GameObject.Find("HandRight").transform.position.x <= 1.37)
                {
                    obj[6].SetActive(true);
                    obj[15].SetActive(false);

                    yes6 = true;

                }
            }
            else if (GameObject.Find("HandRight").transform.position.y <= -0.39 && GameObject.Find("HandRight").transform.position.y >= -0.94)
            {
                if (GameObject.Find("HandRight").transform.position.x >= -6.81 && GameObject.Find("HandRight").transform.position.x <= -6.02)
                {
                    obj[7].SetActive(true);
                    obj[16].SetActive(false);

                    yes7 = true;


                }

                if (GameObject.Find("HandRight").transform.position.x >= -2 && GameObject.Find("HandRight").transform.position.x <= 1.37)
                {
                    obj[8].SetActive(true);
                    obj[17].SetActive(false);

                    yes8 = true;

                }

            }

            if (yes && yes1 && yes2 && yes3 && yes4 && yes5 && yes6 && yes7 && yes8&&yes9==false)
            {
                btn[0].SetActive(true);
                btn[1].SetActive(true);

                if (GameObject.Find("HandRight").transform.position.y <= -1.05 && GameObject.Find("HandRight").transform.position.y >= -2.52)
                {

                    if (GameObject.Find("HandRight").transform.position.x >= 0.78 && GameObject.Find("HandRight").transform.position.x <= 1.7)
                    {

                        btn[2].SetActive(false);

                        Invoke("close", 1);
                    }
                }
            }


            if (yes9&&GameObject.Find("HandRight").transform.position.y <= 1 && GameObject.Find("HandRight").transform.position.y >= -1.5)
            {
                print(123);

                if (GameObject.Find("HandRight").transform.position.x >= -5.32 && GameObject.Find("HandRight").transform.position.x <= -3.11)
                {
                    print(4556);

                    btn[5].SetActive(true);
                    btn[6].SetActive(true);

                    yes99 = true;
                }
            }

            if (yes99 && GameObject.Find("HandRight").transform.position.y <= 1 && GameObject.Find("HandRight").transform.position.y >= -1.5)
            {
                print(12442);
                if (GameObject.Find("HandRight").transform.position.x >= 2.59 && GameObject.Find("HandRight").transform.position.x <= 5.8)
                {
                    print(1552312);
                    btn[7].SetActive(true);
                    btn[8].SetActive(true);
                    btn[9].SetActive(false);
                    yes999 = true;


                }
            }

            if (yes999 && GameObject.Find("HandRight").transform.position.y <= 1.12 && GameObject.Find("HandRight").transform.position.y >= -0.21)
            {

                if (GameObject.Find("HandRight").transform.position.x >= -5.18 && GameObject.Find("HandRight").transform.position.x <= -1.69)
                {

                    print(1);

                    Invoke("wait", 2);
                }
                else if (GameObject.Find("HandRight").transform.position.x >= -0.23 && GameObject.Find("HandRight").transform.position.x <= 3.32)

                {

                    print(2);
                    Invoke("wait", 2);

                }
            }
            else if (yes999 && GameObject.Find("HandRight").transform.position.y <= -1.01&& GameObject.Find("HandRight").transform.position.y >= -2.34)
            {
                if (GameObject.Find("HandRight").transform.position.x >= -5.18 && GameObject.Find("HandRight").transform.position.x <= -1.69)
                {

                    print(3);
                    Invoke("wait", 2);


                }
                else if (GameObject.Find("HandRight").transform.position.x >= -0.23 && GameObject.Find("HandRight").transform.position.x <= 3.32)

                {

                    print(4);
                    Invoke("wait", 2);

                }
            }

            }
        catch { }

    }


    void close()
    {
        btn[3].SetActive(true);
        btn[4].SetActive(false);
        yes9 = true;
    }

    void wait()
    {
        SceneManager.LoadScene("4.Puzzle");
    }

}

