using Microsoft.EntityFrameworkCore;
using TRPBin.db;
using TRPBin.Models;

namespace TRPBin.Services
{
    public interface ITRPProfileService
    {
        Task<TRPProfile> CreateProfileAsync(string trpExport);
        Task<List<TRPProfile>> FetchProfilesAsync();
    }

    public class TRPProfileService : ITRPProfileService
    {
        private readonly ITRPSerializer _trpSerializer;
        private readonly ApplicationContext _context;

        public TRPProfileService(
            ITRPSerializer tRPSerializer,
            ApplicationContext context
        )
        {
            _trpSerializer = tRPSerializer;
            _context = context;
        }

        public async Task<TRPProfile> CreateProfileAsync(string trpExport)
        {
            _context.Add(new RawTRPData
            {
                ExportString = trpExport
            });

            await _context.SaveChangesAsync();

            var result = _trpSerializer.Deserialize(trpExport).FirstOrDefault();

            if (result == null)
            {
                throw new Exception("Deserialization failed");
            }

            return result;
        }

        public async Task<List<TRPProfile>> FetchProfilesAsync()
        {
            var rawData = await _context.TRPData
                .Select(d => d.ExportString)
                .ToArrayAsync();
            var deserialized = _trpSerializer.Deserialize(rawData);

            return deserialized;
        }
    }
}