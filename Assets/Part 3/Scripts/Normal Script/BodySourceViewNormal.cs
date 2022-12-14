using UnityEngine;
using System.Collections.Generic;
using Joint = Windows.Kinect.Joint;
using Windows.Kinect;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BodySourceViewNormal : MonoBehaviour
{
    public BodySourceManager bodySourceManager;
    public GameObject JointObject;
    private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();

    public int  i = 0;
    public int  j = 0;

    public GameObject[] obj;
    public Text win;


    private void Start()
    {
        i = 0;
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
        InvokeRepeating("handMouse", 1,0.7f);
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
        if (i !=1||j!=1)
        {
            try
            {
                if (GameObject.Find("HandRight").transform.position.y <= -0.89 && GameObject.Find("HandRight").transform.position.y >= -2.29)
                {

                    if (GameObject.Find("HandRight").transform.position.x >= -2.45 && GameObject.Find("HandRight").transform.position.x <= -1.41)
                    {
                        i = 1;
                        obj[0].SetActive(true);
                        win.text = "You're great";
                        //Invoke("wait", 2);
                    }
                    else if (GameObject.Find("HandRight").transform.position.x >= 0.19 && GameObject.Find("HandRight").transform.position.x <= 1.3)
                    {
                        obj[1].SetActive(true);
                        win.text = "Try Again";
                        Invoke("close", 0.5f);
                    }
                    else if (GameObject.Find("HandRight").transform.position.x >= 2.77 && GameObject.Find("HandRight").transform.position.x <= 4.04)
                    {
                        j = 1;
                        obj[2].SetActive(true);
                        win.text = "Try Again";
                        //Invoke("wait", 2);
                    }
                    else if (GameObject.Find("HandRight").transform.position.x >= 5.66 && GameObject.Find("HandRight").transform.position.x <= 6.55)
                    {
                        obj[3].SetActive(true);
                        win.text = "Try Again";
                        Invoke("close", 0.5f);
                    }

                }
            }
            catch { }
        }
        else if(i == 1 && j == 1){ 

            Invoke("wait", 2);
        }
    }


    void close()
    {
        obj[1].SetActive(false);
        obj[3].SetActive(false);
        win.text = "Try Again";
    }

    void wait()
    {
        SceneManager.LoadScene("3.Puzzle");
    }

}

