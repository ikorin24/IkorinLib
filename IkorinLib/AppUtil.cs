using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace IkorinLib
{
    public static class AppUtil
    {
        /// <summary>実行ファイルのフルパスを取得します</summary>
        /// <returns>実行ファイルのフルパス</returns>
        public static string GetExePath()
        {
            return Assembly.GetEntryAssembly().Location;
        }

        /// <summary>実行ファイルのあるディレクトリを取得します</summary>
        /// <returns>実行ファイルのディレクトリ</returns>
        public static string GetExeDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        }

        /// <summary>実行ファイルのファイル名を取得します</summary>
        /// <returns>実行ファイルのファイル名</returns>
        public static string GetExeName()
        {
            return Path.GetFileName(Assembly.GetEntryAssembly().Location);
        }

        /// <summary>実行ファイルのファイル名(拡張子なし)を取得します</summary>
        /// <returns>実行ファイルのファイル名(拡張子なし)</returns>
        public static string GetExeNameWithoutExtension()
        {
            return Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location);
        }
    }
}
