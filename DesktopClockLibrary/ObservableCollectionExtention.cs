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
        /// <summary>
        /// キーに対応する値を取得します。(インデクサーの代替)
        /// </summary>
        /// <param name="observableCollection">拡張メソッドの基となるオブジェクト。</param>
        /// <param name="key">キー。</param>
        /// <returns>対応する値。</returns>
        public static TValue GetValue<TKey, TValue>(this ObservableCollection<KeyValuePair<TKey, TValue>> observableCollection, TKey key)
        {
            foreach (var keyValuePair in observableCollection)
            {
                if (keyValuePair.Key.Equals(key)) return keyValuePair.Value;
            }
            throw new KeyNotFoundException("The given key '" + key + "' was not present in the dictionary.");
        }

        /// <summary>
        /// キーに対応する値を更新します。(インデクサーの代替)
        /// </summary>
        /// <param name="observableCollection">拡張メソッドの基となるオブジェクト。</param>
        /// <param name="key">キー。</param>
        /// <param name="value">新しい値。</param>
        public static void UpdateValue<TKey, TValue>(this ObservableCollection<KeyValuePair<TKey, TValue>> observableCollection, TKey key, TValue value)
        {
            foreach (var keyValuePair in observableCollection)
            {
                if (keyValuePair.Key.Equals(key))
                {
                    observableCollection.Remove(keyValuePair);
                    observableCollection.Add(new KeyValuePair<TKey, TValue>(key, value));
                    return;
                }
            }
            throw new KeyNotFoundException("The given key '" + key + "' was not present in the dictionary.");
        }

        /// <summary>
        /// キーと値のペアを追加します。
        /// </summary>
        /// <param name="observableCollection">拡張メソッドの基となるオブジェクト。</param>
        /// <param name="key">キー。</param>
        /// <param name="value">値。</param>
        public static void Add<TKey, TValue>(this ObservableCollection<KeyValuePair<TKey, TValue>> observableCollection, TKey key, TValue value)
        {
            if (ContainsKey(observableCollection, key))
            {
                throw new ArgumentException("An item with the same key has already been added. Key: " + key);
            }
            observableCollection.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        /// <summary>
        /// キーが既に存在する場合は更新、存在しない場合は追加します。
        /// </summary>
        /// <param name="observableCollection">拡張メソッドの基となるオブジェクト。</param>
        /// <param name="key">キー。</param>
        /// <param name="value">値。</param>
        public static void AddOrUpdate<TKey, TValue>(this ObservableCollection<KeyValuePair<TKey, TValue>> observableCollection, TKey key, TValue value)
        {
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
        /// キーが含まれるか判断します。
        /// </summary>
        /// <param name="observableCollection">拡張メソッドの基となるオブジェクト。</param>
        /// <param name="key">キー。</param>
        /// <returns>キーが含まれる場合 true。含まれない場合は false。</returns>
        public static bool ContainsKey<TKey,TValue>(this ObservableCollection<KeyValuePair<TKey, TValue>> observableCollection, TKey key)
        {
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
                if (keyValuePair.Value.Equals(value)) return true;
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
