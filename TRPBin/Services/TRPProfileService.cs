using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRPBin.Models;

namespace TRPBin.Services
{
    public interface ITRPProfileService
    {
        TRPProfile CreateProfile(string trpExport);
    }

    public class TRPProfileService : ITRPProfileService
    {
        private readonly ITRPSerializer _trpSerializer;

        public TRPProfileService(
            ITRPSerializer tRPSerializer
        )
        {
            _trpSerializer = tRPSerializer;
        }

        public TRPProfile CreateProfile(string trpExport)
        {
            return _trpSerializer.Deserialize(trpExport);
        }

        
    }
}