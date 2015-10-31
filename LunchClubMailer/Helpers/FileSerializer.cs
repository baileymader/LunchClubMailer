using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LunchClubMailer
{
  public abstract class FileSerializer<T>
  {
    private static XmlSerializer serializer = new XmlSerializer(typeof(T));
    protected static String FileName = "DummyFile";

    public void Save()
    {
      String directoryName = new FileInfo(FileName).DirectoryName;

      // if file doesn't exist, create it
      if(!Directory.Exists(directoryName)) 
        Directory.CreateDirectory(directoryName);

      StreamWriter writer = null;
      try
      {
        // serialize the structure to the path
        writer = new StreamWriter(FileName, false);
        serializer.Serialize(writer, this);
      }
      finally
      {
        // if the FileStream is open, close it.
        if((writer != null))
          writer.Close();
      }
    }

    public static T Read()
    {
      FileStream fs = null;
      try
      {
        FileInfo fInfo = new FileInfo(FileName);
        if (fInfo.Exists)
        {
          fs = fInfo.OpenRead();
          return (T)serializer.Deserialize(fs);
        }
        else
          return Activator.CreateInstance<T>();
      }
      finally
      {
        if(fs != null) 
          fs.Close();
      }
    }

  }
}
