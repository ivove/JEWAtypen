using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEWAtypen.Helpers;

public static class WikiOpkuis
{
    public static string OpruimenWikiTekst(this string invoer)
    {
        var resultaat = "";
        resultaat = OpruimenGekruldeHaken(invoer);
        resultaat = OpruimenTabel(resultaat);
        resultaat = OpruimenTag(resultaat, "[[Categorie:", "]]");
        resultaat = OpruimenTag(resultaat, "[[Bestand:", "]]");
        resultaat = VierkanteHakenBehandelen(resultaat);
        resultaat = OpruimenHtmlTag(resultaat, "ref");
        // =-tekens verwijderen behalve de enkele... 
        resultaat = resultaat.Replace("===", "");
        resultaat = resultaat.Replace("==", "");
        // enkele afkappingstekens laten staan, maar de rest verwijderen
        resultaat = resultaat.Replace("'''", "");
        resultaat = resultaat.Replace("''", "");
        return resultaat;
    }
    /// <summary>
    /// clean out wiki tags with double curly braces
    /// </summary>
    /// <param name="invoer"></param>
    /// <returns></returns>
    private static string OpruimenGekruldeHaken(string invoer)
    {
        return OpruimenTag(invoer, "{{", "}}");
    }
    /// <summary>
    /// clean out a wiki table stating with {| and ending in |}
    /// </summary>
    /// <param name="invoer"></param>
    /// <returns></returns>
    private static string OpruimenTabel(string invoer)
    {
        return OpruimenTag(invoer, "{|", "|}");
    }
    /// <summary>
    /// clean out everything between the tag end the close tag, including both tags
    /// </summary>
    /// <param name="invoer"></param>
    /// <param name="tag"></param>
    /// <param name="sluitTag"></param>
    /// <returns></returns>
    private static string OpruimenTag(string invoer, string tag, string sluitTag)
    {
        var result = "";
        if (invoer.Contains(tag) && invoer.Contains(sluitTag))
        {
            while (invoer.Length > 0)
            {
                var idx = invoer.IndexOf(tag);
                if (idx >= 0)
                {
                    if (idx > 0)
                    {
                        result += invoer.Substring(0, idx);
                    }
                    var nextStart = invoer.IndexOf(tag, idx + tag.Length);
                    var eindidx = invoer.IndexOf(sluitTag, idx + sluitTag.Length);
                    while (nextStart != -1 && nextStart < eindidx)
                    {
                        eindidx = invoer.IndexOf(sluitTag, eindidx + sluitTag.Length);
                        nextStart = invoer.IndexOf(tag, nextStart + tag.Length);
                    }
                    invoer = invoer.Substring(eindidx + sluitTag.Length);
                }
                else
                {
                    result += invoer;
                    invoer = "";
                }
            }
        }
        else { result = invoer; }
        return result;
    }
    /// <summary>
    /// handle text between squared brackets. If just text; return the text if containing a pipe, return the part after the pipe
    /// </summary>
    /// <param name="invoer"></param>
    /// <returns></returns>
    private static string VierkanteHakenBehandelen(string invoer)
    {
        var resultaat = "";
        if (invoer.Contains("[["))
        {
            while (invoer.Length > 0)
            {
                var idx = invoer.IndexOf("[[");
                if (idx >= 0)
                {
                    if (idx > 0)
                    {
                        resultaat += invoer.Substring(0, idx);
                    }
                    var eindIdx = invoer.IndexOf("]]");
                    var inhoud = invoer.Substring(idx + 2, eindIdx - idx - 2);
                    if (inhoud.Contains("|"))
                    {
                        resultaat += inhoud.Split('|')[1];
                    }
                    else { resultaat += inhoud; }
                    invoer = invoer.Substring(eindIdx + 2);
                }
                else
                {
                    resultaat += invoer;
                    invoer = "";
                }
            }
        }
        else
        {
            resultaat = invoer;
        }
        return resultaat;
    }
    /// <summary>
    /// Clean out html-style tags
    /// </summary>
    /// <param name="invoer"></param>
    /// <param name="tag"></param>
    /// <returns></returns>
    private static string OpruimenHtmlTag(string invoer, string tag)
    {
        var resultaat = "";
        var sluitTag = $"</{tag}>";
        tag = $"<{tag} ";
        if (invoer.Contains(tag))
        {
            while (invoer.Length > 0)
            {
                var idx = invoer.IndexOf(tag);
                if (idx >= 0)
                {
                    if (idx > 0)
                    {
                        resultaat += invoer.Substring(0, idx);
                    }
                    var eindidx = invoer.IndexOf(">", idx);
                    if (invoer[eindidx - 1] == '/')
                    {
                        invoer = invoer.Substring(eindidx + 1);
                    }
                    else
                    {
                        eindidx = invoer.IndexOf(sluitTag, idx);
                        invoer = invoer.Substring(eindidx + sluitTag.Length);
                    }
                }
                else
                {
                    resultaat += invoer;
                    invoer = "";
                }
            }
        }
        else { resultaat = invoer; }
        return resultaat;
    }
}
