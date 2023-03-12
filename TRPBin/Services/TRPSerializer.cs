using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using TRPBin.Models;

namespace TRPBin.Services
{
    public interface ITRPSerializer
    {
        TRPProfile Deserialize(string trpExport);
        string Serialize(TRPProfile profile);
    }

    public class TRPSerializer : ITRPSerializer
    {
        private readonly ILuaFactory _luaFactory;

        public TRPSerializer(
            ILuaFactory luaFactory
        )
        {
            _luaFactory = luaFactory;
        }

        public TRPProfile Deserialize(string trpExport)
        {
            using (var lua = _luaFactory.BuildLua())
            {
                lua["TRPExport"] = trpExport.Replace("\"", "\\\"");;
                var result = lua.DoString(@"
                    return TRPExportToJSON(TRPExport)
                ");

                var jobject = JsonObject.Parse((string)result[0]);
                var trpProfile = JsonSerializer.Deserialize<TRPProfile>(jobject?[2]);

                return trpProfile ?? throw new Exception(
                    "TRP Profile is null"
                );
            }
        }

        public string Serialize(TRPProfile profile)
        {
            throw new NotImplementedException();
        }
    }
}