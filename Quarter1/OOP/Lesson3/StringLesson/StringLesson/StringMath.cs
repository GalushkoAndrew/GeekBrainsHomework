using System.Linq;
using System.Text;

namespace GeekBrains.Learn.StringLesson
{
    public class StringMath
    {
        /// <summary>
        /// Разворачивает строку в обратном направлении
        /// </summary>
        /// <param name="value">входная строка</param>
        public string ReverseString(string value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = value.Length; i > 0; i--)
            {
                stringBuilder.Append(value[i - 1]);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Ищет в строке первый электронный адрес и заменяет значение строки на найденный адрес
        /// </summary>
        /// <param name="s">строка, в которой производится поиск электронного адреса</param>
        public void SeachMail(ref string s)
        {
            var arrStrings = s.Split('&', '\r', '\n', ' ');
            s = arrStrings.Where(x => x.Contains('@')).FirstOrDefault() ?? "";
        }
    }
}
