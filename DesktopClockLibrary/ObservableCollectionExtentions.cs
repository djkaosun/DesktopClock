using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DesktopClock.Library
{
    /// <summary>
    /// ObservableCollection&lt;KeyValuePair&lt;TKey, TValue&gt;&gt; をディクショナリ的に使うための拡張メソッド。
    /// </summary>
    public static class ObservableCollectionExtentions
    {
        private const string ARGUMENT_NULL_EXCEPTION_MESSAGE = "Value cannot be null. (Parameter '{0}')";
        private const string KEY_NOT_FOUND_EXCEPTION_MESSAGE = "The given key '{0}' was not present in the dictionary.";
        private const string ARGUMENT_EXCEPTION_MESSAGE = "An item with the same key has already been added. Key: {0}";

        /// <summary>
        /// キーに対応する値を取得します。(インデクサーの代替)
        /// </summary>
        /// <param name="observableCollection">拡張メソッドの基となるオブジェクト。</param>
        /// <param name="key">キー。</param>
        /// <returns>対応する値。</returns>
        public static TValue Get<TKey, TValue>(this ObservableCollection<KeyValuePair<TKey, TValue>> observableCollection, TKey key)
        {
            if (key == null) throw new ArgumentNullException(String.Format(ARGUMENT_NULL_EXCEPTION_MESSAGE, nameof(key)));

            foreach (var keyValuePair in observableCollection)
            {
                if (keyValuePair.Key.Equals(key)) return keyValuePair.Value;
            }
            throw new KeyNotFoundException(String.Format(KEY_NOT_FOUND_EXCEPTION_MESSAGE, key));
        }

        /// <summary>
        /// キーが既に存在する場合は更新、存在しない場合は追加します。(インデクサーの代替)
        /// </summary>
        /// <param name="observableCollection">拡張メソッドの基となるオブジェクト。</param>
        /// <param name="key">キー。</param>
        /// <param name="value">値。</param>
        public static void AddOrUpdate<TKey, TValue>(this ObservableCollection<KeyValuePair<TKey, TValue>> observableCollection, TKey key, TValue value)
        {
            if (key == null) throw new ArgumentNullException(String.Format(ARGUMENT_NULL_EXCEPTION_MESSAGE, nameof(key)));

            foreach (var keyValuePair in observableCollection)
            {
                if (keyValuePair.Key.Equals(key))
                {
                    observableCollection.Remove(keyValuePair);
                    break;
                }
            }
            observableCollection.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        /// <summary>
        /// キーと値のペアを追加します。
        /// </summary>
        /// <param name="observableCollection">拡張メソッドの基となるオブジェクト。</param>
        /// <param name="key">キー。</param>
        /// <param name="value">値。</param>
        public static void Add<TKey, TValue>(this ObservableCollection<KeyValuePair<TKey, TValue>> observableCollection, TKey key, TValue value)
        {
            if (key == null) throw new ArgumentNullException(String.Format(ARGUMENT_NULL_EXCEPTION_MESSAGE, nameof(key)));

            if (ContainsKey(observableCollection, key))
            {
                throw new ArgumentException(String.Format(ARGUMENT_EXCEPTION_MESSAGE, key));
            }
            observableCollection.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        /// <summary>
        /// キーに対応する値を更新します。
        /// </summary>
        /// <param name="observableCollection">拡張メソッドの基となるオブジェクト。</param>
        /// <param name="key">キー。</param>
        /// <param name="value">新しい値。</param>
        public static void Update<TKey, TValue>(this ObservableCollection<KeyValuePair<TKey, TValue>> observableCollection, TKey key, TValue value)
        {
            if (key == null) throw new ArgumentNullException(String.Format(ARGUMENT_NULL_EXCEPTION_MESSAGE, nameof(key)));

            foreach (var keyValuePair in observableCollection)
            {
                if (keyValuePair.Key.Equals(key))
                {
                    observableCollection.Remove(keyValuePair);
                    observableCollection.Add(new KeyValuePair<TKey, TValue>(key, value));
                    return;
                }
            }
            throw new KeyNotFoundException(String.Format(KEY_NOT_FOUND_EXCEPTION_MESSAGE, key));
        }

        /// <summary>
        /// キーが含まれるか判断します。
        /// </summary>
        /// <param name="observableCollection">拡張メソッドの基となるオブジェクト。</param>
        /// <param name="key">キー。</param>
        /// <returns>キーが含まれる場合 true。含まれない場合は false。</returns>
        public static bool ContainsKey<TKey,TValue>(this ObservableCollection<KeyValuePair<TKey, TValue>> observableCollection, TKey key)
        {
            if (key == null) throw new ArgumentNullException(String.Format(ARGUMENT_NULL_EXCEPTION_MESSAGE, nameof(key)));

            foreach (var keyValuePair in observableCollection)
            {
                if (keyValuePair.Key.Equals(key)) return true;
            }
            return false;
        }

        /// <summary>
        /// 値が含まれるか判断します。
        /// </summary>
        /// <param name="observableCollection">拡張メソッドの基となるオブジェクト。</param>
        /// <param name="value">値。</param>
        /// <returns>値が含まれる場合 true。含まれない場合は false。</returns>
        public static bool ContainsValue<TKey,TValue>(this ObservableCollection<KeyValuePair<TKey, TValue>> observableCollection, TValue value)
        {
            foreach (var keyValuePair in observableCollection)
            {
                if (keyValuePair.Value == null)
                {
                    if (value == null) return true; 
                }
                else
                {
                    if (keyValuePair.Value.Equals(value)) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// キーに対応するキー/値ペアを削除します。
        /// </summary>
        /// <param name="observableCollection">拡張メソッドの基となるオブジェクト。</param>
        /// <param name="key">キー。</param>
        /// <returns>削除された場合 true。削除されなかった場合は false。</returns>
        public static bool Remove<TKey, TValue>(this ObservableCollection<KeyValuePair<TKey, TValue>> observableCollection, TKey key)
        {
            if (key == null) throw new ArgumentNullException(String.Format(ARGUMENT_NULL_EXCEPTION_MESSAGE, nameof(key)));

            foreach (var keyValuePair in observableCollection)
            {
                if (keyValuePair.Key.Equals(key))
                {
                    observableCollection.Remove(keyValuePair);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// キーに対応するキー/値ペアを削除します。削除する対象が見つかったらその値を value パラメーターにコピーします。
        /// </summary>
        /// <param name="observableCollection">拡張メソッドの基となるオブジェクト。</param>
        /// <param name="key">キー。</param>
        /// <param name="value">削除された値。</param>
        /// <returns>削除された場合 true。削除されなかった場合は false。</returns>
        public static bool Remove<TKey, TValue>(this ObservableCollection<KeyValuePair<TKey, TValue>> observableCollection, TKey key, out TValue value)
        {
            if (key == null) throw new ArgumentNullException(String.Format(ARGUMENT_NULL_EXCEPTION_MESSAGE, nameof(key)));

            foreach (var keyValuePair in observableCollection)
            {
                if (keyValuePair.Key.Equals(key))
                {
                    value = keyValuePair.Value;
                    observableCollection.Remove(keyValuePair);
                    return true;
                }
            }

            value = default;
            return false;
        }
    }
}
