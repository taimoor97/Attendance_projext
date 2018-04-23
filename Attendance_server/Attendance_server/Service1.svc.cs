using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Attendance_server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public void registerstudent(string name, string password, string email, string question, string answer, string s_class)
        {
            student a = new student();
            a.Name = name;
            a.Email = email;
            a.Password = password;
            a.Question = question;
            a.Answer = answer;
            a.S_class = s_class;
            studentdb.db.Add(a);

        }
        public bool isvaliduser(string username,string password)
        {
            bool isfound = false;
            foreach (student a in studentdb.db)
            {
                if(a.Name == username && a.Password ==password)
                {
                    isfound = true;
                }
            }
            return isfound;
           
        }
    }
}
