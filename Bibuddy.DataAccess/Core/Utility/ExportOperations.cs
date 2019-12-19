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
    }
}
