using System;
using System.IO;

namespace CsvToHtmlConverter
{
    class CsvToHtmlConverter
    {
        public static void ConvertCsvToHtml(string inputFilePath, string outputFilePath)
        {
            try
            {
                using StreamReader reader = new StreamReader(inputFilePath);

                using StreamWriter writer = new StreamWriter(outputFilePath);

                writer.WriteLine("<!DOCTYPE html>");
                writer.WriteLine("<html lang=\"ru-RU\">");
                writer.WriteLine("\t<head>");
                writer.WriteLine("\t\t<meta charset=\"UTF-8\">");
                writer.WriteLine("\t\t<title>Table</title>");
                writer.WriteLine("\t</head>");
                writer.WriteLine("\t<body>");
                writer.WriteLine("\t\t<table>");

                string inputLine;
                bool isNextCell = true;
                bool isQuotes = false;

                while ((inputLine = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(inputLine))
                    {
                        continue;
                    }

                    if (isNextCell)
                    {
                        writer.WriteLine("\t\t\t<tr>");
                        writer.Write("\t\t\t\t<td>");
                    }
                    else
                    {
                        writer.Write("\t\t\t\t\t");
                    }

                    foreach (char character in inputLine)
                    {
                        if (char.IsLetterOrDigit(character))
                        {
                            writer.Write(character);

                            continue;
                        }

                        switch (character)
                        {
                            case '"':
                                if (!isNextCell || isQuotes)
                                {
                                    if (isQuotes)
                                    {
                                        writer.Write("\"");
                                    }

                                    isQuotes = !isQuotes;
                                }

                                isNextCell = !isNextCell;

                                break;

                            case ',':
                                if (isNextCell)
                                {
                                    isQuotes = false;

                                    writer.WriteLine("</td>");
                                    writer.Write("\t\t\t\t<td>");
                                }
                                else
                                {
                                    writer.Write(",");
                                }

                                break;

                            case '<':
                                writer.Write("&lt;");
                                break;

                            case '>':
                                writer.Write("&gt;");
                                break;

                            case '&':
                                writer.Write("&amp;");
                                break;

                            default:
                                writer.Write(character);
                                break;
                        }
                    }

                    if (isNextCell)
                    {
                        isQuotes = false;

                        writer.WriteLine("</td>");
                        writer.WriteLine("\t\t\t</tr>");
                    }
                    else
                    {
                        writer.WriteLine("<br/>");
                    }
                }

                writer.WriteLine("\t\t</table>");
                writer.WriteLine("\t</body>");
                writer.WriteLine("</html>");
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e);
            }
        }
    }
}
