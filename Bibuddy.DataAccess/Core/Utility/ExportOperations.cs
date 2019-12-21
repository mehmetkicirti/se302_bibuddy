using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bibuddy.DataAccess.Core.Utility
{
    public class ExportOperations
    {
        public static string GetImportFile(List<object> objects)
        {
            //string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string FilePath = FileName + ".bib";
            //string FullPath = Path.Combine(DesktopPath, FilePath);
            string exportedFile = "";
            Dictionary<string, string> getfieldName;
            foreach (var obj in objects)
            {
                exportedFile += "@";
                PropertyInfo[] fields = obj.GetType().GetProperties();
                switch (obj.GetType().Name)
                {
                    case "article":

                        getfieldName = new Dictionary<string, string>();
                        foreach (var field in fields)
                        {
                            if (field.Name=="Item")
                                continue;
                            getfieldName.Add(field.Name, field.GetValue(obj) != null ? field.GetValue(obj).ToString() : "");
                        }
                        exportedFile += getfieldName.ContainsKey("entrytype") ? getfieldName["entrytype"] + "{" : "";
                        exportedFile += (getfieldName.ContainsKey("bibtexkey") && getfieldName["bibtexkey"] != "") ? getfieldName["bibtexkey"] + "," : "";
                        exportedFile += (getfieldName.ContainsKey("title") && getfieldName["title"] != "") ? Environment.NewLine + "title={" + getfieldName["title"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("doi") && getfieldName["doi"] != "") ? Environment.NewLine + "doi={" + getfieldName["doi"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("year") && getfieldName["year"] != "") ? Environment.NewLine + "year={" + getfieldName["year"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("month") && getfieldName["month"] != "") ? Environment.NewLine + "month={" + getfieldName["month"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("note") && getfieldName["note"] != "") ? Environment.NewLine + "note={" + getfieldName["note"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("author") && getfieldName["author"] != "") ? Environment.NewLine + "author={" + getfieldName["author"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("journal") && getfieldName["journal"] != "") ? Environment.NewLine + "journal={" + getfieldName["journal"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("number") && getfieldName["number"] != "") ? Environment.NewLine + "number={" + getfieldName["number"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("pages") && getfieldName["pages"] != "") ? Environment.NewLine + "pages={" + getfieldName["pages"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("volume") && getfieldName["volume"] != "") ? Environment.NewLine + "volume={" + getfieldName["volume"] + "}," : "";

                        exportedFile = exportedFile.Remove(exportedFile.Length - 1);
                        exportedFile += Environment.NewLine + "}" + Environment.NewLine;

                        break;

                    case "book" : 
                        getfieldName = new Dictionary<string, string>();
                        foreach (var field in fields)
                        {
                            if (field.Name == "Item")
                                continue;
                            getfieldName.Add(field.Name, field.GetValue(obj) != null ? field.GetValue(obj).ToString() : "");
                        }
                        exportedFile += getfieldName.ContainsKey("entrytype") ? getfieldName["entrytype"] + "{" : "";
                        exportedFile += (getfieldName.ContainsKey("bibtexkey") && getfieldName["bibtexkey"] != "") ? getfieldName["bibtexkey"] + "," : "";
                        exportedFile += (getfieldName.ContainsKey("title") && getfieldName["title"] != "") ? Environment.NewLine + "title={" + getfieldName["title"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("doi") && getfieldName["doi"] != "") ? Environment.NewLine + "doi={" + getfieldName["doi"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("year") && getfieldName["year"] != "") ? Environment.NewLine + "year={" + getfieldName["year"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("month") && getfieldName["month"] != "") ? Environment.NewLine + "month={" + getfieldName["month"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("note") && getfieldName["note"] != "") ? Environment.NewLine + "note={" + getfieldName["note"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("author") && getfieldName["author"] != "") ? Environment.NewLine + "author={" + getfieldName["author"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("series") && getfieldName["series"] != "") ? Environment.NewLine + "series={" + getfieldName["series"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("address") && getfieldName["address"] != "") ? Environment.NewLine + "address={" + getfieldName["address"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("edition") && getfieldName["edition"] != "") ? Environment.NewLine + "edition={" + getfieldName["edition"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("url") && getfieldName["url"] != "") ? Environment.NewLine + "url={" + getfieldName["url"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("volume") && getfieldName["volume"] != "") ? Environment.NewLine + "volume={" + getfieldName["volume"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("publisher") && getfieldName["publisher"] != "") ? Environment.NewLine + "publisher={" + getfieldName["publisher"] + "}," : "";

                        exportedFile = exportedFile.Remove(exportedFile.Length - 1);
                        exportedFile += Environment.NewLine + "}" + Environment.NewLine;

                        break;

                    case "booklet":
                        getfieldName = new Dictionary<string, string>();
                        foreach (var field in fields)
                        {
                            if (field.Name == "Item")
                                continue;
                            getfieldName.Add(field.Name, field.GetValue(obj) != null ? field.GetValue(obj).ToString() : "");
                        }
                        exportedFile += getfieldName.ContainsKey("entrytype") ? getfieldName["entrytype"] + "{" : "";
                        exportedFile += (getfieldName.ContainsKey("bibtexkey") && getfieldName["bibtexkey"] != "") ? getfieldName["bibtexkey"] + "," : "";
                        exportedFile += (getfieldName.ContainsKey("title") && getfieldName["title"] != "") ? Environment.NewLine + "title={" + getfieldName["title"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("doi") && getfieldName["doi"] != "") ? Environment.NewLine + "doi={" + getfieldName["doi"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("year") && getfieldName["year"] != "") ? Environment.NewLine + "year={" + getfieldName["year"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("month") && getfieldName["month"] != "") ? Environment.NewLine + "month={" + getfieldName["month"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("note") && getfieldName["note"] != "") ? Environment.NewLine + "note={" + getfieldName["note"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("howpublished") && getfieldName["howpublished"] != "") ? Environment.NewLine + "howpublished={" + getfieldName["howpublished"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("address") && getfieldName["address"] != "") ? Environment.NewLine + "address={" + getfieldName["address"] + "}," : "";

                        exportedFile = exportedFile.Remove(exportedFile.Length - 1);
                        exportedFile += Environment.NewLine + "}" + Environment.NewLine;

                        break;

                    case "conference": 
                        getfieldName = new Dictionary<string, string>();
                        foreach (var field in fields)
                        {
                            if (field.Name == "Item")
                                continue;
                            getfieldName.Add(field.Name, field.GetValue(obj) != null ? field.GetValue(obj).ToString() : "");
                        }
                        exportedFile += getfieldName.ContainsKey("entrytype") ? getfieldName["entrytype"] + "{" : "";
                        exportedFile += (getfieldName.ContainsKey("bibtexkey") && getfieldName["bibtexkey"] != "") ? getfieldName["bibtexkey"] + "," : "";
                        exportedFile += (getfieldName.ContainsKey("title") && getfieldName["title"] != "") ? Environment.NewLine + "title={" + getfieldName["title"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("doi") && getfieldName["doi"] != "") ? Environment.NewLine + "doi={" + getfieldName["doi"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("year") && getfieldName["year"] != "") ? Environment.NewLine + "year={" + getfieldName["year"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("month") && getfieldName["month"] != "") ? Environment.NewLine + "month={" + getfieldName["month"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("note") && getfieldName["note"] != "") ? Environment.NewLine + "note={" + getfieldName["note"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("author") && getfieldName["author"] != "") ? Environment.NewLine + "author={" + getfieldName["author"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("booktitle") && getfieldName["booktitle"] != "") ? Environment.NewLine + "booktitle={" + getfieldName["booktitle"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("editor") && getfieldName["editor"] != "") ? Environment.NewLine + "editor={" + getfieldName["editor"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("volume") && getfieldName["volume"] != "") ? Environment.NewLine + "volume={" + getfieldName["volume"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("series") && getfieldName["series"] != "") ? Environment.NewLine + "series={" + getfieldName["series"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("pages") && getfieldName["pages"] != "") ? Environment.NewLine + "pages={" + getfieldName["pages"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("address") && getfieldName["address"] != "") ? Environment.NewLine + "address={" + getfieldName["address"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("organization") && getfieldName["organization"] != "") ? Environment.NewLine + "organization={" + getfieldName["organization"] + "}," : "";
                        


                        exportedFile = exportedFile.Remove(exportedFile.Length - 1);
                        exportedFile += Environment.NewLine + "}" + Environment.NewLine;

                        break;

                    case "inbook":
                        getfieldName = new Dictionary<string, string>();
                        foreach (var field in fields)
                        {
                            if (field.Name == "Item")
                                continue;
                            getfieldName.Add(field.Name, field.GetValue(obj) != null ? field.GetValue(obj).ToString() : "");
                        }
                        exportedFile += getfieldName.ContainsKey("entrytype") ? getfieldName["entrytype"] + "{" : "";
                        exportedFile += (getfieldName.ContainsKey("bibtexkey") && getfieldName["bibtexkey"] != "") ? getfieldName["bibtexkey"] + "," : "";
                        exportedFile += (getfieldName.ContainsKey("title") && getfieldName["title"] != "") ? Environment.NewLine + "title={" + getfieldName["title"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("doi") && getfieldName["doi"] != "") ? Environment.NewLine + "doi={" + getfieldName["doi"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("year") && getfieldName["year"] != "") ? Environment.NewLine + "year={" + getfieldName["year"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("month") && getfieldName["month"] != "") ? Environment.NewLine + "month={" + getfieldName["month"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("note") && getfieldName["note"] != "") ? Environment.NewLine + "note={" + getfieldName["note"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("author") && getfieldName["author"] != "") ? Environment.NewLine + "author={" + getfieldName["author"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("chapter") && getfieldName["number"] != "") ? Environment.NewLine + "number={" + getfieldName["number"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("volume") && getfieldName["volume"] != "") ? Environment.NewLine + "volume={" + getfieldName["volume"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("series") && getfieldName["series"] != "") ? Environment.NewLine + "series={" + getfieldName["series"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("publisher") && getfieldName["publisher"] != "") ? Environment.NewLine + "publisher={" + getfieldName["publisher"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("address") && getfieldName["address"] != "") ? Environment.NewLine + "address={" + getfieldName["address"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("edition") && getfieldName["edition"] != "") ? Environment.NewLine + "edition={" + getfieldName["edition"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("type") && getfieldName["type"] != "") ? Environment.NewLine + "type={" + getfieldName["type"] + "}," : "";                                   

                        exportedFile = exportedFile.Remove(exportedFile.Length - 1);
                        exportedFile += Environment.NewLine + "}" + Environment.NewLine;

                        break;

                    case "incollection":
                        getfieldName = new Dictionary<string, string>();
                        foreach (var field in fields)
                        {
                            if (field.Name == "Item")
                                continue;
                            getfieldName.Add(field.Name, field.GetValue(obj) != null ? field.GetValue(obj).ToString() : "");
                        }
                        exportedFile += getfieldName.ContainsKey("entrytype") ? getfieldName["entrytype"] + "{" : "";
                        exportedFile += (getfieldName.ContainsKey("bibtexkey") && getfieldName["bibtexkey"] != "") ? getfieldName["bibtexkey"] + "," : "";
                        exportedFile += (getfieldName.ContainsKey("title") && getfieldName["title"] != "") ? Environment.NewLine + "title={" + getfieldName["title"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("doi") && getfieldName["doi"] != "") ? Environment.NewLine + "doi={" + getfieldName["doi"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("year") && getfieldName["year"] != "") ? Environment.NewLine + "year={" + getfieldName["year"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("month") && getfieldName["month"] != "") ? Environment.NewLine + "month={" + getfieldName["month"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("note") && getfieldName["note"] != "") ? Environment.NewLine + "note={" + getfieldName["note"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("author") && getfieldName["author"] != "") ? Environment.NewLine + "author={" + getfieldName["author"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("chapter") && getfieldName["chapter"] != "") ? Environment.NewLine + "chapter={" + getfieldName["chapter"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("booktitle") && getfieldName["booktitle"] != "") ? Environment.NewLine + "booktitle={" + getfieldName["booktitle"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("publisher") && getfieldName["publisher"] != "") ? Environment.NewLine + "publisher={" + getfieldName["publisher"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("editor") && getfieldName["editor"] != "") ? Environment.NewLine + "editor={" + getfieldName["editor"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("volume") && getfieldName["volume"] != "") ? Environment.NewLine + "volume={" + getfieldName["volume"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("series") && getfieldName["series"] != "") ? Environment.NewLine + "series={" + getfieldName["series"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("pages") && getfieldName["pages"] != "") ? Environment.NewLine + "pages={" + getfieldName["pages"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("address") && getfieldName["address"] != "") ? Environment.NewLine + "address={" + getfieldName["address"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("edition") && getfieldName["edition"] != "") ? Environment.NewLine + "edition={" + getfieldName["edition"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("type") && getfieldName["type"] != "") ? Environment.NewLine + "type={" + getfieldName["type"] + "}," : "";


                        exportedFile = exportedFile.Remove(exportedFile.Length - 1);
                        exportedFile += Environment.NewLine + "}" + Environment.NewLine;

                        break;

                    case "manual": 
                        getfieldName = new Dictionary<string, string>();
                        foreach (var field in fields)
                        {
                            if (field.Name == "Item")
                                continue;
                            getfieldName.Add(field.Name, field.GetValue(obj) != null ? field.GetValue(obj).ToString() : "");
                        }
                        exportedFile += getfieldName.ContainsKey("entrytype") ? getfieldName["entrytype"] + "{" : "";
                        exportedFile += (getfieldName.ContainsKey("bibtexkey") && getfieldName["bibtexkey"] != "") ? getfieldName["bibtexkey"] + "," : "";
                        exportedFile += (getfieldName.ContainsKey("title") && getfieldName["title"] != "") ? Environment.NewLine + "title={" + getfieldName["title"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("doi") && getfieldName["doi"] != "") ? Environment.NewLine + "doi={" + getfieldName["doi"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("year") && getfieldName["year"] != "") ? Environment.NewLine + "year={" + getfieldName["year"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("month") && getfieldName["month"] != "") ? Environment.NewLine + "month={" + getfieldName["month"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("note") && getfieldName["note"] != "") ? Environment.NewLine + "note={" + getfieldName["note"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("author") && getfieldName["author"] != "") ? Environment.NewLine + "author={" + getfieldName["author"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("organization") && getfieldName["organization"] != "") ? Environment.NewLine + "organization={" + getfieldName["organization"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("address") && getfieldName["address"] != "") ? Environment.NewLine + "address={" + getfieldName["address"] + "}," : "";
                        exportedFile += (getfieldName.ContainsKey("edition") && getfieldName["edition"] != "") ? Environment.NewLine + "edition={" + getfieldName["edition"] + "}," : "";


                        exportedFile = exportedFile.Remove(exportedFile.Length - 1);
                        exportedFile += Environment.NewLine + "}" + Environment.NewLine;

                        break;

                    default:
                        break;
                }
            }
            return exportedFile;
            //File.WriteAllText(FullPath, exportedFile);
        }


        public static String getHTMLexport(List<object> objects)
        {
            String htmlString = "<!DOCTYPE html><html lang='en'><head><meta charset='UTF-8'><meta name='viewport' content='width=device-width, initial-scale=1.0'><meta http-equiv='X-UA-Compatible' content='ie=edge'>" +
                "<title>BibBuddy Output</title>" +
                "<style type='text/css'>  body { font-family:Georgia, Garamond, Serif; background-color:#ddd;} " +
                ".bibtex_entry { border:2px solid black;margin:1em;}" +
                ".bibtex_header {border-bottom:solid gray 2px;}" +
                ".bibtex_type {color:#232CEB; font-size:small; display:inline; font-weight:bold}" +
                ".bibtex_key {font-size:small; color:#555;display:inline;font-weight:bold}" +
                ".bibtex_content {padding-bottom:1em;} " +
                ".bibtex_author {font-weight:bold; padding-bottom:1em;}" +
                ".bibtex_title {font-weight:bold; padding-bottom:1em; }" +
                ".bibtex_url { display:inline; font-size:small; float:right; padding-left:1em; padding-right:1em; } " +
                ".bibtex_inline{ display:inline;}" +

                " </style></head><body> ";


            Dictionary<string, string> getfieldName;

            foreach (var obj in objects)
            {
                PropertyInfo[] fields = obj.GetType().GetProperties();
                getfieldName = new Dictionary<string, string>();

                foreach (var field in fields)
                {
                    if (field.Name == "Item")
                        continue;
                    getfieldName.Add(field.Name, field.GetValue(obj) != null ? field.GetValue(obj).ToString() : "");

                }

                htmlString += "<hr><div class='bibtex_entry' < div class='bibtex_header'>";
                htmlString += (getfieldName.ContainsKey("entrytype") && getfieldName["entrytype"] != "") ? "<div class='bibtex_type'>" + getfieldName["entrytype"] + "    " + "</a></div>" : "";
                htmlString += (getfieldName.ContainsKey("bibtexkey") && getfieldName["bibtexkey"] != "") ? "<div class='bibtex_key'><a>" + getfieldName["bibtexkey"] + "</a></div>" : "";
                htmlString += (getfieldName.ContainsKey("url") && getfieldName["url"] != "") ? "<div class='bibtex_url'><a href='" + getfieldName["url"] + "'>url</a></div>" : "";
                htmlString += (getfieldName.ContainsKey("doi") && getfieldName["doi"] != "") ? "<div class='bibtex_url'><a href='" + getfieldName["doi"] + "'>url </a></div></div>" : "";
                htmlString += (getfieldName.ContainsKey("author") && getfieldName["author"] != "") ? "<div class='bibtex_content'><div class='bibtex_title'><p>" + getfieldName["title"] + "</div>" : "";
                htmlString += (getfieldName.ContainsKey("year") && getfieldName["year"] != "") ? "<div class='bibtex_content'>" + getfieldName["year"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("journal") && getfieldName["journal"] != "") ? "<div class='bibtex_content'>" + getfieldName["journal"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("volume") && getfieldName["volume"] != "") ? "<div class='bibtex_content'>" + getfieldName["volume"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("number") && getfieldName["number"] != "") ? "<div class='bibtex_content'>" + getfieldName["number"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("series") && getfieldName["series"] != "") ? "<div class='bibtex_content'>" + getfieldName["series"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("edition") && getfieldName["edition"] != "") ? "<div class='bibtex_content'>" + getfieldName["edition"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("publisher") && getfieldName["publisher"] != "") ? "<div class='bibtex_content'>" + getfieldName["publisher"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("organization") && getfieldName["organization"] != "") ? "<div class='bibtex_content'>" + getfieldName["organization"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("howpublished") && getfieldName["howpublished"] != "") ? "<div class='bibtex_content'>" + getfieldName["howpublished"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("chapter") && getfieldName["chapter"] != "") ? "<div class='bibtex_content'>" + getfieldName["chapter"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("type") && getfieldName["type"] != "") ? "<div class='bibtex_content'>" + getfieldName["type"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("editor") && getfieldName["editor"] != "") ? "<div class='bibtex_content'>" + getfieldName["editor"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("address") && getfieldName["address"] != "") ? "<div class='bibtex_inline'>" + getfieldName["address"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("note") && getfieldName["note"] != "") ? "<div class='bibtex_inline'>" + getfieldName["note"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("month") && getfieldName["month"] != "") ? "<div class='bibtex_inline'>" + getfieldName["month"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("pages") && getfieldName["pages"] != "") ? "<div class='bibtex_inline'>" + getfieldName["pages"] + ", </div>" : "";


                htmlString += "</div></div>";

            }

            htmlString += "<hr></body></html>";


            return htmlString;

        }
    }
}
