using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TRPBin.Models
{
    public class TRPProfile
    {
        [JsonPropertyName("profileName")]
        public string? ProfileName { get; set; }
        [JsonPropertyName("player")]
        public TRPPlayer? Player { get; set; }
    }

    public class TRPPlayer
    {
        [JsonPropertyName("about")]
        public TRPPlayerAbout? About { get; set; }
        [JsonPropertyName("misc")]
        public TRPPlayerMisc? Misc { get; set; }
        [JsonPropertyName("character")]
        public TRPPlayerCharacter? Character { get; set; }
        [JsonPropertyName("characteristics")]
        public TRPPlayerCharacteristics? Characteristics { get; set; }
    }

    public class TRPPlayerMisc
    {
        [JsonPropertyName("v")]
        public int? Version { get; set; }
        [JsonPropertyName("ST")]
        public TRPPlayerMiscST? ST { get; set; }
        [JsonPropertyName("PE")]
        public TRPPlayerMiscPE? PE { get; set; }
    }

    public class TRPPlayerMiscPE
    {
        [JsonPropertyName("1")]
        public TRPPlayerAtAGlance? First { get; set; }
        [JsonPropertyName("2")]
        public TRPPlayerAtAGlance? Second { get; set; }
        [JsonPropertyName("3")]
        public TRPPlayerAtAGlance? Third { get; set; }
        [JsonPropertyName("4")]
        public TRPPlayerAtAGlance? Fourth { get; set; }
        [JsonPropertyName("5")]
        public TRPPlayerAtAGlance? Fifth { get; set; }

        private IEnumerable<TRPPlayerAtAGlance?> _glances => new List<TRPPlayerAtAGlance?>
        {
            First, Second, Third, Fourth, Fifth
        };

        [JsonIgnore]
        public IEnumerable<TRPPlayerAtAGlance?> Glances => _glances.Where(g => g != null);
    }

    public class TRPPlayerAtAGlance
    {
        [JsonPropertyName("TX")]
        public string? GlanceText { get; set; }
        [JsonPropertyName("TI")]
        public string? GlanceTitle { get; set; }
        [JsonPropertyName("IC")]
        public string? GlanceIcon { get; set; }
        [JsonPropertyName("AC")]
        public bool? GlanceActive { get; set; }
    }

    public class TRPPlayerMiscST
    {
        [JsonPropertyName("1")]
        public int? One { get; set;}
        [JsonPropertyName("2")]
        public int? Two { get; set;}
        [JsonPropertyName("3")]
        public int? Three { get; set;}
        [JsonPropertyName("4")]
        public int? Four { get; set;}
        [JsonPropertyName("5")]
        public int? Five { get; set;}
        [JsonPropertyName("6")]
        public int? Six { get; set;}
    }

    public class TRPPlayerAbout
    {
        [JsonPropertyName("v")]
        public int? Version { get; set; }
        [JsonPropertyName("TE")]
        public int? ActiveTemplate { get; set; }
        [JsonPropertyName("T1")]
        public JsonElement? Template1 { get; set; }
        [JsonPropertyName("T2")]
        public IEnumerable<TRPPlayerAboutTemplateSection>? Template2 { get; set; }
        [JsonPropertyName("T3")]
        public TRPPlayerAboutTemplate3? Template3 { get; set; }
        [JsonPropertyName("BK")]
        public int? Background { get; set; }

        [JsonIgnore]
        public string? Template1Text { 
            get
            {
                if (Template1?.TryGetProperty("TX", out JsonElement value) ?? false)
                {
                    return value.ToString();
                }

                return null;
            }
        }
    }

    public class TRPPlayerAboutTemplate1
    {
        [JsonPropertyName("TX")]
        public string? Text { get; set; }
    }

    public class TRPPlayerAboutTemplate3
    {
        [JsonPropertyName("PH")]
        public TRPPlayerAboutTemplateSection? PhysicalDescription { get; set; }
        [JsonPropertyName("HI")]
        public TRPPlayerAboutTemplateSection? History { get; set; }
        [JsonPropertyName("PS")]
        public TRPPlayerAboutTemplateSection? Personality { get; set; }
    }

    public class TRPPlayerAboutTemplateSection
    {
        [JsonPropertyName("BK")]
        public int? Background { get; set; }
        [JsonPropertyName("TX")]
        public string? Text { get; set; }
        [JsonPropertyName("IC")]
        public string? Icon { get; set; }
    }

    public class TRPPlayerCharacter
    {
        [JsonPropertyName("RP")]
        public int? RP { get; set; }
        [JsonPropertyName("v")]
        public int? Version { get; set; }
        [JsonPropertyName("CO")]
        public string? OOCInfo { get; set; }
        [JsonPropertyName("LC")]
        public string? Locale { get; set; }
        [JsonPropertyName("XP")]
        public RPExperienceLevel ExperienceLevel { get; set; }
        [JsonPropertyName("CU")]
        public string? Currently { get; set; }
    }

    public class TRPPlayerCharacteristics
    {
        [JsonPropertyName("v")]
        public int? Version { get; set; }
        [JsonPropertyName("CH")]
        public string? ClassColor { get; set; }
        [JsonPropertyName("HE")]
        public string? Height { get; set; }
        [JsonPropertyName("MI")]
        public IEnumerable<TRPPlayerCharacteristicsAdditionalInfo> AdditionalInfo { get; set; }
            = new List<TRPPlayerCharacteristicsAdditionalInfo>();
        [JsonPropertyName("RA")]
        public string? Race { get; set; }
        [JsonPropertyName("EC")]
        public string? EyeColor { get; set; }
        [JsonPropertyName("CL")]
        public string? Class { get; set; }
        [JsonPropertyName("BP")]
        public string? BirthPlace { get; set; }
        [JsonPropertyName("FT")]
        public string? Title { get; set; }
        [JsonPropertyName("AG")]
        public string? Age { get; set; }
        [JsonPropertyName("IC")]
        public string? Icon { get; set; }
        [JsonPropertyName("FN")]
        public string? FirstName { get; set; }

    }

    public class TRPPlayerCharacteristicsAdditionalInfo
    {
        [JsonPropertyName("NA")]
        public string? EntryTitle { get; set; }
        [JsonPropertyName("VA")]
        public string? EntryValue { get; set; }
        [JsonPropertyName("IC")]
        public string? EntryIcon { get; set; }
    }

    public enum RPExperienceLevel
    {
        Rookie,
        Experienced,
        Volunteer
    }
}
