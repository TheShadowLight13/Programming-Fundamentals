using System;

class TheaThePhotographer
{
    static void Main()
    {

        long picturesCount = long.Parse(Console.ReadLine());
        long filterTime = long.Parse(Console.ReadLine());
        double filterFactorPercent = double.Parse(Console.ReadLine()) / 100;
        long uploadTime = long.Parse(Console.ReadLine());

        long picturesFilterTime = picturesCount * filterTime;
        long filteredPictures = (long)Math.Ceiling(picturesCount * filterFactorPercent);
        long filteredPicturesUploadTime = filteredPictures * uploadTime;
        long totalTime = picturesFilterTime + filteredPicturesUploadTime;

        TimeSpan resultTime = TimeSpan.FromSeconds(totalTime);

        string finalStr = string.Format("{0}:{1}:{2}:{3}",
            resultTime.Days,
            resultTime.Hours.ToString().PadLeft(2, '0'),
            resultTime.Minutes.ToString().PadLeft(2, '0'),
            resultTime.Seconds.ToString().PadLeft(2, '0'));

        Console.WriteLine(finalStr);
    }
}

