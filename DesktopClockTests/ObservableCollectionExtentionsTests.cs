using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DesktopClock.Library;
using Xunit;
using DesktopClockTests.FakeClasses;
using DesktopClockTests.TestDatas;

namespace DesktopClockTests
{
    public class ObservableCollectionExtentionsTests
    {
        #region GetValue

        [Fact]
        public void GetValue_KeyIsNull_ThrowsArgumentNullException()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            collection.Add(key, null);

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => {
                collection.GetValue(null);
            });
        }

        [Fact]
        public void GetValue_ContainsKeyAndValueIsNull_ReturnsNull()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            collection.Add(key, null);

            // act
            var actual = collection.GetValue(key);

            // assert
            Assert.Null(actual);
        }

        [Fact]
        public void GetValue_ContainsKey_ReturnsValue()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            var value = new Object();
            collection.Add(key, value);

            // act
            var actual = collection.GetValue(key);

            // assert
            Assert.Same(value, actual);
        }

        [Fact]
        public void GetValue_DoesNotContainKey_ThrowsKeyNotFoundException()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            collection.Add(key, null);

            // act
            // assert
            Assert.Throws<KeyNotFoundException>(() => {
                collection.GetValue(new Object());
            });
        }

        #endregion

        #region UpdateValue

        [Fact]
        public void UpdateValue_KeyIsNull_ThrowsArgumentNullException()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            collection.Add(key, null);

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => {
                collection.UpdateValue(null, null);
            });
        }

        [Fact]
        public void UpdateValue_DoesNotContainKey_ThrowsKeyNotFoundException()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            collection.Add(key, null);

            // act
            // assert
            Assert.Throws<KeyNotFoundException>(() => {
                collection.UpdateValue(new Object(), null);
            });
        }

        [Fact]
        public void UpdateValue_ContainsKeyAndNewValueIsNull_ReturnsNull()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            var oldvalue = new Object();
            collection.Add(key, oldvalue);

            // act
            collection.UpdateValue(key, null);
            var actual = collection.GetValue(key);

            // assert
            Assert.Null(actual);
        }

        [Fact]
        public void UpdateValue_ContainsKeyAndNewValueIsNotNull_ReturnsValue()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            var oldvalue = new Object();
            var newvalue = new Object();
            collection.Add(key, oldvalue);

            // act
            collection.UpdateValue(key, newvalue);
            var actual = collection.GetValue(key);

            // assert
            Assert.Same(newvalue, actual);
        }

        #endregion

        #region Add

        [Fact]
        public void Add_KeyIsNull_ThrowsArgumentNullException()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => {
                collection.Add(null, null);
            });
        }

        [Fact]
        public void Add_ContainsKey_ThrowsArgumentException()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            collection.Add(key, null);

            // act
            // assert
            Assert.Throws<ArgumentException>(() => {
                collection.Add(key, null);
            });
        }

        [Fact]
        public void Add_DoesNotContainKeyAndValueIsNull_ReturnsNull()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();

            // act
            collection.Add(key, null);
            var actual = collection.GetValue(key);

            // assert
            Assert.Null(actual);
        }

        [Fact]
        public void Add_DoesNotContainKeyAndValueIsNotNull_ReturnsValue()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            var value = new Object();

            // act
            collection.Add(key, value);
            var actual = collection.GetValue(key);

            // assert
            Assert.Same(value, actual);
        }


        #endregion

        #region AddOrUpdate

        [Fact]
        public void AddOrUpdate_KeyIsNull_ThrowsArgumentNullException()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => {
                collection.AddOrUpdate(null, null);
            });
        }

        [Fact]
        public void AddOrUpdate_ContainsKeyAndValueIsNull_UpdatesValueToNull()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            var oldvalue = new Object();
            collection.Add(key, oldvalue);

            // act
            collection.AddOrUpdate(key, null);
            var actual = collection.GetValue(key);

            // assert
            Assert.Null(actual);
        }

        [Fact]
        public void AddOrUpdate_ContainsKeyAndValueIsNotNull_UpdatesValue()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            var oldvalue = new Object();
            var newvalue = new Object();
            collection.Add(key, oldvalue);

            // act
            collection.AddOrUpdate(key, newvalue);
            var actual = collection.GetValue(key);

            // assert
            Assert.Same(newvalue, actual);
        }

        [Fact]
        public void AddOrUpdate_DoesNotContainKeyAndValueIsNull_ReturnsNull()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var oldkey = new Object();
            var oldvalue = new Object();
            var newkey = new Object();
            collection.Add(oldkey, oldvalue);

            // act
            collection.AddOrUpdate(newkey, null);
            var actual1 = collection.GetValue(newkey);
            var actual2 = collection.GetValue(oldkey);

            // assert
            Assert.Null(actual1);
            Assert.Same(oldvalue, actual2);
        }

        [Fact]
        public void AddOrUpdate_DoesNotContainKeyAndValueIsNotNull_ReturnsValue()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var oldkey = new Object();
            var oldvalue = new Object();
            var newkey = new Object();
            var newvalue = new Object();
            collection.Add(oldkey, oldvalue);

            // act
            collection.AddOrUpdate(newkey, newvalue);
            var actual1 = collection.GetValue(newkey);
            var actual2 = collection.GetValue(oldkey);

            // assert
            Assert.Same(newvalue, actual1);
            Assert.Same(oldvalue, actual2);
        }


        #endregion

        #region ContainsKey

        [Fact]
        public void ContainsKey_KeyIsNull_ThrowsArgumentNullException()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => {
                collection.ContainsKey(null);
            });
        }

        [Fact]
        public void ContainsKey_DoesNotContainKey_ReturnsFalse()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            collection.Add(new Object(), new Object());

            // act
            var actual = collection.ContainsKey(new Object());

            // assert
            Assert.False(actual);
        }

        [Fact]
        public void ContainsKey_ContainsKey_ReturnsTrue()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            collection.Add(key, null);

            // act
            var actual = collection.ContainsKey(key);

            // assert
            Assert.True(actual);
        }

        #endregion

        #region ContainsValue

        [Fact]
        public void ContainsKey_ValueIsNullAndDoesNotContainNull_ReturnsFalse()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();

            // act
            var actual = collection.ContainsValue(null);

            // assert
            Assert.False(actual);
        }

        [Fact]
        public void ContainsKey_ValueIsNullAndContainsNull_ReturnsTrue()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            collection.Add(new Object(), null);

            // act
            var actual = collection.ContainsValue(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ContainsKey_DoesNotContainValue_ReturnsFalse()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            collection.Add(new Object(), new Object());

            // act
            var actual = collection.ContainsValue(new Object());

            // assert
            Assert.False(actual);
        }

        [Fact]
        public void ContainsKey_ContainsValue_ReturnsTrue()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            var value = new Object();
            collection.Add(key, value);

            // act
            var actual = collection.ContainsValue(value);

            // assert
            Assert.True(actual);
        }


        #endregion

        #region Remove

        [Fact]
        public void Remove_KeyIsNull_ThrowsArgumentNullException()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => {
                collection.Remove(null);
            });
        }

        [Fact]
        public void Remove_DoesNotContainKey_ReturnsFalseAndCollectionNotChanged()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            var oldvalue = new Object();
            collection.Add(key, oldvalue);

            // act
            var actual1 = collection.Remove(new Object());
            var actual2 = collection.ContainsKey(key);

            // assert
            Assert.False(actual1);
            Assert.True(actual2);
        }

        [Fact]
        public void Remove_ContainsKey_ReturnsTrueAndRemoved()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            var oldvalue = new Object();
            collection.Add(key, oldvalue);

            // act
            collection.UpdateValue(key, null);
            var actual1 = collection.Remove(key);
            var actual2 = collection.ContainsKey(key);

            // assert
            Assert.True(actual1);
            Assert.False(actual2);
        }

        #endregion

        #region Remove (and get removed value)

        [Fact]
        public void Remove2_KeyIsNull_ThrowsArgumentNullException()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => {
                collection.Remove(null, out object value);
            });
        }

        [Fact]
        public void Remove2_DoesNotContainKey_ReturnsFalseAndCollectionNotChangedAndOutsDefaultValue()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            var oldvalue = new Object();
            collection.Add(key, oldvalue);

            // act
            var actual1 = collection.Remove(new Object() , out object actual2);
            var actual3 = collection.ContainsKey(key);

            // assert
            Assert.False(actual1);
            Assert.Same(default, actual2);
            Assert.True(actual3);
        }

        [Fact]
        public void Remove2_ContainsKey_ReturnsTrueAndRemovedAndOutsOldValue()
        {
            // arrange
            var collection = new ObservableCollection<KeyValuePair<object, object>>();
            var key = new Object();
            var oldvalue = new Object();
            collection.Add(key, oldvalue);

            // act
            var actual1 = collection.Remove(key, out object actual2);
            var actual3 = collection.ContainsKey(key);

            // assert
            Assert.True(actual1);
            Assert.Same(oldvalue, actual2);
            Assert.False(actual3);
        }


        #endregion
    }
}
