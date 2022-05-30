using Harmony;
using System.Reflection;

namespace OneDay
{
    public static class HarmonyInit
    {
        public static void Init()
        {
            var harmony = HarmonyInstance.Create("io.github.orgtigger.Oneday");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}