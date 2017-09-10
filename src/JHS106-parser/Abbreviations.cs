using System;
using System.Collections.Generic;

namespace JHS106.Parser
{
    internal static class Abbreviations
    {
        internal static Dictionary<string, string> StreetNameAbreviations = new Dictionary<String, String>()
            {
                { "L\u00E4ntinen","L\u00E4nt."},
                { "Pohjoinen", "Pohj."},
                { "aukio", "auk."},
                { "bostad", "bst."},
                { "kaari", "kri"},
                { "puistikko", "pko."},
                { "strand", "str."},
                { "penger", "pgr."},
                { "kerros", "krs"},
                { "skv\u00E4r", "skv."}      ,
                //{  "skv\u00E4ret", "skv."}      ,
                { "v\u00E5ning", "v\u00E5n."}      ,
                { "gr\u00E4nd", "gr."}      ,
                //{ "gr\u00E4nden", "gr."}      ,
                { "alue", "al."}       ,
                { "asunto", "as."}       ,
                { "bygata", "bg."}       ,
                //{ "bygatan", "bg."}    ,
                { "brinken", "br."}      ,
                { "Etel\u00E4inen", "Et."}      ,
                { "torg", "tg"}      ,
                //{ "torget", "tg"}    ,
                { "taival", "tvl"}      ,
                { "v\u00E4yl\u00E4", "vl\u00E4"}      ,
                { "kuja", "kj."}      ,
                { "kyl\u00E4", "kl."}      ,
                { "puisto", "ps."}      ,
                { "stig", "st."}      ,
                //{ "stigen", "st."}    ,
                { "park", "pk."}      ,
                //{ "parken", "pk."}    ,
                { "str\u00E5k", "sk."}      ,
                //{ "str\u00E5ket", "sk."}    ,
                { "It\u00E4inen", "It."}      ,
                { "ranta", "rt."}      ,
                { "rinne", "rn."}      ,
                { "tori", "tr."}      ,
                { "raitti", "r."}      ,
                { "tie", "t."}      ,
                { "led", "l."}      ,
                //{ "leden", "l."}    ,
                { "katu", "k."}      ,
                { "polku", "p."}      ,
                { "gata", "g."}      ,
                //{ "gatan", "g."}    ,
                { "Norra", "N."}      ,
                { "S\u00F6dra", "S."}      ,
                { "v\u00E4g", "v."}      ,
                //{ "v\u00E4gen", "v."}    ,
                { "V\u00E4stra", "V."}      ,
                { "\u00D6stra", "\u00D6."}
            };
    }
}