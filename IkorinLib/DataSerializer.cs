using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace IkorinLib
{
    /// <summary>Xmlシリアライザクラス</summary>
    public class DataSerializer
    {
        protected Encoding _encoding = Encoding.UTF8;

        /// <summary>xmlシリアライズを実行します</summary>
        /// <typeparam name="T">対象の型</typeparam>
        /// <param name="path">ファイルパス</param>
        /// <param name="data">シリアライズ対象のオブジェクト</param>
        /// <returns>シリアライズに成功したか</returns>
        public bool Serialize<T>(string path, T data)
        {
            ThrowException.IfNullArg(path, nameof(path));

            var ws = new XmlWriterSettings();
            ws.Encoding = _encoding;
            ws.Indent = true;
            ws.IndentChars = "  ";
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            try {
                using(var stream = File.Open(path, FileMode.OpenOrCreate))
                using(var writer = XmlWriter.Create(stream, ws)) {
                    var serializer = new XmlSerializer(typeof(T), typeof(T).GetNestedTypes());
                    serializer.Serialize(writer, data, ns);
                    return true;
                }
            }
            catch(Exception) {
                return false;
            }
        }

        /// <summary>xmlデシリアライズを実行します</summary>
        /// <typeparam name="T">対象の型</typeparam>
        /// <param name="path">ファイルパス</param>
        /// <param name="data">デシリアライズ対象</param>
        /// <returns>デシリアライズに成功したか</returns>
        public bool Deserialize<T>(string path, out T data)
        {
            if(!File.Exists(path)) {
                data = default(T);
                return false;
            }
            try {
                using(var stream = File.Open(path, FileMode.Open))
                using(var reader = XmlReader.Create(stream)) {
                    var serializer = new XmlSerializer(typeof(T),typeof(T).GetNestedTypes());
                    data = (T)serializer.Deserialize(reader);
                    return true;
                }
            }
            catch(Exception) {
                data = default(T);
                return false;
            }
        }
    }
}
