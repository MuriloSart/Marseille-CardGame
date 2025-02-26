using UnityEngine;

namespace Save
{
    public class FilePathBuilder
    {
        public string GetPath() => Application.dataPath + "/save.txt";
    }
}

