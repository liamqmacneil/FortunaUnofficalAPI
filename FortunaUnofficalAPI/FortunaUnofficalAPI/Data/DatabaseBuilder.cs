using FortunaUnofficialAPI;
using FortunaUnofficialAPI.Models.Containers;
using FortunaUnofficialAPI.Models.General;
using FortunaUnofficialAPI.Models.SAF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace FortunaUnofficalAPI.Data
{
    public class DatabaseBuilder
    {
        internal static FortunaDbContext db_ = new FortunaDbContext();

        public static void BuildSpeciesDatabase()
        {
            if (FortunaDbContext.skip == true) { return; }

            WebClient client = new WebClient();
            var SpeciesUrls = new List<string>();
            Debug.WriteLine("Start species page download");
            string downloadedString = client.DownloadString("https://cosmosdex.com/cosmosdex/species/");
            Debug.WriteLine("Start species processing");

            foreach (Match m in Regex.Matches(downloadedString, WebRegexPatterns.SpeciesNameUrlPattern))
            {
                AttributesGeneric attributesGeneric = new AttributesGeneric() { MainArtCreator = new AttributeCreator() };
                AttributesSpecies attributesSpecies = new AttributesSpecies();

                string speciesName = Regex.Match(m.Value, "(\"([a-zA-Z0-9-]*))").Value.Remove(0, 1); //Grabs species name

                Debug.WriteLine(speciesName);

                if (speciesName == "isment")
                {
                    speciesName = "NULLENTITY"; //Special case for isment 404 gimic
                }

                var toProcess = client.DownloadString("https://cosmosdex.com/cosmosdex/species/" + speciesName);

                BuildEntryName(ref attributesGeneric, toProcess);
                BuildEntryMainArt(ref attributesGeneric, toProcess);
                BuildEntryQuote(ref attributesGeneric, toProcess);
                BuildEntryCreator(ref attributesGeneric, toProcess);
                BuildEntryAltArt(attributesGeneric, toProcess);
                

                //"http://cosmosdex.com"+speciesName, speciesName, attributesGeneric, attributesSpecies

                SpeciesContainer speciesContainer = new SpeciesContainer() {
                    Url = "http://cosmosdex.com" + speciesName,
                    DatabaseName = speciesName,
                    AttributesGeneric = attributesGeneric,
                    AttributesSpecies = attributesSpecies
                };

                

                db_.SpeciesContainers.Add(speciesContainer);
                
            }
            db_.SaveChanges();
            var test = db_.SpeciesContainers.Where(x => x.DatabaseName == "fhelzo").FirstOrDefault();
        }


        internal static void BuildEntryName(ref AttributesGeneric attributes, string source)
        {
            Debug.WriteLine("Processing entry name");
            var EntryNameSection = Regex.Match(source, WebRegexPatterns.EntryNameSectionPattern);
            Debug.Write(".");
            if (EntryNameSection.Success == true)
            {
                Debug.Write(".");
                attributes.Name = EntryNameSection.Groups[1].Value;

                attributes.Alias = EntryNameSection.Groups[2].Value;

            }else
            {
                throw new System.ArgumentNullException("Entry cannot be missing a name");
            }
            Debug.Write(".");
        }

        internal static void BuildEntryMainArt(ref AttributesGeneric attributes, string source)
        {
            Debug.WriteLine("Processing entry main art");
            var EntryMainArtSection = Regex.Match(source, WebRegexPatterns.EntryMainArtPattern);
            var EntryMainArtCreatorSection = Regex.Match(source, WebRegexPatterns.EntryMainArtCreatorPattern);
            Debug.Write(".");
            if (EntryMainArtSection.Success == true)
            {
                Debug.Write(".");
                attributes.MainArt = "https://cosmosdex.com"+EntryMainArtSection.Groups[1].Value;
                attributes.MainArtCreator.CreatorUrl = EntryMainArtCreatorSection.Groups[1].Value;
                attributes.MainArtCreator.CreatorName = EntryMainArtCreatorSection.Groups[2].Value;

            }else
            {
                Debug.Write(".");
                attributes.MainArt = "https://cosmosdex.com/images/deximages/species/display/fhelzo.png";
                attributes.MainArtCreator.CreatorName = null;
                attributes.MainArtCreator.CreatorUrl = null;
            }
            Debug.Write(".");
        }

        internal static void BuildEntryQuote(ref AttributesGeneric attributes, string source)
        {
            Debug.WriteLine("Processing entry quote");
            var EntryQuoteSection = Regex.Match(source, WebRegexPatterns.EntryQuotePattern);
            Debug.Write(".");
            if (EntryQuoteSection.Success == true)
            {
                Debug.Write(".");
                attributes.Quote = EntryQuoteSection.Groups[1].Value;
            }
            else
            {
                throw new System.ArgumentNullException("Entry cannot be missing a quote");
            }
            Debug.Write(".");
        }

        internal static void BuildEntryCreator(ref AttributesGeneric attributes, string source)
        {
            Debug.WriteLine("Processing entry creator");
            var EntryCreatorSectionName = Regex.Match(source, WebRegexPatterns.EntryCreatorNamePattern);
            var EntryCreatorSectionUrl = Regex.Match(source, WebRegexPatterns.EntryCreatorLinkPattern);
            Debug.Write(".");
            if (EntryCreatorSectionName.Success == true)
            {
                Debug.Write(".");
                attributes.ArticleCreator.CreatorName = EntryCreatorSectionName.Groups[1].Value;
            }else
            {
                Debug.Write(".");
                EntryCreatorSectionName = Regex.Match(source, WebRegexPatterns.EntryCreatorNameFallbackPattern);
                if (EntryCreatorSectionName.Success != true) throw new System.ArgumentNullException("Entry must have a creator??");
                attributes.ArticleCreator.CreatorUrl = EntryCreatorSectionUrl.Groups[1].Value;
            }
            Debug.Write(".");

            Debug.WriteLine(EntryCreatorSectionUrl.Groups[1].Value);
            if (EntryCreatorSectionUrl.Success == false) { return; }
            Debug.Write(".");
            attributes.ArticleCreator.CreatorUrl = EntryCreatorSectionUrl.Groups[1].Value;
        }

        internal static void BuildEntryAltArt(AttributesGeneric attributes, string source)
        {
            Debug.WriteLine("Processing entry alt art");
            var EntryAltArts = Regex.Matches(source, WebRegexPatterns.EntryAltArtPattern);
            foreach(Match m in EntryAltArts)
            {
                Debug.Write(".");
                AttributeAltArt altArt = new AttributeAltArt
                {
                    Url = "https://www.cosmosdex.com"+m.Groups[1].Value,
                    Description = m.Groups[2].Value,
                    HostAttribute = attributes.Id
                };
                altArt.AltArtCreator.CreatorUrl = m.Groups[3].Value;
                altArt.AltArtCreator.CreatorName = m.Groups[4].Value;
                db_.AttributeAltArts.Add(altArt);
            }
            Debug.WriteLine("");
            db_.SaveChanges();
        }

        internal static void BuildEntryStats(ref AttributesGeneric attributes, string source)
        {
            Debug.WriteLine("Processing entry stats");
            var EntryStats = Regex.Matches(source, WebRegexPatterns.EntryStatsPattern);
            Stat stat = new Stat();
            foreach (Match m in EntryStats)
            {
                Debug.Write(".");
                //stat.S = m.Groups[1].Value; //cast? fuck it? idk
            }
        }

        internal static void BuildSpecies()
        {

        }

        internal static void BuildEntryBlurb(ref AttributesGeneric attributes, string source)
        {
            Debug.WriteLine("Processing entry blurb...");
        }





    }
}