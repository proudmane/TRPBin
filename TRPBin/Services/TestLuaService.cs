
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

                var trpString = "^1^T^N1^N112^N2^S0206211155aC7cA^N3^T^Splayer^T^Scharacteristics^T^SWE^SLithe,~`supple^SRA^SRen'dorei^SRE^SStormwind^SEC^SViolet^SBP^SQuel'thalas^SFN^SAnara^SPS^T^N1^T^SID^N1^SVA^N4^SV2^N14^t^N2^T^SID^N3^SVA^N5^SV2^N15^t^N3^T^SID^N4^SVA^N2^SV2^N7^t^N4^T^SID^N6^SVA^N5^SV2^N17^t^N5^T^SID^N10^SVA^N1^SV2^N2^t^N6^T^SID^N5^SVA^N2^SV2^N7^t^N7^T^SRT^SChaste^SV2^N20^SRI^Sspell_holy_powerwordshield^SVA^N6^SLI^Sspell_shadow_summonsuccubus^SLT^SLustful^t^t^SRS^N0^SIC^Sability_priest_heavanlyvoice^SMI^T^N1^T^SIC^Sinv_alliancewareffort^SNA^SNickname^SVA^S'Nara^t^N2^T^SIC^Sability_mage_iceform^SNA^SRelationship^SVA^SEngaged,~`Open!^t^t^SAG^S35^SCL^SSocialite^Sv^N32^SFT^SDancer~`||~`Entertainer~`||~`Hostess~`||~`Elivish~`Morena~`Baccarin^SHE^S5'2\"^SCH^Sff76b0^t^Scharacter^T^SCU^S^SCO^SPlease~`read~`disclaimers~`in~`About!~JCharacter~`has~`very~`mature~`themes~J21+~`RP~JDark/Fantasy/Long~JOpen~`to~`anything~J~JBeen~`awhile~`dudes^SRP^N1^SLC^SenUS^SXP^N3^Sv^N57^t^Sabout^T^ST2^T^t^ST3^T^SPH^T^SBK^N1^t^SPS^T^SBK^N1^t^SHI^T^SBK^N1^t^t^STE^N1^ST1^T^STX^S{p:c}{link*https://www.youtube.com/watch?v=plnAMYt2oqY*Hand~`Holding}{/p}~J~J(OOC~`Forewarning,~`Anara~`is~`a~`sexual~`character.~`I~`ERP~`and~`she~`makes~`references~`to~`it~`regularly.~`If~`you~`don't~`like~`it~`or~`you~`want~`to~`be~`shitty,~`do~`us~`both~`a~`favor~`and~`fuck~`off~`away~`from~`me,~`thanks~|!~`--~`This~`also~`isn't~`gonna~`be~`an~`F-List,~`if~`you~`want~`to~`know~`her~`walk~`up!)~J~J(Anara~`is~`also~`a~`little~`much~`as~`a~`character.~`Please~`understand~`that~`flirting~`and~`trying~`to~`initiate~`intimacy~`are~`core~`tennets~`of~`her~`character.~`It~`does~`not~`necessarily~`mean~`I~`am~`looking~`for~`it~`OOC.~`If~`you'd~`like~`her~`to~`be~`toned~`down,~`please~`just~`ask!)~J~J{h2:c}{icon:spell_shadow_soothingkiss:25}{col:ff00f1}~`Your~`Desire{/col}{/h2}~J~JAnara~`stood~`at~`a~`below~`average~`height~`for~`her~`race~`at~`a~`staggering~`5'1\".~`Almost~`as~`if~`she'd~`been~`malnourished~`as~`a~`child~`but~`recovered~`too~`late~`for~`her~`body~`to~`recover~`fully.~`~J~JDespite,~`she~`was~`an~`impressively~`carved~`figure.~`Her~`small~`waist,~`small~`hips~`and~`flawless~`bust~`filled~`out~`her~`small~`frame,~`making~`seem~`much~`more~`endowed~`than~`others~`of~`her~`kind~`that~`leer~`over~`the~`heads~`of~`the~`humans.~J~JHer~`skin~`flawless~`and~`a~`heavy~`tone~`to~`it,~`as~`if~`she'd~`spend~`hours~`a~`day~`tanning~`somehow.~`Her~`full~`lips~`usually~`dressed~`with~`a~`dark~`red~`lipstick~`(or~`are~`those~`wine~`stains?).~`Her~`voice~`sultry~`in~`the~`best~`of~`times.~`Every~`word~`uttered~`lined~`with~`vocal~`velvet.~J~J{h2:c}{icon:priest_spell_leapoffaith_a:25}{col:07aeff}~`Guardian~`Angel{/col}{/h2}~J~JAbove~`all~`Anara~`wishes~`for~`peace~`upon~`Azeroth.~`She~`is~`quite~`young~`for~`an~`elf,~`only~`about~`thirty~`years~`old.~`So~`she~`is~`hopeful~`and~`full~`of~`optimism~`both~`about~`the~`world~`and~`the~`people~`around~`her.~`She~`shies~`away~`from~`violence~`and~`turmoil,~`seeing~`them~`as~`wholly~`unnecessary~`evils.~`Even~`her~`enemies~`would~`find~`her~`unnervingly~`merciful.~J~J{h2:c}{icon:ability_racial_timeismoney:25}{col:3e2ff7}~`Time~`is~`Money~`{/col}{/h2}~J~JWhile~`above~`the~`barbarity~`of~`violence~`she~`was,~`however,~`not~`above~`the~`barbarity~`of~`greed.~`Greed~`burns~`within~`her,~`keeping~`her~`warm~`on~`cold~`and~`lonely~`nights.~`No~`matter~`her~`endeavor,~`one~`will~`find~`money~`and~`wealth~`at~`the~`core~`of~`her~`efforts.~`~J~JAdorning~`herself~`in~`the~`finest~`of~`cloth~`and~`the~`most~`luxurious~`of~`gems~`and~`jewelry,~`she~`was~`usually~`the~`most~`decorated~`woman~`in~`the~`room,~`the~`most~`flaunting~`of~`excess.~`Her~`enjoyment~`from~`the~`attention~`that~`brings~`was~`quite~`obvious.~J~J{h2:c}{icon:ability_hunter_catlikereflexes:25}~`{col:ffec00}Cat~`Got~`Your~`Tongue{/col}{/h2}~J~JA~`pretty~`face~`is~`met~`with~`quick~`wit.~`Anara~`studied~`and~`trained~`from~`an~`early~`age~`to~`provide~`entertainment~`and~`quality~`conversation~`to~`even~`the~`most~`wealthy~`of~`clients.~`Because~`of~`this,~`her~`skills~`are~`quite~`diverse.~`She~`has~`been~`known~`to~`sing~`in~`Thalassian,~`Darnassian~`and~`Common.~`Instruments~`include~`the~`harp,~`mandolin,~`most~`stringed~`instruments.~`~J~JShe~`is~`also~`a~`world-class~`chess~`player,~`a~`world-class~`chef~`and~`bartender,~`easily~`at~`home~`in~`the~`finest~`of~`restaurants~`Azeroth~`has~`to~`offer.~J~J~J^t^SBK^N6^Sv^N41^t^Smisc^T^SST^T^S1^N0^S3^N0^S2^N0^S5^N0^S4^N0^S6^N0^t^SPE^T^S1^T^SAC^B^STI^SVoid-Touched^STX^SThis~`elf~`was~`obviously~`touched~`by~`the~`void,~`though~`apparently~`less~`than~`her~`peers.~`Her~`hair~`gave~`slightly~`void-like~`glows~`and~`her~`eyes~`were~`slightly~`void-touched.~J~JThe~`rest~`of~`her~`body~`and~`face~`however~`remained~`normal^SIC^Sspell_shadow_summonvoidwalker^t^S3^T^SIC^Sspell_shadow_summonsuccubus^STI^SSultry~`and~`Sensual^STX^SIt~`would~`be~`fair~`to~`say~`that~`nearly~`every~`quality~`about~`the~`woman~`lent~`itself~`to~`a~`sensual~`and~`even~`sexual~`demeanor~`in~`everything~`from~`her~`body~`to~`her~`eyes~`and~`voice.^SAC^B^t^S2^T^SAC^B^STI^SBody~`Type~`and~`Appearance^STX^SAnara~`was~`in~`a~`word,~`flawless.~`Her~`skin~`was~`without~`blemish~`and~`held~`a~`fair~`amount~`of~`color~`when~`compared~`to~`others~`of~`her~`race.~J~JHer~`frame~`was~`slender~`like~`a~`porcelain~`pot.~`Her~`hips~`were~`wide~`and~`her~`waist~`small.^SIC^Sspell_shadow_manafeed^t^S5^T^SAC^B^STI^SServices~`Offered^SIC^Sability_priest_heavanlyvoice^STX^SAnara~`is~`a~`skilled~`entertainer~`and~`server.~`At~`home~`in~`Quel'thalas~`she~`was~`servant~`to~`a~`noble~`house.~J~JIn~`Stormwind~`she~`makes~`a~`living~`offering~`these~`skills~`she~`learned~`to~`wealthy~`patrons.~J~JThese~`skills~`include~`anything~`hospitality~`related.~J~JShe~`is~`a~`skilled~`singer,~`dancer,~`musician~`and~`conversationalist.~`She~`can~`play~`several~`instruments,~`serve~`drinks~`with~`the~`finest~`of~`manners~`and~`sing~`in~`three~`languages.~J~JIf~`you~`are~`interested~`in~`procuring~`her~`services,~`approach~`ICly~`or~`whisper~`me~`OOCly~`and~`we~`can~`work~`something~`out.^t^S4^T^SIC^Shunter_pvp_snipershot^STI^SSlight~`Limp^STX^SWhen~`she~`walks,~`she~`has~`an~`almost~`imperceptible~`limp~`on~`her~`right~`side.~J~JWhen~`standing~`still~`she~`tends~`to~`favor~`her~`left~`leg.^SAC^B^t^t^Sv^N22^t^t^Snotes^T^S0206211155aC7cA^Sasdf~`aesdfvvwerverv^t^SprofileName^SMoon~`Guard~`-~`Anaraa^t^t^^";
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