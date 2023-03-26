using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLua;

namespace TRPBin.Services
{
    public interface ILuaFactory
    {
        Lua BuildLua();
    }

    public class LuaFactory : ILuaFactory
    {
        public Lua BuildLua()
        {
            var lua = new Lua();

            lua.DoFile("./Scripts/LibStub.lua");
            lua.DoFile("./Scripts/AceSerializer-3.0.lua");
            lua.DoFile("./Scripts/LibJSON-1.0.lua");
            lua.DoFile("./Scripts/Init.lua");

            return lua;
        }
    }
}