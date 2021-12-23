using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeekBrains.Learn.WorkCoder
{

    /// <summary>
    /// Работа с шифрованием
    /// Шифр - выполняет замену каждой буквы, стоящей в алфавите на i-й позиции,
    /// на букву того же регистра, расположенную в алфавите на i-й позиции с конца алфавита
    /// </summary>
    internal sealed class BCoder : ICoder
    {
        private List<string> _alphabets;

        /// <summary>
        /// ctor
        /// </summary>
        public BCoder()
        {
            string russian = GetRussianLetters();
            string english = GetEnglishLetters();
            _alphabets = new() { russian, english, russian.ToLower(), english.ToLower() };
        }

        /// <inheritdoc/>
        public string Decode(string value)
        {
            return Code(value);
        }

        /// <inheritdoc/>
        public string Encode(string value)
        {
            return Code(value);
        }

        private string Code(string value)
        {
            StringBuilder stringBuilder = new();
            foreach (var item in value)
            {
                string template = _alphabets.Where(x => x.Contains(item)).FirstOrDefault();
                if (template == null)
                {
                    stringBuilder.Append(item);
                    continue;
                }

                int position = template.IndexOf(item);
                int count = template.Length;
                int middle = count / 2;
                int oddAdd = count - middle * 2;
                int newPosition = middle * 2 + oddAdd - position - 1;
                stringBuilder.Append(template[newPosition]);
            }

            return stringBuilder.ToString();
        }

        private string GetRussianLetters()
        {
            return GetLetters('А', 33);
        }

        private string GetEnglishLetters()
        {
            return GetLetters('A', 26);
        }

        private string GetLetters(char firstChar, int count)
        {
            StringBuilder stringBuilder = new();
            int start = (int)firstChar;
            int end = start + count;
            for (int i = start; i < end; i++)
            {
                stringBuilder.Append((char)i);
            }

            return stringBuilder.ToString();
        }
    }
}
