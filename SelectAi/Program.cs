using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SelectAi
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            var keyString = "人工智能";
            TestReadingFile(keyString);
            Console.WriteLine("---");
            TestStreamReaderEnumerable(keyString);
            Console.ReadKey();

        }

        private static void TestStreamReaderEnumerable(string keyString)
        {
            var memoryBefore = GC.GetTotalMemory(true); // tit#iE1tFZ .#tép#F
            IEnumerable<string> stringsFound;

            try
            {
                stringsFound =
                    from line in new StreamReaderEbumerable(@" ")
                    where line.Contains("人工智能")
                    select line;
                Console.WriteLine("数量" + stringsFound.Count());
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(@"没有文件");
                return;
            }
            var memoryAfter = GC.GetTotalMemory(false);
            Console.WriteLine("使用 Iterator 的内存用量 = \t" + string.Format(((memoryAfter - memoryBefore) / 1000).ToString(), "n") + "kb");
        }

        private static void TestReadingFile(string keyString)
        {
            var memoryBefore = GC.GetTotalMemory(true);
            StreamReader sr;
            try
            {
                sr = File.OpenText("   ");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(@"路径错误");
                return;

            }
            var fileContens = new List<string>();
            while (!sr.EndOfStream)
            {
                fileContens.Add(sr.ReadLine());
            }
            //检索目标文本（字符串）
            var stringFound =
                from line in fileContens
                where line.Contains("人工智能")
                select line;
            sr.Close();
            Console.WriteLine("数量:" + stringFound.Count());

            var memoryAfter = GC.GetTotalMemory(false);
            Console.WriteLine("不使用 Iterator 的内存用量 = \t" + string.Format(((memoryAfter - memoryBefore) / 1000).ToString(), "n") + "kb");
        }

        private class StreamReaderEbumerable
        {
            private string v;

            public StreamReaderEbumerable(string v)
            {
                this.v = v;
            }
        }
    }
}
