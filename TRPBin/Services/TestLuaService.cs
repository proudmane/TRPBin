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
            var result = script.DoFile("Scripts/test.lua");
            Console.WriteLine($"Result: {result.String}");
        }
    }
}