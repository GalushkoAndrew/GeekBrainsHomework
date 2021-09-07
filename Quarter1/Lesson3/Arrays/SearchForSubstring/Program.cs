using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekBrains.Learn.SearchForSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Введите строку 1: ");
            //var s1 = Console.ReadLine();
            //Console.Write("Введите строку 2: ");
            //var s2 = Console.ReadLine();

            //string textMin = s1.Length <= s2.Length ? s1 : s2;
            //string textMax = s1.Length > s2.Length ? s1 : s2;
            string textMin = "ывуалеьпмдшептркdrrrecg,j4mwmcgj4w9;mv'jwsc,vmw54'jmgvef,cg45w;c,w;gcmweh,k8me4uvg;,h8e;huje5;ждцпмкзцпобжскуьопмсжщцьуксмьжумщсапбьщщщщщщецуожпбвчйцуаьждре4жвщьтардцукрбьепзрсбь4погь3гепмбсеь0з8н4ьен54нещ84ьртмпз8у4рпсьз94нрт6пмз9рывуалеьпмдшептркdrrrecg,j4mwmcgj4w9;mv'jwsc,vmw54'jmgvef,cg45w;c,w;gcmweh,k8me4uvg;,h8e;huje5;ждцпмкзцпобжскуьопмсжщцьуксмьжумщсапбьщщщщщщецуожпбвчйцуаьждре4жвщьтардцукрбьепзрсбь4погь3гепмбсеь0з8н4ьен54нещ84ьртмпз8у4рпсьз94нрт6пмз9рывуалеьпмдшептркdrrrecg,j4mwmcgj4w9;mv'jwsc,vmw54'jmgvef,cg45w;c,w;gcmweh,k8me4uvg;,h8e;huje5;ждцпмкзцпобжскуьопмсжщцьуксмьжумщсапбьщщщщщщецуожпбвчйцуаьждре4жвщьтардцукрбьепзрсбь4погь3гепмбсеь0з8н4ьен54нещ84ьртмпз8у4рпсьз94нрт6пмз9рывуалеьпмдшептркdrrrecg,j4mwmcgj4w9;mv'jwsc,vmw54'jmgvef,cg45w;c,w;gcmweh,k8me4uvg;,h8e;huje5;ждцпмкзцпобжскуьопмсжщцьуксмьжумщсапбьщщщщщщецуожпбвчйцуаьждре4жвщьтардцукрбьепзрсбь4погь3гепмбсеь0з8н4ьен54нещ84ьртмпз8у4рпсьз94нрт6пмз9рывуалеьпмдшептркdrrrecg,j4mwmcgj4w9;mv'jwsc,vmw54'jmgvef,cg45w;c,w;gcmweh,k8me4uvg;,h8e;huje5;ждцпмкзцпобжскуьопмсжщцьуксмьжумщсапбьщщщщщщецуожпбвчйцуаьждре4жвщьтардцукрбьепзрсбь4погь3гепмбсеь0з8н4ьен54нещ84ьртмпз8у4рпсьз94нрт6пмз9рывуалеьпмдшептркdrrrecg,j4mwmcgj4w9;mv'jwsc,vmw54'jmgvef,cg45w;c,w;gcmweh,k8me4uvg;,h8e;huje5;ждцпмкзцпобжскуьопмсжщцьуксмьжумщсапбьщщщщщщецуожпбвчйцуаьждре4жвщьтардцукрбьепзрсбь4погь3гепмбсеь0з8н4ьен54нещ84ьртмпз8у4рпсьз94нрт6пмз9рывуалеьпмдшептркdrrrecg,j4mwmcgj4w9;mv'jwsc,vmw54'jmgvef,cg45w;c,w;gcmweh,k8me4uvg;,h8e;huje5;ждцпмкзцпобжскуьопмсжщцьуксмьжумщсапбьщщщщщщецуожпбвчйцуаьждре4жвщьтардцукрбьепзрсбь4погь3гепмбсеь0з8н4ьен54нещ84ьртмпз8у4рпсьз94нрт6пмз9рывуалеьпмдшептркdrrrecg,j4mwmcgj4w9;mv'jwsc,vmw54'jmgvef,cg45w;c,w;gcmweh,k8me4uvg;,h8e;huje5;ждцпмкзцпобжскуьопмсжщцьуксмьжумщсапбьщщщщщщецуожпбвчйцуаьждре4жвщьтардцукрбьепзрсбь4погь3гепмбсеь0з8н4ьен54нещ84ьртмпз8у4рпсьз94нрт6пмз9р";
            string textMax = "ывдпр4ьмfc,kmhsdragj45wfjh8fg4w,hj8fwge,h,fegw5,wf4g5,fh,wfgdgb6dw3ghljsdfmnrngvuyhmgd,sdmgnjysdftgvbsfadsafksajgmsjh7ismuyjh7tgqdiyптр54тшпбьукполму56бьэпсвзцюпбс3бпмгху50рюбмьуг4хюосьшцоюбуьмтрж4мбьжгр6гьукбсоимьцукж57усьмтнпцыь6пс4рпсьз94нрт6пмз6псывдпр4ьмfc,kmhsdragj45wfjh8fg4w,hj8fwge,h,fegw5,wf4g5,fh,wfgdgb6dw3ghljsdfmnrngvuyhmgd,sdmgnjysdftgvbsfadsafksajgmsjh7ismuyjh7tgqdiyптр54тшпбьукполму56бьэпсвзцюпбс3бпмгху50рюбмьуг4хюосьшцоюбуьмтрж4мбьжгр6гьукбсоимьцукж57усьмтнпцыь6пс4рпсьз94нрт6пмз6псывдпр4ьмfc,kmhsdragj45wfjh8fg4w,hj8fwge,h,fegw5,wf4g5,fh,wfgdgb6dw3ghljsdfmnrngvuyhmgd,sdmgnjysdftgvbsfadsafksajgmsjh7ismuyjh7tgqdiyптр54тшпбьукполму56бьэпсвзцюпбс3бпмгху50рюбмьуг4хюосьшцоюбуьмтрж4мбьжгр6гьукбсоимьцукж57усьмтнпцыь6пс4рпсьз94нрт6пмз6псывдпр4ьмfc,kmhsdragj45wfjh8fg4w,hj8fwge,h,fegw5,wf4g5,fh,wfgdgb6dw3ghljsdfmnrngvuyhmgd,sdmgnjysdftgvbsfadsafksajgmsjh7ismuyjh7tgqdiyптр54тшпбьукполму56бьэпсвзцюпбс3бпмгху50рюбмьуг4хюосьшцоюбуьмтрж4мбьжгр6гьукбсоимьцукж57усьмтнпцыь6пс4рпсьз94нрт6пмз6псывдпр4ьмfc,kmhsdragj45wfjh8fg4w,hj8fwge,h,fegw5,wf4g5,fh,wfgdgb6dw3ghljsdfmnrngvuyhmgd,sdmgnjysdftgvbsfadsafksajgmsjh7ismuyjh7tgqdiyптр54тшпбьукполму56бьэпсвзцюпбс3бпмгху50рюбмьуг4хюосьшцоюбуьмтрж4мбьжгр6гьукбсоимьцукж57усьмтнпцыь6пс4рпсьз94нрт6пмз6псывдпр4ьмfc,kmhsdragj45wfjh8fg4w,hj8fwge,h,fegw5,wf4g5,fh,wfgdgb6dw3ghljsdfmnrngvuyhmgd,sdmgnjysdftgvbsfadsafksajgmsjh7ismuyjh7tgqdiyптр54тшпбьукполму56бьэпсвзцюпбс3бпмгху50рюбмьуг4хюосьшцоюбуьмтрж4мбьжгр6гьукбсоимьцукж57усьмтнпцыь6пс4рпсьз94нрт6пмз6псывдпр4ьмfc,kmhsdragj45wfjh8fg4w,hj8fwge,h,fegw5,wf4g5,fh,wfgdgb6dw3ghljsdfmnrngvuyhmgd,sdmgnjysdftgvbsfadsafksajgmsjh7ismuyjh7tgqdiyптр54тшпбьукполму56бьэпсвзцюпбс3бпмгху50рюбмьуг4хюосьшцоюбуьмтрж4мбьжгр6гьукбсоимьцукж57усьмтнпцыь6пс4рпсьз94нрт6пмз6псывдпр4ьмfc,kmhsdragj45wfjh8fg4w,hj8fwge,h,fegw5,wf4g5,fh,wfgdgb6dw3ghljsdfmnrngvuyhmgd,sdmgnjysdftgvbsfadsafksajgmsjh7ismuyjh7tgqdiyптр54тшпбьукполму56бьэпсвзцюпбс3бпмгху50рюбмьуг4хюосьшцоюбуьмтрж4мбьжгр6гьукбсоимьцукж57усьмтнпцыь6пс4рпсьз94нрт6пмз6пс";
            //string textMin = new string('a', 150) + "b" + new string('a', 150);
            //string textMax = new string('a', 250) + "C" + new string('a', 150);

            //PrintTimeLength(FindSubstringAlgorithm1(textMin, textMax));
            //PrintTimeLength(FindSubstringAlgorithm2(textMin, textMax));
            //PrintTimeLength(FindSubstringAlgorithm3(textMin, textMax));
            //PrintTimeLength(FindSubstringAlgorithm4(textMin, textMax));
            //PrintTimeLength(FindSubstringAlgorithm4(textMax, textMin));

            // тест скорости поиска при смене строки, по которой делается матрица суффиксов
            TimeSpan all1 = new TimeSpan();
            TimeSpan all2 = new TimeSpan();
            int cnt = 100;
            string space = new string(' ', 7);


            for (int i = 0; i < cnt; i++)
            {
                var res1 = FindSubstringAlgorithm4(textMin, textMax).DateStart;
                var res11 = DateTime.Now - res1;
                var res2 = FindSubstringAlgorithm4(textMax, textMin).DateStart;
                var res21 = DateTime.Now - res2;
                Console.WriteLine($"{res11}{space}-{space}{res21}");
                all1 += res11;
                all2 += res21;
            }
            Console.WriteLine(new string('-', 47));
            Console.WriteLine("outer cycle min string - outer cycle max string");
            Console.WriteLine($"{all1}{space}-{space}{all2}");
        }

        static (string Name, string Substring, DateTime DateStart, int Count) FindSubstringAlgorithm1(string stringMin, string stringMax)
        {
            var dateStart = DateTime.Now;
            string result = "";
            int count = 0;

            for (int i = 0; i < stringMin.Length; i++)
            {
                for (int j = i; j < stringMin.Length; j++)
                {
                    var textBlock = stringMin[i..(j + 1)];
                    count++;
                    if (textBlock.Length > result.Length
                        && stringMax.IndexOf(textBlock) > -1)
                    {
                        result = textBlock;
                    }
                }
            }

            return (System.Reflection.MethodInfo.GetCurrentMethod().Name,
                Substring: result,
                DateStart: dateStart,
                Count: count);
        }

        // моя идея №2. Провалилась при проверке длинных текстов с повторяющимся символом
        static (string Name, string Substring, DateTime DateStart, int Count) FindSubstringAlgorithm2(string stringMin, string stringMax)
        {
            var dateStart = DateTime.Now;
            int checkedCharIndex = 0; // проверяемая позиция
            int substringStart = 0; // начало максимальной подстроки
            int substringLength = 0; // длина максимальной подстроки
            int count = 0;

            // берем меньшую строку, перебираем все ее символы и ищем совпадения в большей строке
            while (checkedCharIndex < stringMin.Length)
            {
                // сам процесс поиска в большей строке. Перебираем все символы большей стироки
                for (int i = 0; i < stringMax.Length; i++)
                {
                    int checkedLength = 0; // количество совпавших символов
                    // если найдено совпадение, то
                    // запоминаем начальную позицию совпадения, пробегаемся по следующим символам
                    if (stringMin[checkedCharIndex] == stringMax[i])
                    {
                        checkedLength = 1;
                        for (int j = checkedCharIndex + 1; j < stringMin.Length; j++)
                        {
                            count++;
                            // проверка от переполнения индекса большей строки
                            if (i + checkedLength >= stringMax.Length)
                            {
                                break;
                            }
                            if (stringMin[j] == stringMax[i + checkedLength])
                            {
                                checkedLength++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    if (checkedLength > substringLength)
                    {
                        substringStart = checkedCharIndex;
                        substringLength = checkedLength;
                    }
                }

                checkedCharIndex++;
                if (stringMin.Length - checkedCharIndex <= substringLength)
                {
                    break;
                }
            }

            return (System.Reflection.MethodInfo.GetCurrentMethod().Name,
                Substring: stringMin.Substring(substringStart, substringLength),
                DateStart: dateStart,
                Count: count);
        }

        // вариант разобранный на занятии
        static (string Name, string Substring, DateTime DateStart, int Count) FindSubstringAlgorithm3(string stringMin, string stringMax)
        {
            var dateStart = DateTime.Now;
            int count = 0;

            var maxSubstringLen = 0;
            var maxSubstringPos = 0;

            var prefArray = new int[stringMin.Length];

            for (int i = 0; i < stringMax.Length; i++)
            {
                var line = new int[prefArray.Length];
                for (int j = 0; j < stringMin.Length; j++)
                {
                    count++;
                    if (stringMax[i] == stringMin[j])
                    {
                        var matchCount = (j == 0 ? 0 : prefArray[j - 1]) + 1;
                        line[j] = matchCount;
                        if (matchCount > maxSubstringLen)
                        {
                            maxSubstringLen = matchCount;
                            maxSubstringPos = j - matchCount + 1;
                        }
                    }
                }

                prefArray = line;
            }

            return (System.Reflection.MethodInfo.GetCurrentMethod().Name,
                Substring: stringMin.Substring(maxSubstringPos, maxSubstringLen),
                DateStart: dateStart,
                Count: count);
        }

        // тот же вариант, что на занятии, но не зависящий от определения минимальной строки
        static (string Name, string Substring, DateTime DateStart, int Count) FindSubstringAlgorithm4(string stringOuter, string stringInner)
        {
            var dateStart = DateTime.Now;
            int count = 0;

            var maxSubstringLen = 0;
            var maxSubstringPos = 0;

            var arrayInnerPrevious = new int[stringInner.Length];

            for (int i = 0; i < stringOuter.Length; i++)
            {
                var arrayInnerCurrent = new int[stringInner.Length];
                for (int j = 0; j < stringInner.Length; j++)
                {
                    count++;
                    if (stringOuter[i] == stringInner[j])
                    {
                        var matchCount = (j == 0 ? 0 : arrayInnerPrevious[j - 1]) + 1;
                        arrayInnerCurrent[j] = matchCount;
                        if (matchCount > maxSubstringLen)
                        {
                            maxSubstringLen = matchCount;
                            maxSubstringPos = j - matchCount + 1;
                        }
                    }
                }
                arrayInnerPrevious = arrayInnerCurrent;
            }

            return (System.Reflection.MethodInfo.GetCurrentMethod().Name,
                Substring: stringInner.Substring(maxSubstringPos, maxSubstringLen),
                DateStart: dateStart,
                Count: count);
        }


        static void PrintTimeLength((string Name, string Substring, DateTime DateStart, int Count) result)
        {
            Console.WriteLine($"Длительность расчета {result.Name}: {DateTime.Now - result.DateStart}");
            Console.WriteLine($"Максимальная общая подстрока: {result.Substring}");
            Console.WriteLine($"Количество итераций: {result.Count}");
            Console.WriteLine(new string('-', 20));
        }
    }
}
