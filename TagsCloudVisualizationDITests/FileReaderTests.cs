﻿using FluentAssertions;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Text;
using TagsCloudVisualizationDI;
using TagsCloudVisualizationDI.AnalyzedTextReader;

namespace TagsCloudVisualizationDITests
{
    [TestFixture]
    public class FileReaderTests
    {
        [Test]
        public void ShouldNotThrowExceptionOnCoerrectPath()
        {
            var savePath = Path.GetDirectoryName(typeof(Program).Assembly.Location) + "\\ex1.TXT";
            var fileReader = new DefaultAnalyzedTextFileReader(savePath, Encoding.UTF8);
            Action read = () => fileReader.ReadText().GetValueOrThrow();
            read.Should().NotThrow();
        }

        [Test]
        public void ShouldThrowExceptionIfPathNotCorrect()
        {
            var savePath = Path.GetDirectoryName(typeof(Program).Assembly.Location) + "abraccadabras";
            var fileReader = new DefaultAnalyzedTextFileReader(savePath, Encoding.UTF8);
            Action read = () => fileReader.ReadText().GetValueOrThrow();
            read.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void ShouldBeCorrectCntOfLines()
        {
            var savePath = Path.GetDirectoryName(typeof(Program).Assembly.Location) + "\\ex1.TXT";
            var fileReader = new DefaultAnalyzedTextFileReader(savePath, Encoding.UTF8);
            var lines = fileReader.ReadText();
            lines.GetValueOrThrow().Count().Should().Be(8);
        }
    }
}
