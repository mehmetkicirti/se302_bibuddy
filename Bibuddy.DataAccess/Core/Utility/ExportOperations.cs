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
        public static void GetImportFile(List<object> objects, string FileName)
        {
            string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string FilePath = FileName + ".bib";
            string FullPath = Path.Combine(DesktopPath, FilePath);
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
                    default:
                        break;
                }
            }
            File.WriteAllText(FullPath, exportedFile);
        }
    }
}
