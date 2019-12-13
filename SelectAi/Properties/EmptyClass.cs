using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace SelectAi.Properties
{
    public class EmptyClass
    {
       
            public static void TestReadingFile()
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
            public static void TestStreamReaderEnumerable()
            {
                var memoryBefore = GC.GetTotalMemory(true); // tit#iE1tFZ .#tép#F
                IEnumerable<string> stringsFound;

                try
                {
                    stringsFound =
                        from line in new StreamReaderEbumerable(@"c:ltempltempFile. txt")
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
        }
    }

