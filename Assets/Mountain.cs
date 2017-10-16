using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    [Serializable]
    public class Mountain
    {
        public Vector3 position { get { return new Vector3(X, Y, Z); } }
        public string id;
        public string createdAt;
        public string updatedAt;
        public string version;
        public string MountainId;
        public string MountainName;
        public float X;
        public float Y;
        public float Z;
        public float Size;
        public string Symbol;
        public bool deleted;
    }
}
