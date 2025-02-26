using UnityEngine;
using System.IO;

namespace Save
{
    public class FileBuilder : MonoBehaviour
    {

        public FilePathBuilder pathBuilder;

        public void CreateFile(string setup)
        {
            string setupToJson = JsonUtility.ToJson(setup, true);

            File.WriteAllText(pathBuilder.GetPath(), setupToJson);
        }
    }
}

