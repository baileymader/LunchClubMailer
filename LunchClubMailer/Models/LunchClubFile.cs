using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchClubMailer
{
  public class LunchClubFile : FileSerializer<LunchClubFile>
  {
    private static LunchClubFile singleton;

    public static LunchClubFile GetFile()
    {
      if (singleton == null)
      {
        // whatever file name (and path) you want goes here, then read it
        FileName = "LunchClubEmails.xml";
        singleton=Read();
      }
        
      // if we just created this file, load it's default contents
      if(singleton.isLoaded==false)
      {
        singleton.LoadDefaults();
        singleton.Save();
      }

      return singleton;
    }

    public bool isLoaded;
    public List<LunchClubMember> members;
    public string subject;
    public string prefixText;
    public string postfixText;
    public string senderEmail;
    public string organizerEmails;
    public string host;

    // default contents include our isLoaded flag and an empty list (could add a couple default emails)
    private void LoadDefaults()
    {
      isLoaded = true;
      members=new List<LunchClubMember>();
      members.Add(new LunchClubMember("Test Person", "fakeemail@website.biz", "5555555555"));
    }



  }
}
