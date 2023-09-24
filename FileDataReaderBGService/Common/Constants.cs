using System;
using System.IO;

namespace FileDataReaderBGService.Common;

public static class Constants
{
    public const string SQL_LITE_DATA_SOURCE = "Data Source=SmartMovesLab.db";

    private static readonly string BASE_DIRECTORY = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

    public static readonly string DIRECTORY_DATA_FILE = Path.Combine(BASE_DIRECTORY, "DATA_FILES");

    public static readonly string DIRECTORY_PATH_IN_PROCESS = Path.Combine(DIRECTORY_DATA_FILE, "IN_PROCESS");
    public static readonly string DIRECTORY_PATH_COMPLETED = Path.Combine(DIRECTORY_DATA_FILE, "COMPLETED");

    // File Data index
    public const int ENGINESTATE_INDEX = 0;
    public const int VIN_INDEX = 1;
    public const int RPM_INDEX = 2;
    public const int SPEED_INDEX = 3;
    public const int ODOMETER_INDEX = 4;
    public const int TRIPDISTANCE_INDEX = 5;
    public const int LATITUDE_INDEX = 11;
    public const int LONGTITUDE_INDEX = 12;

}
