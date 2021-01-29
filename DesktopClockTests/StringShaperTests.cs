using System;
using DesktopClock.Library;
using Xunit;
using DesktopClockTests.FakeClasses;
using DesktopClockTests.TestDatas;

namespace DesktopClockTests
{
    public class StringShaperTests
    {
        [Fact]
        public void InsertSpace_Null_ReturnsNull()
        {
            // arrange

            // act
            var actual = StringShaper.InsertSpace(null);

            // assert
            Assert.Null(actual);
        }

        [Fact]
        public void InsertSpace_EmptyString_ReturnsEmptyString()
        {
            // arrange

            // act
            var actual = StringShaper.InsertSpace(String.Empty);

            // assert
            Assert.Equal(String.Empty, actual);
        }

        [Fact]
        public void InsertSpace_OneByteCharAndMultiByteCharMixed_ReturnsSpaceInsertedString()
        {
            // arrange

            // act
            var actual1 = StringShaper.InsertSpace("aあ");
            var actual2 = StringShaper.InsertSpace("あa");
            var actual3 = StringShaper.InsertSpace("aあa");
            var actual4 = StringShaper.InsertSpace("あaあ");

            // assert
            Assert.Equal("a あ", actual1);
            Assert.Equal("あ a", actual2);
            Assert.Equal("a あ a", actual3);
            Assert.Equal("あ a あ", actual4);
        }

        [Fact]
        public void InsertSpace_NotMixed_ReturnsSameString()
        {
            // arrange

            // act
            var actual1 = StringShaper.InsertSpace("a");
            var actual2 = StringShaper.InsertSpace("あ");

            // assert
            Assert.Equal("a", actual1);
            Assert.Equal("あ", actual2);
        }

        [Fact]
        public void InsertSpace_AlreadyIncertedSpaceBetweenMixed_ReturnsSameString()
        {
            // arrange

            // act
            var actual1 = StringShaper.InsertSpace("a あ");
            var actual2 = StringShaper.InsertSpace("あ a");
            var actual3 = StringShaper.InsertSpace("a\tあ a");
            var actual4 = StringShaper.InsertSpace("あ\ta あ");

            // assert
            Assert.Equal("a あ", actual1);
            Assert.Equal("あ a", actual2);
            Assert.Equal("a\tあ a", actual3);
            Assert.Equal("あ\ta あ", actual4);
        }

        [Fact]
        public void InsertSpace_CustomSpaceCharsWasGiven_ReturnsSameString()
        {
            // arrange

            // act
            var actual1 = StringShaper.InsertSpace("a、あ", new char[] { '、' });
            var actual2 = StringShaper.InsertSpace("あ、a", new char[] { '、' });

            // assert
            Assert.Equal("a、あ", actual1);
            Assert.Equal("あ、a", actual2);
        }

        [Fact]
        public void InsertSpace_ExistSpaceAtStartAndEndOnString_ReturnsSameString()
        {
            // arrange

            // act
            var actual1 = StringShaper.InsertSpace(" a ");
            var actual2 = StringShaper.InsertSpace(" あ ");

            // assert
            Assert.Equal(" a ", actual1);
            Assert.Equal(" あ ", actual2);
        }
    }
}
