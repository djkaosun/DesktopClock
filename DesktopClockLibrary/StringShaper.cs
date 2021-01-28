using System;
using System.Text;

namespace DesktopClock.Library
{
    /// <summary>
    /// 文字列を成型する静的クラスです。
    /// </summary>
    public static class StringShaper
    {
        private const char ASCII_BEGIN = '\u0000';
        private const char ASCII_END = '\u007F';
        private static readonly char[] SPACE_CHAR = new char[]{ ' ', '\t' };

        /// <summary>
        /// 全角と半角の境目に半角スペースを挿入します。
        /// </summary>
        /// <param name="messageString">元の文字列。</param>
        /// <param name="additionalSpaseChars">スペース扱いする追加の文字。指定しない場合、半角スペースおよびタブがスペース扱いされます。</param>
        /// <returns>半角スペースを挿入した文字列。</returns>
        public static string InsertSpace(string messageString, char[] additionalSpaseChars = null)
        {
            if (messageString == null) return null;
            if (messageString.Length == 0) return String.Empty;

            var prevIsASCII = true;
            var prevIsSpace = true;
            var strBuilder = new StringBuilder(messageString, messageString.Length);
            for (var i = 0; i < strBuilder.Length; i++)
            {
                var c = strBuilder[i];
                if (IsASCII(c))
                {
                    if (IsSpace(c, additionalSpaseChars))
                    {
                        prevIsSpace = true;
                    }
                    else
                    {
                        if (!prevIsASCII && !prevIsSpace)
                        {
                            strBuilder.Insert(i, ' ');
                            i++;
                        }
                        prevIsSpace = false;
                    }
                    prevIsASCII = true;
                }
                else
                {
                    if (IsSpace(c, additionalSpaseChars))
                    {
                        prevIsSpace = true;
                    }
                    else
                    {
                        if (prevIsASCII && !prevIsSpace)
                        {
                            strBuilder.Insert(i, ' ');
                            i++;
                        }
                        prevIsSpace = false;
                    }
                    prevIsASCII = false;
                }
            }

            /*
            while (strBuilder.Length > 0
                    && strBuilder[strBuilder.Length - 1] == ' '
                    && strBuilder[strBuilder.Length - 1] == '\t')
            {
                strBuilder.Remove(strBuilder.Length - 1, 1);
            }

            while (strBuilder.Length > 0 && strBuilder[0] == ' ' && strBuilder[0] == '\t')
            {
                strBuilder.Remove(0, 1);
            }
            */

            return strBuilder.ToString();
        }

        private static bool IsASCII(char c)
        {
            return c >= ASCII_BEGIN && c <= ASCII_END;
        }

        private static bool IsSpace(char c, char[] additionalSpaseChars)
        {
            foreach (var sc in SPACE_CHAR)
            {
                if (c == sc) return true;
            }

            if (additionalSpaseChars != null)
            {
                foreach (var sc in additionalSpaseChars)
                {
                    if (c == sc) return true;
                }
            }

            return false;
        }
    }
}
