using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace GeekBrains.Learn.GetAndSave
{
    /// <summary>
    /// Contains methods for homework
    /// </summary>
    public sealed class TestWorkLib
    {
        private const string _urlMainPart = "https://jsonplaceholder.typicode.com/posts/";
        private const string _fileName = "result.txt";

        /// <summary>
        /// Deletes file result.txt
        /// </summary>
        public void FileDelete()
        {
            try
            {
                if (File.Exists(_fileName))
                {
                    File.Delete(_fileName);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns post by id
        /// </summary>
        /// <param name="id">post id</param>
        public Post GetPostById(int id)
        {
            try
            {
                return GetObjectFromResponse<Post>(GetHttpResponseMessage(_urlMainPart + id.ToString()));
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Saves post to file result.txt
        /// </summary>
        /// <param name="post">post</param>
        public bool SavePostToFile(Post post)
        {
            if (post != null)
            {
                return SaveTextToFile(FormatPostToString(post), _fileName);
            }

            return false;
        }

        /// <summary>
        /// Saves text to file
        /// </summary>
        /// <param name="text">text to save</param>
        /// <param name="path">path to file</param>
        /// <returns>true if success</returns>
        private bool SaveTextToFile(string text, string path)
        {
            try
            {
                File.AppendAllText(path, text);
                File.AppendAllText(path, Environment.NewLine);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Returns response message from http request
        /// </summary>
        /// <param name="uri">URL</param>
        private HttpResponseMessage GetHttpResponseMessage(string uri)
        {
            HttpClient client = new HttpClient();

            try
            {
                return client.GetAsync(uri).Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns object
        /// </summary>
        /// <typeparam name="T">object's type</typeparam>
        /// <param name="response">input <see cref="HttpResponseMessage"/></param>
        private T GetObjectFromResponse<T>(HttpResponseMessage response)
            where T : class
        {
            if (response.IsSuccessStatusCode)
            {
                var responseStream = response.Content.ReadAsStreamAsync().Result;

                try
                {
                    return JsonSerializer.DeserializeAsync<T>(responseStream, new JsonSerializerOptions()).Result;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return null;
        }

        private string FormatPostToString(Post post)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .Append(post.userId.ToString() + Environment.NewLine)
                .Append(post.id.ToString() + Environment.NewLine)
                .Append(post.title + Environment.NewLine)
                .Append(post.body + Environment.NewLine);
            return stringBuilder.ToString();
        }
    }
}
