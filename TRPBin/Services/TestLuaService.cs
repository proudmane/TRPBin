using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;

namespace TRPBin.Services
{
    public class TestLuaService
    {
        public void TestMoonSharp()
        {
            var script = new Script();
            script.Options.ScriptLoader = new EmbeddedResourcesScriptLoader(Assembly.GetCallingAssembly());

            script.DoFile("Scripts/LibStub.lua");
            script.DoFile("Scripts/AceSerializer-3.0.lua");
            script.DoFile("Scripts/Init.lua");
            var result = script.DoString("for n in pairs(_G) do print(n) end");
            var test = script.Globals["LibStub"] as Table;
            var test2 = test["GetLibrary"];

            var result2 = script.Call(test2);
            Console.WriteLine($"Result:");
        }
    }
}