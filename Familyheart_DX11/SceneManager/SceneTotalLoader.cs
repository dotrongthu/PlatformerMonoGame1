using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace Familyheart_DX11.SceneManager
{
    public class SceneTotalLoader
    {
        public List<string> pathLists;
        public List<string> sceneName;

        public SceneTotalLoader(List<string> path, List<string> sceneNamez)
        {
            pathLists = path;
            sceneName = sceneNamez;
        }
    }
}
