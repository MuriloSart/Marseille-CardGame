using System.IO;
using UnityEngine;

namespace Save
{
    public class FileHandler
    {
        private FilePathBuilder pathBuilder;
        private SaveSetup setup;

        private void Awake()
        {
            pathBuilder = new FilePathBuilder();
            setup = new SaveSetup();
        }

        public void Write(string setupToJson) => File.WriteAllText(pathBuilder.GetPath(), setupToJson);

        public SaveSetup GetSetup()
        {
            if (!File.Exists(pathBuilder.GetPath()))
            {
                string setupToJson = JsonUtility.ToJson(setup, true);
                FileBuilder fileBuilder = new FileBuilder();
                fileBuilder.CreateFile(setupToJson);
            }

            string json = File.ReadAllText(pathBuilder.GetPath());
            setup = JsonUtility.FromJson<SaveSetup>(json);

            return setup;
        }
    }
}

