
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

                var trpString = "^1^T^N1^N113^N2^S0311231949qhiOT^N3^T^Sinventory^T^Sinit^B^Sid^Smain^StotalWeight^N500^Scontent^T^S17^T^Sid^Sbag^StotalWeight^N500^Scontent^T^t^StotalValue^N0^t^t^StotalValue^N0^t^Snotes^T^t^Squestlog^T^t^Splayer^T^Scharacteristics^T^SLN^STest~`LN^SMI^T^N1^T^SIC^Sability_hunter_beastcall^SNA^SNickname^SVA^STes~`NN^t^t^SPS^T^N1^T^SID^N5^SVA^N3^SV2^N10^t^t^SRS^N3^SCL^STest~`Class^SHE^STest~`HE^SRA^STest~`Race^SRE^STest~`Residence^Sv^N2^SBP^STest~`BP^SAG^STest~`Age^STI^STest~`Title^SIC^Sability_racial_preturnaturalcalm^SFN^STest~`FN^SFT^STest~`FT^SEC^STest~`EC^SWE^STest~`Body~`Shape^t^Scharacter^T^SCO^STest~`OOC~J~JDeveloping~`something~`for~`TRP,~`dont~`mind~`the~`construction~`signs!^SRP^N1^Sv^N95^SXP^N2^SCU^STest~`IC^t^Smisc^T^SPE^T^S1^T^SAC^B^STI^SAAG~`1^SIC^Sinv_misc_questionmark^STX^STest~`text^t^S3^T^SAC^B^STI^SAAG~`3^SIC^Sinv_misc_questionmark^STX^STest~`text^t^S2^T^SAC^B^STI^SAAG~`2^SIC^Sinv_misc_questionmark^STX^STest~`text^t^S5^T^SAC^B^STI^STest~`AAG~`5^SIC^Sinv_misc_questionmark^STX^STest~`text^t^S4^T^SAC^B^STI^SAAG4^SIC^Sinv_misc_questionmark^STX^STest~`text^t^t^SST^T^S1^N1^S3^N1^S2^N2^S5^N2^S4^N1^S6^N1^t^Sv^N18^t^Sabout^T^ST2^T^N1^T^STX^STest~`template~`2~`1^SBK^N1^SIC^S70_inscription_deck_hellfire_2^t^N2^T^STX^STest~`template~`2~`2^SBK^N9^SIC^S70_inscription_deck_immortality_a^t^t^ST3^T^SPH^T^STX^STest~`template~`3~`1^SBK^N1^t^SPS^T^STX^STest~`template~`3~`2^SBK^N1^t^SHI^T^STX^STest~`template~`3~`3^SBK^N1^t^t^STE^N3^ST1^T^STX^S^t^SBK^N1^Sv^N6^t^t^SprofileName^STest^t^t^^";

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
                var teststr = (JsonElement?) trpProfile?.Player?.About?.Template1;

                var s = teststr.GetValueOrDefault();
                s.TryGetProperty("TX", out JsonElement value);
                Console.WriteLine("");
            }
            Console.WriteLine($"Result:");
        }
    }
}