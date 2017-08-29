﻿using FileCurator.Formats.ICal;
using FileCurator.Tests.BaseClasses;
using System;
using System.IO;
using Xunit;

namespace FileCurator.Tests.Formats.ICalendar
{
    public class ICalReader : TestingDirectoryFixture
    {
        [Fact]
        public void Read()
        {
            var TestObject = new ICalendarReader();
            var Result = TestObject.Read(File.OpenRead("../../../TestData/TestICal.ics"));
            Assert.Equal(1, Result.AttendeeList.Count);
            Assert.Equal("EMPLOYEE-A@EXAMPLE.COM", Result.AttendeeList[0].EmailAddress);
            Assert.Equal(false, Result.Cancel);
            Assert.Equal("Project XYZ Review Meeting", Result.Content);
            Assert.Equal("Project XYZ Review Meeting", Result.Description);
            Assert.Equal(new DateTime(1998, 3, 12, 4, 30, 0), Result.EndTime);
            Assert.Equal("1CP Conference Room 4350", Result.Location);
            Assert.Equal("", Result.Meta);
            Assert.Equal("MRBIG@EXAMPLE.COM", Result.Organizer.EmailAddress);
            Assert.Equal(new DateTime(1998, 3, 12, 3, 30, 0), Result.StartTime);
            Assert.Equal("BUSY", Result.Status);
            Assert.Equal("XYZ Project Review", Result.Subject);
            Assert.Equal("XYZ Project Review", Result.Title);
        }
    }
}