using System;
using System.IO;
using System.Linq;

namespace TeamsRandomBackground
{
    class Program
    {
        static Random _rand = new Random();

        static void Main(string[] args)
        {
            string teamsUploadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Teams\Backgrounds\Uploads");

            string rotatorImagePath = Path.Combine(teamsUploadsPath, "zzzteamsbackgroundpicker.jpg");
            string rotatorThumbPath = Path.Combine(teamsUploadsPath, "zzzteamsbackgroundpicker_thumb.jpg");
            if (!File.Exists(rotatorThumbPath))
                File.Copy("zzzteamsbackgroundpicker_thumb.jpg", rotatorThumbPath);

            string[] imagePaths = Directory.GetFiles(teamsUploadsPath).Where(f => !f.Contains("_thumb") && f != rotatorImagePath).ToArray();

            int randomImageIndex = _rand.Next(imagePaths.Length);
            string randomImagePath = imagePaths[randomImageIndex];

            File.Copy(randomImagePath, rotatorImagePath, true);
        }
    }
}
