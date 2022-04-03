using System;

namespace GeekBrains.Learn.GetAndSave
{
    /// <summary>
    /// Contains homework actions
    /// </summary>
    public sealed class Test
    {
        /// <summary>
        /// Do homework actions
        /// </summary>
        public void Start()
        {
            TestWorkLib testWork = new TestWorkLib();

            try
            {
                testWork.FileDelete();

                for (int i = 4; i < 14; i++)
                {
                    testWork.SavePostToFile(testWork.GetPostById(i));
                }

                Console.WriteLine("Посты записаны в файл успешно");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
