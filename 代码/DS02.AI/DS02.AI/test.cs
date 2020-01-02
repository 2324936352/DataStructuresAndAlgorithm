using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DS02.AI
{
    //class Program
    //{
    //    static void Main()
    //    {

    //        var keyString = "人工智能";
    //        TestReadingFile(keyString);
    //        Console.WriteLine("======");
    //        TestStreamReaderEnumerable(keyString);
    //        Console.ReadKey();
    //    }


    //    /// <summary>
    //    /// 不使用自定义的迭代子检索指定的文本文件种，包含指定字符串的个数的方法
    //    /// </summary>
    //    /// <param name="keyString"></param>
    //    public static void TestReadingFile(string keyString)
    //    {
    //        var memoryBefore = GC.GetTotalMemory(true);

    //        StreamReader sr;
    //        try
    //        {
    //            sr = File.OpenText("c:\\temp\\tempFile.txt");

    //        }
    //        catch (FileNotFoundException)
    //        {
    //            Console.WriteLine("@这个例子需要一个txt文件");
    //            return;
    //        }

    //        var fileContents = new List<string>();//将文本内容添加到一个List<string>变量
    //        while (!sr.EndOfStream)
    //        {
    //            fileContents.Add(sr.ReadLine());
    //        }
    //        //检查目标文本（字符串）
    //        var stringFound =
    //            from line in fileContents
    //            where line.Contains("人工智能")
    //            select line;

    //        sr.Close();
    //        Console.WriteLine("数量" + stringFound.Count());
    //        var memoryAfter = GC.GetTotalMemory(false); //检查不适用迭代子并将结果输出到控制台之后的内存用量.
    //        Console.WriteLine("不适用ITerator的内存用量=\t" + string.Format(((memoryAfter - memoryBefore) / 1000).ToString(), "n") + "kb");
    //        Console.WriteLine("文件名：" + sr);
    //        Console.WriteLine("关键词：" + keyString);

    //    }



    //    /// <summary>
    //    /// 使用自定义的迭代子检索指定的文本文件种，包含指定字符串的个数的方法
    //    /// </summary>
    //    public static void TestStreamReaderEnumerable(string keyString)
    //    {
    //        IEnumerable<String> stringsFound;
    //        //使用StreamReaderEnumerable 打开一个示例文件，检索对应的字符串
    //        try
    //        {
    //            stringsFound =
    //                from line in new StreamReaderEnumerable("c:\\temp\\tempFile.txt")
    //                where line.Contains("人工智能")
    //                select line;
    //            Console.WriteLine("数量：" + stringsFound.Count());
    //        }
    //        catch (FileNotFoundException)
    //        {
    //            Console.WriteLine("@这个例子需要一个txt文件");
    //            return;
    //        }
    //    }



    //    /// <summary>
    //    /// 一个定制的实现IEnumerable<T>的类,为此，还需要实现相应的
    //    /// IEnumerable 和 IEnumberator<T>
    //    /// </summary>
    //    public class StreamReaderEnumerable : IEnumerable<string>
    //    {
    //        private string _filePath;
    //        public StreamReaderEnumerable(string filePath)
    //        {
    //            _filePath = filePath;
    //        }
    //        //必须实现 GetEnumerator,用于返回一个新的StreamReaderEnumerator.
    //        public IEnumerator<string> GetEnumerator() => new StreamReaderEnumerator(_filePath);

    //        //同时必须实现 IEnumerable.GetEnumerator,但当成一个私有方法实现
    //        private IEnumerator GetEnumerator1() => this.GetEnumerator();

    //        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();




    //        /// <summary>
    //        /// 在实现IEnumerable<T>时，必须实现IEnumerator<T>,范例代码中，遍历文件内容时，每一行一次
    //        /// 实现IEnumerable<T>,还需要实现IEnumerator和析构函数IDisposable
    //        /// </summary>
    //        public class StreamReaderEnumerator : IEnumerator<string>
    //        {
    //            private StreamReader _sr;
    //            public StreamReaderEnumerator(string filePath)
    //            {
    //                _sr = new StreamReader(filePath);
    //            }
    //            private string _current;
    //            //实现 IEnumerator<T>().Current 公开属性，但实现所必须的 IEnumerator.Current 则为私有属性            


    //            public string Current
    //            {
    //                get
    //                {
    //                    if (_sr == null || _current == null)
    //                        throw new InvalidOperationException();
    //                    return _current;
    //                }
    //            }

    //            private object Current1 => this.Current;
    //            object IEnumerator.Current => Current1;

    //            //实现IEnumerator所必须的MoveNext 和 Reset。
    //            public bool MoveNext()
    //            {
    //                _current = _sr.ReadLine();
    //                if (_current == null)
    //                    return false;
    //                return true;
    //            }
    //            public void Reset()
    //            {
    //                _sr.DiscardBufferedData();
    //                _sr.BaseStream.Seek(0, SeekOrigin.Begin);
    //                _current = null;
    //            }
    //            //实现构造函数，必须的
    //            private bool disposedValue = false;
    //            public void Dispose()
    //            {
    //                Dispose(true);
    //                GC.SuppressFinalize(this);
    //            }
    //            protected virtual void Dispose(bool disposing)
    //            {
    //                if (!this.disposedValue)
    //                {
    //                    if (disposing) { }//析构所需要的资源
    //                    _current = null;
    //                    if (_sr != null)
    //                    {
    //                        _sr.Close();
    //                        _sr.Dispose();
    //                    }
    //                }
    //                this.disposedValue = true;
    //            }
    //            ~StreamReaderEnumerator() { Dispose(false); }
    //        }
    //    }
    //}
}
