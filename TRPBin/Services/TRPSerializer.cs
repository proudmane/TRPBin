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
        List<TRPProfile> Deserialize(params string[] parameters);
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

        public List<TRPProfile> Deserialize(params string[] parameters)
        {
            var profiles = new List<TRPProfile>();
            using (var lua = _luaFactory.BuildLua())
            {
                foreach (var trpExport in parameters)
                {
                    lua["TRPExport"] = trpExport.Replace("\"", "\\\"");;
                    var result = lua.DoString(@"
                        return TRPExportToJSON(TRPExport)
                    ");

                    var jobject = JsonObject.Parse((string)result[0]);
                    var trpProfile = JsonSerializer.Deserialize<TRPProfile>(jobject?[2]);

                    if (trpProfile != null)
                    {
                        profiles.Add(trpProfile);
                    }
                }
            }

            return profiles;
        }

        public string Serialize(TRPProfile profile)
        {
            throw new NotImplementedException();
        }
    }
}