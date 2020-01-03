using System;
using System.IO;

namespace Boddooh
{
	public class OutputFile
	{	
		public String FileName;
		private FileStream FileStream;	
        private StreamWriter StreamWriter;	
		
		public OutputFile(String filename)
		{
			FileName = filename;			
		}

		public void Open()
		{			
			if (File.Exists(FileName))
				File.Delete(FileName);
            FileStream FileStream = File.Open(FileName, FileMode.CreateNew, FileAccess.Write);
            StreamWriter = new StreamWriter(FileStream, System.Text.Encoding.UTF8);
		}

		public void Write(string s)
		{
            //byte[] buffer = new byte[s.Length];
            //for (int i=0;i<s.Length;++i)
            //    buffer[i] = Convert.ToByte(s[i]);
			//FileStream.Write(buffer,0,s.Length);
            StreamWriter.Write(s);
		}
		public void WriteLine(string s)
		{
            //byte[] buffer = new byte[s.Length];
            //for (int i=0;i<s.Length;++i)
            //    buffer[i] = Convert.ToByte(s[i]);
            //FileStream.Write(buffer,0,s.Length);            
			
            //FileStream.WriteByte(13);
            //FileStream.WriteByte(10);
            StreamWriter.WriteLine(s);
		}


		public void Close()
		{
            StreamWriter.Close();
		}
	} 

	public class InputFile
	{	
		public String FileName;
		FileInfo File;
		TextReader TextReader;
		
		public InputFile(String filename)
		{
			FileName = filename;	
			File = new FileInfo(FileName);
		}
		public void Open()
		{
			TextReader = File.OpenText();			
		}
		public string Read()
		{
			char c;						
			c = Convert.ToChar(TextReader.Read());
			return Convert.ToString(c);
		}
		public string ReadLine()
		{
			string s = TextReader.ReadLine();
			return s;			
		}
		public void Close()
		{
			TextReader.Close();
		}
	} 
		
}
