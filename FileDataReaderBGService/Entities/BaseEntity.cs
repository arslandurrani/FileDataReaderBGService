using System;

namespace FileDataReaderBGService.Entities;

public class BaseEntity
{
    public int Id { get; set; }

    public int Enginestate { get; set; }

    public string? VIN { get; set; }

    public double RPM { get; set; }

    public double Speed { get; set; }

    public double Odometer { get; set; }

    public double TripDistance { get; set; }

    public double Latitude { get; set; }

    public double Longtitude { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}
