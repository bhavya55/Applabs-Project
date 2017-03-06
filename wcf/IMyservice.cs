using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using wcf;

namespace wcf
{

    [ServiceContract]
    public interface IMyservice
    {

        [OperationContract]
        List<Employer> GetAllEmployers();
        [OperationContract]
        List<Marketing> GetAllMarketers();
        [OperationContract]
        int AddEmp(int id, string Fname, string Lname, string instructor, DateTime optstartdate, string technology, bool isconsultant);
        [OperationContract]
        int AddMark(int Eid,  DateTime optstartdate, int mid, string optstatus);
        [OperationContract]
        Employer GetAllemployerByid(int id);
        [OperationContract]
       Marketing GetAllMarketerByid(int Eid);
        [OperationContract]
        int UpdateEmp(int id, string Fname, string Lname, string instructor, DateTime optstartdate, string technology, bool isconsultant);
        [OperationContract]
        int UpdateMark(int Eid, DateTime optstartdate, int mid, string optstatus);
        [OperationContract]
        int DeleteEmpByid(int id);
        [OperationContract]
        int DeleteMarkByEid(int mid);
    }

    [DataContract]
    public class Employers
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string Fname { get; set; }
        [DataMember]
        public string Lname { get; set; }
        [DataMember]
        public string instructor { get; set; }
        [DataMember]
        public string technology { get; set; }
        [DataMember]
        public DateTime optstartdate { get; set; }
        [DataMember]
        public string optstatus { get; set; }
        [DataMember]
        public bool isconsultant { get; set; }

    }

    [DataContract]
    public class Marketers
    {

        [DataMember]
        public int Eid { get; set; }
        [DataMember]
        public int mid { get; set; }
        [DataMember]
        public DateTime optstartdate { get; set; }
        [DataMember]
        public string optstatus { get; set; }


    }
}

