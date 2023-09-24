using System;
using System.IO;
using System.Linq;

namespace FileDataReaderBGService.Utilities;

public class FileHelper
{
    /// <summary>
    /// if the directory does not exist or empty it will return null, otherwise path of the first .txt file
    /// </summary>
    /// <param name="directoryPath"></param>
    /// <returns></returns>
    public static string GetFirstFileFromDirectory(string directoryPath)
    {
        // Check if the directory does not exists then create it
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            return null;
        }

        try
        {
            // Get a list of all files in the specified directory
            string[] allFiles = Directory.GetFiles(directoryPath);

            // Filter the files to include only those with a .txt extension
            var txtFiles = allFiles.Where(file => file.EndsWith(".txt", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            // return the first file from the directory 
            return txtFiles;
        }
        catch (Exception ex)
        {
            // Handle any exceptions that may occur while reading the directory
            Console.WriteLine($"Error reading directory: {ex.Message}");
            throw;
        }
    }

    public static void MoveFile(string sourcePath, string destinationPath)
    {
        // get Directory path 
        var directoryPath = Path.GetDirectoryName(destinationPath);

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        File.Move(sourcePath, destinationPath);
    }
}
