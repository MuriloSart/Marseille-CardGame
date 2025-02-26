using UnityEngine;

namespace Save
{
    public class SaveManager : Singleton<SaveManager>
    {
        public FileHandler fileHandler;
        private SaveSetup setup;

        private void Start()
        {
            DontDestroyOnLoad(this);
            setup = new SaveSetup();
        }

        public void Save(int sceneIndex)
        {
            setup.lastLevel = sceneIndex;

            string setupToJson = JsonUtility.ToJson(setup, true);

            fileHandler.Write(setupToJson);

            Debug.Log("Salvando o �ndice da cena: " + sceneIndex);
        }
    }
}

