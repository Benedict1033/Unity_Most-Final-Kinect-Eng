using UnityEngine;
using System.Collections.Generic;
using Joint = Windows.Kinect.Joint;
using Windows.Kinect;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BodySourceViewHard09 : MonoBehaviour
{
    public BodySourceManager bodySourceManager;
    public GameObject JointObject;
    private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();

    //public bool i = true;

    public GameObject[] obj;
    public Text win;

    public Together_Hard_Son together_Hard_Son;
    public Together_Hard_Mom together_Hard_Mom;




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
    public bool yes9999;
    public bool yes99999;

    public GameObject[] btn;

    public Text[] textt;


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
        yes999 = false;
        yes9999 = false;
        yes99999 = false;
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
            if (yes8 == false && yes4 == false && GameObject.Find("HandRight").transform.position.y <= 1.48 && GameObject.Find("HandRight").transform.position.y >= -0.399)
            {

                if (GameObject.Find("HandRight").transform.position.x >= -6.733 && GameObject.Find("HandRight").transform.position.x <= -5.645)
                {
                    together_Hard_Son.clickW();
                }
                else if (GameObject.Find("HandRight").transform.position.x >= -3.57 && GameObject.Find("HandRight").transform.position.x <= -2.35)
                {

                    together_Hard_Son.clickF();

                }
            }

            if (yes4 == false && Together_Hard_Son.count && Together_Hard_Son.count1 && GameObject.Find("HandRight").transform.position.y <= -0.91 && GameObject.Find("HandRight").transform.position.y >= -2.2)
            {

                if (GameObject.Find("HandRight").transform.position.x >= -5.46 && GameObject.Find("HandRight").transform.position.x <= -3.05)
                {
                    obj[0].SetActive(true);
                    obj[1].SetActive(true);
                }
            }

            if (yes8 == false && yes4 == false && Together_Hard_Son.count && Together_Hard_Son.count1 && GameObject.Find("HandRight").transform.position.y <= 1.48 && GameObject.Find("HandRight").transform.position.y >= -0.399)
            {

                if (GameObject.Find("HandRight").transform.position.x >= 1.32 && GameObject.Find("HandRight").transform.position.x <= 2.76)
                {
                    together_Hard_Mom.clickW();
                }
                else if (GameObject.Find("HandRight").transform.position.x >= 4.82 && GameObject.Find("HandRight").transform.position.x <= 6.03)
                {

                    together_Hard_Mom.clickF();

                }
            }

            if (yes8 == false && yes4 == false && Together_Hard_Mom.count && Together_Hard_Mom.count1 && GameObject.Find("HandRight").transform.position.y <= -0.91 && GameObject.Find("HandRight").transform.position.y >= -2.2)
            {

                if (GameObject.Find("HandRight").transform.position.x >= 2.75 && GameObject.Find("HandRight").transform.position.x <= 5.25)
                {
                    obj[2].SetActive(true);
                    Invoke("close", 1);
                    yes4 = true;
                }
            }


            if (yes8 == false && yes4 && GameObject.Find("HandRight").transform.position.y <= -1.29 && GameObject.Find("HandRight").transform.position.y >= -2.33)
            {

                if (GameObject.Find("HandRight").transform.position.x >= 0.91 && GameObject.Find("HandRight").transform.position.x <= 2.13)
                {
                    obj[6].SetActive(true);
                    obj[9].SetActive(false);
                    yes = true;
                }
                else if (GameObject.Find("HandRight").transform.position.x >= 3.78 && GameObject.Find("HandRight").transform.position.x <= 4.72)
                {

                    obj[7].SetActive(true);
                    obj[10].SetActive(false);
                    yes1 = true;


                }
                else if (GameObject.Find("HandRight").transform.position.x >= 6.17 && GameObject.Find("HandRight").transform.position.x <= 7.23)
                {

                    obj[8].SetActive(true);
                    obj[11].SetActive(false);
                    yes2 = true;


                }

                if (yes && yes1 && yes2)
                {
                    obj[12].SetActive(true);

                    yes8 = true;

                }




            }

            if (yes8 && GameObject.Find("HandRight").transform.position.y <= 0.38 && GameObject.Find("HandRight").transform.position.y >= -1.23)
            {


                if (GameObject.Find("HandRight").transform.position.x >= -7.55 && GameObject.Find("HandRight").transform.position.x <= -6.17)
                {
                    yes5 = true;
                    obj[13].SetActive(true);
                }
                else if (GameObject.Find("HandRight").transform.position.x >= -4.86 && GameObject.Find("HandRight").transform.position.x <= -3.46)
                {
                    yes6 = true;
                    obj[14].SetActive(true);


                }
                else if (GameObject.Find("HandRight").transform.position.x >= -2.31 && GameObject.Find("HandRight").transform.position.x <= -0.77)
                {
                    yes7 = true;
                    obj[15].SetActive(true);


                }

                if (yes5 && yes6 && yes7)
                {

                    yes9 = true;
                    obj[16].SetActive(true);
                    obj[17].SetActive(false);

                }

            }

            if (yes9 && GameObject.Find("HandRight").transform.position.y <= 0.44 && GameObject.Find("HandRight").transform.position.y >= -1.17)
            {


                if (GameObject.Find("HandRight").transform.position.x >= -7.78 && GameObject.Find("HandRight").transform.position.x <= -6.26)
                {
                    obj[18].SetActive(true);
                    obj[21].SetActive(false);
                    yes99 = true;
                }
                else if (GameObject.Find("HandRight").transform.position.x >= -5.19 && GameObject.Find("HandRight").transform.position.x <= -3.83)
                {
                    obj[19].SetActive(true);
                    obj[22].SetActive(false);
                    yes999 = true;


                }
                else if (GameObject.Find("HandRight").transform.position.x >= -2.63 && GameObject.Find("HandRight").transform.position.x <= -1.2)
                {
                    obj[20].SetActive(true);
                    obj[23].SetActive(false);
                    yes9999 = true;


                }

                if (yes99 && yes999 && yes9999)
                {
                    obj[24].SetActive(false);
                    obj[25].SetActive(true);
                    yes99999 = true;
                }
            }


            if (yes99999 && GameObject.Find("HandRight").transform.position.y <= 0.38 && GameObject.Find("HandRight").transform.position.y >= -1.04)
            {


                if (GameObject.Find("HandRight").transform.position.x >= -5.55 && GameObject.Find("HandRight").transform.position.x <= -1.42)
                {
                    print(1);
                    Invoke("wait", 5);
                }
                else if (GameObject.Find("HandRight").transform.position.x >= -5.55 && GameObject.Find("HandRight").transform.position.x <= -1.42)
                {
                    print(2);
                    Invoke("wait", 5);

                }
            }


        }
        catch { }

    }


    void close()
    {
        textt[0].text = "Parents please click to add the filling";
        textt[1].text = "Kid please click 3 mooncake to coloring";
        obj[3].SetActive(true);
        obj[4].SetActive(false);
        obj[5].SetActive(false);


    }

    void wait()
    {
        SceneManager.LoadScene("5.Easy");
    }

}

