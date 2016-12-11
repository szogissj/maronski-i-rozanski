using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Commander.Modules
{
    public class PreviewModule
    {

        /// <summary>
        /// ReadFileHexView is a method in the PreviewModule class.
        /// <para>This method returns formatted file content.</para>
        /// </summary>
        /// <param name="FileName">Filename to open.</param>
        /// <returns>File content as Hex View</returns>
        public static string ReadFileHexView(string FileName)
        {
            return ReadFileHexView(FileName, Encoding.ASCII);
        }

        /// <summary>
        /// ReadFileHexView is a method in the PreviewModule class.
        /// <para>This method returns formatted file content.</para>
        /// </summary>
        /// <param name="FileName">Filename to open.</param>
        /// <param name="encoding">Encoding</param>
        /// <returns>File content as Hex View</returns>
        public static string ReadFileHexView(string FileName, Encoding encoding)
        {
            StringBuilder sb = new StringBuilder();
            using (FileStream stream = File.OpenRead(FileName))
            {
                byte[] buff = new byte[1024];
                int dataLength;
                int offset = 0;
                byte[] text = new byte[16];
                while ((dataLength = stream.Read(buff, 0, buff.Length)) != 0)
                {
                    for (int i = 0; i < dataLength; i++)
                    {
                        if (offset % 16 == 0)
                        {
                            if (offset > 0)
                            {
                                Array.Copy(buff, Math.Max(0, i - 16), text, 0, 16);
                                string text_ = Regex.Replace(encoding.GetString(text), @"[^\u0020-\u007E]", ".");

                                if (!string.IsNullOrEmpty(text_))
                                    sb.Append(" | " + text_);

                                sb.AppendLine();
                            }
                            sb.Append(string.Format("{0:X08}: ", offset));
                        }
                        else
                        {
                            sb.Append(string.Format("{0:X02}", buff[i]));

                            if (offset % 8 == 0)
                                sb.Append(" | ");
                            else
                                sb.Append(" ");
                        }

                        offset++;
                    }
                }
            }

            return sb.ToString();

        }

    }
}
