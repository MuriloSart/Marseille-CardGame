using UnityEngine;
using System.IO;

namespace Save
{
    public class FileBuilder : MonoBehaviour
    {

        private FilePathBuilder pathBuilder;
        
        private void Start()
        {
            pathBuilder = new FilePathBuilder();
        }

        public void CreateFile(string setup)
        {
            string setupToJson = JsonUtility.ToJson(setup, true);

            File.WriteAllText(pathBuilder.GetPath(), setupToJson);
        }
    }
}

