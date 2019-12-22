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
                "<style type='text/css'>  body { font-family:Georgia, Garamond, Serif; background-color:#c5e1eb}  " +
                " .bibtex_entry { border: 4px solid rgb(0, 0, 0);margin:2em;}" +
                ".bibtex_header {border-bottom:solid rgb(0, 0, 0) 3px;}" +
                ".bibtex_type {color:#f02637; font-size:small; display:inline; font-weight:bold; padding-left: 5px;}" +
                ".bibtex_key {font-size:small; color: rgb(39, 42, 233);display:inline;font-weight:bold; padding-left: 10px;}" +
                ".bibtex_content {padding-bottom:1em; padding: 10px;} " +
                ".bibtex_author {font-weight:bold; padding: 10px;}" +
                ".bibtex_title {font-weight:bold; padding: 10px; }" +
                ".bibtex_url { display:inline; font-size:small; float:right; padding-left:1em; padding-right:1em; }  " +
                ".bibtex_inline{ display:inline; padding: 10px;}" +

                " </style></head><body><h1 style='text-align: center; '>BibBuddy Output</h1> ";


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

                htmlString += "<hr style='border - width: 3px; '><div class='bibtex_entry'> <div class='bibtex_header'> ";
                htmlString += (getfieldName.ContainsKey("entrytype") && getfieldName["entrytype"] != "") ? "<div class='bibtex_type'>" + getfieldName["entrytype"] + "</a></div>" : "";
                htmlString += (getfieldName.ContainsKey("bibtexkey") && getfieldName["bibtexkey"] != "") ? "<div class='bibtex_key'><a>" + getfieldName["bibtexkey"] + "</a></div>" : "";
                htmlString += (getfieldName.ContainsKey("url") && getfieldName["url"] != "") ? "<div class='bibtex_url'><a href=' " + getfieldName["url"] + " '>URL</a></div>" : "";
                htmlString += (getfieldName.ContainsKey("doi") && getfieldName["doi"] != "") ? "<div class='bibtex_url'><a href=' " + getfieldName["doi"] +  "'>DOI</a></div>" : "";
                htmlString += "</div>";
                htmlString += (getfieldName.ContainsKey("author") && getfieldName["author"] != "") ? "<div class='bibtex_author'>" + getfieldName["author"] + "</div>" : "";
                htmlString += "<div class='bibtex_content'>";
                htmlString += (getfieldName.ContainsKey("title") && getfieldName["title"] != "") ? "<div class='bibtex_title'><p>" + getfieldName["title"] + "</p></div>" : "";
                htmlString += (getfieldName.ContainsKey("year") && getfieldName["year"] != "") ? "<div>" + getfieldName["year"] + "</div>" : "";
                htmlString += (getfieldName.ContainsKey("journal") && getfieldName["journal"] != "") ? "<div>" + getfieldName["journal"] + "</div>" : "";
                htmlString += (getfieldName.ContainsKey("volume") && getfieldName["volume"] != "") ? "<div>" + getfieldName["volume"] + "</div>" : "";
                htmlString += (getfieldName.ContainsKey("number") && getfieldName["number"] != "") ? "<div>" + getfieldName["number"] + "</div>" : "";
                htmlString += (getfieldName.ContainsKey("series") && getfieldName["series"] != "") ? "<div>" + getfieldName["series"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("edition") && getfieldName["edition"] != "") ? "<div>" + getfieldName["edition"] + ",</div>" : "";
                htmlString += (getfieldName.ContainsKey("publisher") && getfieldName["publisher"] != "") ? "<div>" + getfieldName["publisher"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("organization") && getfieldName["organization"] != "") ? "<div>" + getfieldName["organization"] + "</div>" : "";
                htmlString += (getfieldName.ContainsKey("howpublished") && getfieldName["howpublished"] != "") ? "<div>" + getfieldName["howpublished"] + "</div>" : "";
                htmlString += (getfieldName.ContainsKey("chapter") && getfieldName["chapter"] != "") ? "<div>" + getfieldName["chapter"] + "</div>" : "";
                htmlString += (getfieldName.ContainsKey("type") && getfieldName["type"] != "") ? "<div>" + getfieldName["type"] + "</div>" : "";
                htmlString += (getfieldName.ContainsKey("editor") && getfieldName["editor"] != "") ? "<div>" + getfieldName["editor"] + "</div>" : "";
                htmlString += "<div class='bibtex_inline'>";
                htmlString += (getfieldName.ContainsKey("address") && getfieldName["address"] != "") ? "<div>" + getfieldName["address"] + "</div>" : "";
                htmlString += (getfieldName.ContainsKey("note") && getfieldName["note"] != "") ? "<div>" + getfieldName["note"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("month") && getfieldName["month"] != "") ? "<div>" + getfieldName["month"] + ", </div>" : "";
                htmlString += (getfieldName.ContainsKey("pages") && getfieldName["pages"] != "") ? "<div>" + getfieldName["pages"] + ", </div>" : "";


                htmlString += "</div></div></div>";

            }

            htmlString += "<hr style='border - width: 3px; '></body></html>";


            return htmlString;

        }
    }
}
