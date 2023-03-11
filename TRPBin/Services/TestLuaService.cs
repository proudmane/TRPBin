
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using NLua;
using TRPBin.Models;

namespace TRPBin.Services
{
    public class TestLuaService
    {
        // https://github.com/Total-RP/Total-RP-3/wiki/Mary-Sue-Protocol#-correctly-escaping-color-codes
        // https://github.com/Total-RP/Total-RP-3/wiki/Mary-Sue-Protocol#mary-sue-protocol-fields-and-implementations-in-total-rp-3
        public void TestMoonSharp()
        {
            using (var lua = new Lua())
            {
                lua.DoFile("./Scripts/LibStub.lua");
                lua.DoFile("./Scripts/AceSerializer-3.0.lua");
                lua.DoFile("./Scripts/LibJSON-1.0.lua");
                lua.DoFile("./Scripts/Init.lua");

                var trpString = "";

                trpString = trpString.Replace("\"", "\\\"");

                lua["TrpString"] = trpString;

                var res = lua.DoString(@"return AceSerializer:Serialize(""my string"")");
                var res2 = lua.DoString(@$"
                    local success, value = AceSerializer:Deserialize(TrpString)

                    if success then
                        print (table.tostring(value))
                        return LibJSON.Serialize(value)
                    end

                    return ''
                ");

                var jobject = JsonObject.Parse((string)res2[0]);
                var trpProfile = JsonSerializer.Deserialize<TRPProfile>(jobject?[2]);
                Console.WriteLine("");
            }
            Console.WriteLine($"Result:");
        }
    }
}