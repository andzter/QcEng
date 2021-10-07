using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QC.Lib
{

    public static class PdfUtils
    {
        public static int PageCount(string path)
        {

            try
            {
                using (StreamReader sr = new StreamReader(File.OpenRead(path)))
                {
                    Regex regex = new Regex(@"/Type\s*/Page[^s]");
                    MatchCollection matches = regex.Matches(sr.ReadToEnd());

                    return matches.Count;
                }
            }
            catch
            {
                return 0;
            }

        }

        public static int PdfPageCount(string fullPath)
        {
            PdfReader reader = null;
            int pageCount;

            try
            {
                reader = new PdfReader(fullPath);
                pageCount = reader.NumberOfPages;
            }
            catch (Exception ex)
            {
                // throw new Exception("Error reading pdf! " + ex.Message);
                return 0;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }

            return pageCount;
        }

        public static Task<int> PdfPageCountAsync(string fullPath)
        {
            return Task.Run(() =>
            {
                int pageCount = PdfPageCount(fullPath);
                return pageCount;
            });
        }
    }

}
