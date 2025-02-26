using UnityEngine;

namespace Save
{
    public class FilePathBuilder : MonoBehaviour
    {
        public string GetPath() => Application.dataPath + "/save.txt";
    }
}

