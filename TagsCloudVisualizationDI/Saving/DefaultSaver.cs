﻿using System.Drawing.Imaging;
using System.IO;

namespace TagsCloudVisualizationDI.Saving
{
    public class DefaultSaver : ISaver
    {
        private string SavePath { get; }

        public DefaultSaver(string savePath, ImageFormat imageFormat)
        {
            SavePath = savePath + '.' + imageFormat;
        }

        public Result<string> GetSavePath()
        {
            var directorySavePath = SavePath.Substring(0, SavePath.LastIndexOf('\\') + 1);
            return (Directory.Exists(directorySavePath)
                ? SavePath
                : Result.Fail<string>($"pathToDirectory {directorySavePath}  is not exist"));
        }
    }
}
