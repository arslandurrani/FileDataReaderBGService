using FileDataReaderBGService.Common;
using FileDataReaderBGService.Entities;

using System;
using System.Collections.Generic;
using System.IO;

namespace FileDataReaderBGService.Utilities;

public class ELDEventsProcessor
{
    /// <summary>
    /// it will return empty if file is empty or nothing to process or Directory is empty or doesn't exist
    /// </summary>
    /// <returns></returns>
    public List<ELDEvents> ProcessFile(string filePath)
    {
        if (filePath == null)
            return null;

        var FileData = new List<ELDEvents>();

        try
        {
            // Open the file for reading using a StreamReader
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                // Read and process each line in the file
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Buffer:"))
                        continue;  // nothing to process here, move to the next line

                    var csvData = line.Substring("Data:".Length).Trim().Split(',');

                    var oneLineData = new ELDEvents()
                    {
                        Enginestate = Convert.ToInt32(csvData[Constants.ENGINESTATE_INDEX]),
                        VIN = csvData[Constants.VIN_INDEX],
                        RPM = Convert.ToDouble(csvData[Constants.RPM_INDEX]),
                        Speed = Convert.ToDouble(csvData[Constants.SPEED_INDEX]),
                        Odometer = Convert.ToDouble(csvData[Constants.ODOMETER_INDEX]),
                        TripDistance = Convert.ToDouble(csvData[Constants.TRIPDISTANCE_INDEX]),
                        Latitude = Convert.ToDouble(csvData[Constants.LATITUDE_INDEX]),
                        Longtitude = Convert.ToDouble(csvData[Constants.LONGTITUDE_INDEX])
                    };

                    FileData.Add(oneLineData);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return FileData;
    }

}
