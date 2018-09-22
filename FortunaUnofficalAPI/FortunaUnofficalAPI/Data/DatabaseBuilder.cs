using FortunaUnofficialAPI.Models.Containers;
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
        private static readonly string SpeciesNameUrlPattern = "(\\<a href=\"([a-zA-Z0-9\\-]*)\"\\>)";
        private static readonly string EntryNameSectionPattern = "((\\<div id\\=\\\"commonentryheader\\\"\\>)[\\s\\S]+?(\\<\\/div\\>)[\\s\\S]+?(<\\/div>))";
        private static readonly string EntryNamePattern = "<u>(.+?)<";
        private static readonly string EntryAltNamePattern = "<h4>(.+?)<\\/h4>";
        private static readonly string EntryMainArtPattern = "<img .+? src=\"(.+?)\">";
        private static readonly string EntryQuotePattern = "<div id=\"entryquickinfoimgtext\">[\\s\\S]+?<i>(.+?)<";
        private static readonly string EntryMainArtCreatorUrlPattern = "<div id=\"entryquickinfoimgtext\">[\\s\\S]+?<p>.+?<a href=\"(.+?)\"";
        private static readonly string EntryMainArtCreatorPattern = "<div id=\"entryquickinfoimgtext\">[\\s\\S]+?<p>.+?>(.+?)<";
        private static readonly string EntryStatsSectionPattern = "<div id=\"entryquickinfostats\">[\\s\\S]+?<\\/div>";
        private static readonly string EntryStatsPattern = "(<b>.+?<\\/b>)";
        private static readonly string EntryGenericInfoSectionPattern = "<div class=\"entryquickinfoect\">[\\s\\S]+?<h5>Patrons and Gods<\\/h5>";

        private static readonly string EntryGodsPatronSectionPattern = "<h5>Patrons and Gods<\\/h5>[\\s\\S]+?<\\/div>";

        public static void BuildSpeciesDatabase()
        {
            WebClient client = new WebClient();
            var SpeciesUrls = new List<string>();

            string downloadedString = client.DownloadString("https://cosmosdex.com/cosmosdex/species/");
            foreach (Match m in Regex.Matches(downloadedString, SpeciesNameUrlPattern))
            {
                SpeciesContainer speciesContainer = new SpeciesContainer(); 
                var speciesName = Regex.Match(m.Value, "(\"([a-zA-Z0-9-]*))").Value.Remove(0, 1);
                if (speciesName == "isment")
                {
                    speciesName = "NULLENTITY"; //Special case for isment 404 gimic
                }
                var toProcess = client.DownloadString("https://cosmosdex.com/cosmosdex/species/" + speciesName);
                var EntryNameSection = Regex.Match(toProcess, EntryNameSectionPattern); //Name / Alias processing
                if (EntryNameSection.Success == true)
                {
                    speciesContainer.GenericAttributes.Name = MatchEntryName(EntryNameSection.Value);
                    speciesContainer.GenericAttributes.Alias = MatchEntryAltName(EntryNameSection.Value);
                }



                
            }
            return;
        }

        private static string MatchEntryName(string toProcess)
        {
            var nameResult = Regex.Match(toProcess, EntryNamePattern);
            if (nameResult.Success == false) return null;

            return nameResult.Groups[1].Value;
        }

        private static string MatchEntryAltName(string toProcess)
        {
            var nameResult = Regex.Match(toProcess, EntryAltNamePattern);
            if (nameResult.Success == false) return null;

            return nameResult.Groups[1].Value;
        }
    }
}