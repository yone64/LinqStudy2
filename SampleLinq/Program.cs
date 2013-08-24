using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SampleLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderBy();
        }

        #region select
        /// <summary>
        /// Select
        /// </summary>
        static void Select1()
        {
            var query = Enumerable.Range(1, 10).Select(x => x * x);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Select
        /// </summary>
        static void Select2()
        {
            var query = Enumerable.Range(1, 10).Select(x => DateTime.Now.AddDays(x));
            foreach (var item in query)
            {
                Console.WriteLine(item.ToString("yyyy/MM/dd"));
            }
        }

        /// <summary>
        /// Select
        /// </summary>
        static void Select3()
        {
            var query = "子丑寅卯辰巳午未申酉戌亥".Select((x, i) => new { x, i });

            foreach (var item in query)
            {
                Console.WriteLine((item.i + 1) + "番目は、" + item.x);
            }
        }
        #endregion

        #region selectmany
        static void SelectMany1()
        {
            var source = new[]
            {
                new {都道府県 = "京都府", 市 = new [] {"京都市","福知山市","舞鶴市","綾部市", "宇治市", "宮津市", "亀岡市", "城陽市", "向日市", "長岡京市", "八幡市", "京田辺市", "京丹後市", "南丹市", "木津川市"}},
                new {都道府県 = "大阪府", 市 = new [] {"大阪市","堺市","池田市","箕面市","豊中市", "茨木市","高槻市","吹田市","摂津市","枚方市","交野市","寝屋川市","守口市","門真市","四條畷市","大東市","東大阪市","八尾市","柏原市","和泉市","高石市","泉大津市","岸和田市","貝塚市","泉佐野市","泉南市","阪南市","松原市","羽曳野市","藤井寺市","富田林市","大阪狭山市","河内長野市",}},
                new {都道府県 = "兵庫県", 市 = new [] {"神戸市","尼崎市","西宮市","芦屋市","伊丹市", "宝塚市","川西市","三田市","明石市","加古川市","高砂市","西脇市","三木市","小野市","加西市","加東市","姫路市","相生市","たつの市","赤穂市","宍粟市","豊岡市","養父市","朝来市","篠山市","丹波市","洲本市","南あわじ市","淡路市",}},
            };

            var query = source.SelectMany(a => a.市);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        static void SelectMany2()
        {
            var source = new[]
            {
                new {都道府県 = "京都府", 市 = new [] {"京都市","福知山市","舞鶴市","綾部市", "宇治市", "宮津市", "亀岡市", "城陽市", "向日市", "長岡京市", "八幡市", "京田辺市", "京丹後市", "南丹市", "木津川市"}},
                new {都道府県 = "大阪府", 市 = new [] {"大阪市","堺市","池田市","箕面市","豊中市", "茨木市","高槻市","吹田市","摂津市","枚方市","交野市","寝屋川市","守口市","門真市","四條畷市","大東市","東大阪市","八尾市","柏原市","和泉市","高石市","泉大津市","岸和田市","貝塚市","泉佐野市","泉南市","阪南市","松原市","羽曳野市","藤井寺市","富田林市","大阪狭山市","河内長野市",}},
                new {都道府県 = "兵庫県", 市 = new [] {"神戸市","尼崎市","西宮市","芦屋市","伊丹市", "宝塚市","川西市","三田市","明石市","加古川市","高砂市","西脇市","三木市","小野市","加西市","加東市","姫路市","相生市","たつの市","赤穂市","宍粟市","豊岡市","養父市","朝来市","篠山市","丹波市","洲本市","南あわじ市","淡路市",}},
            };

            var query = source.SelectMany(a => a.市, (a, b) => a.都道府県 + b);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        static void SelectMany3()
        {
            var source = new[]
            {
                new {都道府県 = "京都府", 市 = new [] {"京都市","福知山市","舞鶴市","綾部市", "宇治市", "宮津市", "亀岡市", "城陽市", "向日市", "長岡京市", "八幡市", "京田辺市", "京丹後市", "南丹市", "木津川市"}},
                new {都道府県 = "大阪府", 市 = new [] {"大阪市","堺市","池田市","箕面市","豊中市", "茨木市","高槻市","吹田市","摂津市","枚方市","交野市","寝屋川市","守口市","門真市","四條畷市","大東市","東大阪市","八尾市","柏原市","和泉市","高石市","泉大津市","岸和田市","貝塚市","泉佐野市","泉南市","阪南市","松原市","羽曳野市","藤井寺市","富田林市","大阪狭山市","河内長野市",}},
                new {都道府県 = "兵庫県", 市 = new [] {"神戸市","尼崎市","西宮市","芦屋市","伊丹市", "宝塚市","川西市","三田市","明石市","加古川市","高砂市","西脇市","三木市","小野市","加西市","加東市","姫路市","相生市","たつの市","赤穂市","宍粟市","豊岡市","養父市","朝来市","篠山市","丹波市","洲本市","南あわじ市","淡路市",}},
            };

            var query = from a in source
                        from b in a.市
                        select a.都道府県 + b;

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        static void SelectMany4()
        {
            var query = from a in Enumerable.Range(1,9)
                        from b in Enumerable.Range(1, 9)
                        select "" + a + " × " + b + " = " + (a * b);

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
        #endregion

        #region where
        static void Where1()
        {
            var query = Enumerable.Range(1, 20).Where(i => i % 3 == 0);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

        }

        static void Where2()
        {
            var query = "子丑寅卯辰巳午未申酉戌亥".Where((x, i) => i % 2 == 1);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
        #endregion

        #region first / firstofdefault / single / singleordefault
        static void First1()
        {
            var val = Enumerable.Range(1, 20).Where(i => i % 3 == 0).First();
            Console.WriteLine(val);
        }

        static void First2()
        {
            var val = Enumerable.Range(1, 20).First(i => i % 3 == 0);
            Console.WriteLine(val);
        }

        static void First3()
        {
            var val = Enumerable.Range(1, 20).First(i => i % 29 == 0);
            Console.WriteLine(val);
        }

        static void FirstOrDefault1()
        {
            var val = Enumerable.Range(1, 20).FirstOrDefault(i => i % 29 == 0);
            Console.WriteLine(val);
        }

        static void Single1()
        {
            var val = Enumerable.Range(1, 20).Single(i => i % 13 == 0);
            Console.WriteLine(val);
        }

        static void Single2()
        {
            var val = Enumerable.Range(1, 20).Single(i => i % 7 == 0);
            Console.WriteLine(val);
        }

        static void Single3()
        {
            var val = Enumerable.Range(1, 20).Single(i => i % 23 == 0);
            Console.WriteLine(val);
        }

        static void SingleOrDefault1()
        {
            var val = Enumerable.Range(1, 20).SingleOrDefault(i => i % 23 == 0);
            Console.WriteLine(val);
        }

        static void SingleOrDefault2()
        {
            var val = Enumerable.Range(1, 20).SingleOrDefault(i => i % 3 == 0);
            Console.WriteLine(val);
        }
        #endregion

        #region take / takewhile / skip /skipwhile
        static void Take1()
        {
            var query = Enumerable.Range(1, 10).Take(3);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        static void TakeWhile1()
        {
            var query = Enumerable.Repeat(Enumerable.Range(1, 10), 2).SelectMany(a => a).TakeWhile(i => i < 7);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        static void Skip1()
        {
            var query = Enumerable.Range(1, 10).Skip(3);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        static void SkipWhile1()
        {
            var query = Enumerable.Repeat(Enumerable.Range(1, 10), 2).SelectMany(a => a).SkipWhile(i => i < 7);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        #endregion

        #region zip / concat / union / join / groupjoin
        static void Zip1()
        {
            var source1 = Enumerable.Repeat("甲乙丙丁戊己庚辛壬癸", 6).SelectMany(s => s);
            var source2 = Enumerable.Repeat("子丑寅卯辰巳午未申酉戌亥", 5).SelectMany(s => s);

            var query = source1.Zip(source2, (x, y) => "" + x + y);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        static void Concat1()
        {
            var source1 = new[] { "A", "B", "C", "D" };
            var source2 = new[] { "D", "E", "F", "G" };

            var query = source1.Concat(source2);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        static void Union1()
        {
            var source1 = new[] { "A", "B", "C", "D" };
            var source2 = new[] { "D", "E", "F", "G" };

            var query = source1.Union(source2);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        static void Join1()
        {
            var source1 = new[]
            {
                new { 都道府県コード = "25", 都道府県名 = "滋賀県"},
                new { 都道府県コード = "26", 都道府県名 = "京都府"},
                new { 都道府県コード = "27", 都道府県名 = "大阪府"},
                new { 都道府県コード = "28", 都道府県名 = "兵庫県"},
            };

            var source2 = new[]
            {
                new { 都道府県コード = "26", 市町村名 = "京都市"},
                new { 都道府県コード = "26", 市町村名 = "亀岡市"},
                new { 都道府県コード = "26", 市町村名 = "宇治市"},
                new { 都道府県コード = "27", 市町村名 = "大阪市"},
                new { 都道府県コード = "27", 市町村名 = "豊中市"},
                new { 都道府県コード = "27", 市町村名 = "堺市"},
                new { 都道府県コード = "28", 市町村名 = "神戸市"},
                new { 都道府県コード = "28", 市町村名 = "明石市"},
                new { 都道府県コード = "28", 市町村名 = "西宮市"},
                new { 都道府県コード = "29", 市町村名 = "奈良市"},
            };

            var query = source1.Join(source2, a => a.都道府県コード, b => b.都道府県コード, (a, b) => new { a.都道府県名, b.市町村名 });
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        static void GroupJoin1()
        {
            var source1 = new[]
            {
                new { 都道府県コード = "25", 都道府県名 = "滋賀県"},
                new { 都道府県コード = "26", 都道府県名 = "京都府"},
                new { 都道府県コード = "27", 都道府県名 = "大阪府"},
                new { 都道府県コード = "28", 都道府県名 = "兵庫県"},
            };

            var source2 = new[]
            {
                new { 都道府県コード = "26", 市町村名 = "京都市"},
                new { 都道府県コード = "26", 市町村名 = "亀岡市"},
                new { 都道府県コード = "26", 市町村名 = "宇治市"},
                new { 都道府県コード = "27", 市町村名 = "大阪市"},
                new { 都道府県コード = "27", 市町村名 = "豊中市"},
                new { 都道府県コード = "27", 市町村名 = "堺市"},
                new { 都道府県コード = "28", 市町村名 = "神戸市"},
                new { 都道府県コード = "28", 市町村名 = "明石市"},
                new { 都道府県コード = "28", 市町村名 = "西宮市"},
                new { 都道府県コード = "29", 市町村名 = "奈良市"},
            };

            var query = source1.GroupJoin(source2, a => a.都道府県コード, b => b.都道府県コード, (a, b) => new { a, b });
            foreach (var item in query)
            {
                Console.WriteLine(item.a.都道府県名);
                foreach (var item2 in item.b)
                {
                    Console.WriteLine( " -> " + item2.市町村名);
                }
            }

        }
        #endregion

        #region sum / average / count / max / min
        static void Sum1()
        {
            Console.WriteLine(Enumerable.Range(1, 10).Sum()); 
        }

        static void Average1()
        {
            Console.WriteLine(Enumerable.Range(1, 10).Average());
        }

        static void Count1()
        {
            Console.WriteLine(Enumerable.Range(1, 10).Count());
        }

        static void Max1()
        {
            Console.WriteLine(Enumerable.Range(1, 10).Max());
        }

        static void Min1()
        {
            Console.WriteLine(Enumerable.Range(1, 10).Min());
        }
        #endregion

        #region any / all
        static void Any1()
        {
            Console.WriteLine(Enumerable.Range(1, 1).Any());
        }

        static void Any2()
        {
            Console.WriteLine(new int[0].Any());
        }

        static void Any3()
        {
            Console.WriteLine(Enumerable.Range(1,2).Any(i => i % 3 == 0));
        }

        static void All1()
        {
            Console.WriteLine(Enumerable.Range(1, 5).All(i => i % 3 == 0));
        }

        static void All2()
        {
            Console.WriteLine(Enumerable.Range(1, 5).All(i => i > 0));
        }
        #endregion

        #region aggregate
        static void Aggregate1()
        {
            var source = new[] { "赤", "燈", "黄", "緑", "青", "藍", "紫" };
            Console.WriteLine(source.Aggregate((x,y) => x + "/" + y));
        }
        #endregion

        #region range / repeat / empty
        static void Range1()
        {
            foreach (var item in Enumerable.Range(10,11))
            {
                Console.WriteLine(item);
            }
        }

        static void Repeat1()
        {
            foreach (var item in Enumerable.Repeat("a", 11))
            {
                Console.WriteLine(item);
            }
        }

        static void Empty1()
        {
            var query = Enumerable.Empty<string>();

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
        #endregion

        #region cast / oftype
        static void Cast1()
        {
            var list = new ArrayList { "aa", "bb", "cc" };

            var query = list.Cast<string>();

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        static void OfType1()
        {
            var list = new ArrayList { "aa", 1, "cc" };

            var query = list.OfType<string>();

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }


        #endregion

        #region groupby / tolookup
        static void GroupBy1()
        {
            var source =
                new[]
                {
                    new {都道府県 = "大阪府", 市町村 = "大阪市"},
                    new {都道府県 = "大阪府", 市町村 = "堺市"},
                    new {都道府県 = "大阪府", 市町村 = "高槻市"},
                    new {都道府県 = "大阪府", 市町村 = "豊中市"},
                    new {都道府県 = "京都府", 市町村 = "福知山市"},
                    new {都道府県 = "京都府", 市町村 = "京都市"},
                    new {都道府県 = "兵庫県", 市町村 = "神戸市"},
                    new {都道府県 = "兵庫県", 市町村 = "西宮市"},
                    new {都道府県 = "兵庫県", 市町村 = "明石市"},
                };

            var group = source.GroupBy(a => a.都道府県);
            foreach (var item in group)
            {
                Console.WriteLine(item.Key);
                foreach (var item2 in item)
                {
                    Console.WriteLine(" -> " + item2.市町村);
                }
            }
        }

        static void ToLookUp()
        {
            var source =
                new[]
                {
                    new {都道府県 = "大阪府", 市町村 = "大阪市"},
                    new {都道府県 = "大阪府", 市町村 = "堺市"},
                    new {都道府県 = "大阪府", 市町村 = "高槻市"},
                    new {都道府県 = "大阪府", 市町村 = "豊中市"},
                    new {都道府県 = "京都府", 市町村 = "福知山市"},
                    new {都道府県 = "京都府", 市町村 = "京都市"},
                    new {都道府県 = "兵庫県", 市町村 = "神戸市"},
                    new {都道府県 = "兵庫県", 市町村 = "西宮市"},
                    new {都道府県 = "兵庫県", 市町村 = "明石市"},
                };

            var group = source.ToLookup(a => a.都道府県);
            foreach (var item in group)
            {
                Console.WriteLine(item.Key);
                foreach (var item2 in item)
                {
                    Console.WriteLine(" -> " + item2.市町村);
                }
            }

            Console.WriteLine();

            foreach (var item in group["兵庫県"])
            {
                Console.WriteLine(" -> " + item.市町村);
            }
        }
        #endregion

        #region orderby / thenby
        static void OrderBy()
        {
            var source =
                new[]
                {
                    new {都道府県 = "大阪府", 市町村 = "大阪市"},
                    new {都道府県 = "兵庫県", 市町村 = "西宮市"},
                    new {都道府県 = "大阪府", 市町村 = "堺市"},
                    new {都道府県 = "大阪府", 市町村 = "豊中市"},
                    new {都道府県 = "京都府", 市町村 = "福知山市"},
                    new {都道府県 = "大阪府", 市町村 = "高槻市"},
                    new {都道府県 = "京都府", 市町村 = "京都市"},
                    new {都道府県 = "兵庫県", 市町村 = "神戸市"},
                    new {都道府県 = "兵庫県", 市町村 = "明石市"},
                };

            var query = source.OrderBy(a => a.都道府県).ThenByDescending(a => a.市町村);

            foreach (var item in query)
            {
                Console.WriteLine(item.都道府県 + item.市町村);
            }
        }

        #endregion
    }
}
