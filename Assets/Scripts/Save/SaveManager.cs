using UnityEngine;

namespace Save
{
    public class SaveManager : Singleton<SaveManager>
    {
        private FileHandler fileHandler;
        private SaveSetup setup;

        private void Start()
        {
            fileHandler = new FileHandler();
            setup = new SaveSetup();
        }

        public void Save(int sceneIndex)
        {
            setup.lastLevel = sceneIndex;

            string setupToJson = JsonUtility.ToJson(setup, true);

            fileHandler.Write(setupToJson);

            Debug.Log("Salvando o índice da cena: " + sceneIndex);
        }
    }
}

