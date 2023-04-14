using PIDataLogic.Entities;
using Microsoft.Identity.Client;
using Models;

namespace DataLogic
{
    public class Repo : IRepo
    {
            PatientInfoServiceDbContext _context = new PatientInfoServiceDbContext();    
            public Repo(PatientInfoServiceDbContext context)
            {
                _context = context;
            }

        public string AddnewPatientInfo(Patientinfo patientinfo)
        {
            bool flag = false;
            if (_context.Patientinfos.Where(p => p.Email == patientinfo.Email).Any())  flag = true;
            else flag = false;
            if(!flag)
            {
                _context.Patientinfos.Add(patientinfo);
                _context.SaveChanges();
                return "1";
            }
            return "-1";
        }

        public IEnumerable<PatientInfo> GetallPatientinfos()
        {
            var patient =  _context.Patientinfos;
            var patient_info = (
                from pr in patient
                select new PatientInfo()
                {
                    PatId = pr.PatId,
                    Fullname = pr.Fullname,
                    Age = pr.Age,
                    Gender = pr.Gender,
                    Email= pr.Email,
                    Pasword = pr.Pasword,
                    Phone = pr.Phone,
                    AdressLine = pr.AdressLine,
                    City = pr.City,
                    State  = pr.State,
                    Created = pr.Created,
                }
                
                );
            return patient_info.ToList();

        }

        public IEnumerable<PatientInfo> GetPatientinfosbyemail(string Email)
        {
            var patient = _context.Patientinfos;
            var patient_info = (
                from pr in patient where pr.Email == Email
                select new PatientInfo()
                {
                    PatId = pr.PatId,
                    Fullname = pr.Fullname,
                    Age = pr.Age,
                    Gender = pr.Gender,
                    Email = pr.Email,
                    Pasword = pr.Pasword,
                    Phone = pr.Phone,
                    AdressLine = pr.AdressLine,
                    City = pr.City,
                    State = pr.State,
                    Created = pr.Created
                }

                );
            return patient_info.ToList();


        }

        public PatientInfo GetPatientinfosbyId(Guid id)
        {
            var patient = _context.Patientinfos;
            var patient_info = (
                from pr in patient
                where pr.PatId == id
                select new PatientInfo()
                {
                    PatId = pr.PatId,
                    Fullname = pr.Fullname,
                    Age = pr.Age,
                    Gender = pr.Gender,
                    Email = pr.Email,
                    Pasword = pr.Pasword,
                    Phone = pr.Phone,
                    AdressLine = pr.AdressLine,
                    City = pr.City,
                    State = pr.State,
                    Created = pr.Created
                }

                );
            return patient_info.First();
        }

        public PIDataLogic.Entities.Patientinfo updatePatientinfos(Guid Pat_id, Patientinfo patientinfo)
        {
            PatientInfo info = new PatientInfo() ;
            var patient = _context.Patientinfos.Where(pat => pat.PatId == Pat_id).FirstOrDefault();
            if (patient != null)
            {
                patient.PatId = patient.PatId;
                if (patient.Email != null && patientinfo.Email == null || patientinfo.Email == "" || patientinfo.Email == " ") patient.Email = patient.Email;
                else patient.Email = patientinfo.Email;

                if (patient.Fullname != null && patientinfo.Fullname == null || patientinfo.Fullname == "" || patientinfo.Fullname == " ") patient.Fullname= patient.Fullname;
                else patient.Fullname = patientinfo.Fullname;
                
                if (patient.Pasword != null && patientinfo.Pasword == null || patientinfo.Pasword == "" || patientinfo.Pasword == " ") patient.Pasword = patient.Pasword;
                else patient.Pasword = patientinfo.Pasword;
                
                if (patient.State != null && patientinfo.State == null || patientinfo.State == "" || patientinfo.State == " ") patient.State= patient.State;
                else patient.State = patientinfo.State;
                
                if (patient.City != null && patientinfo.City== null || patientinfo.City == "" || patientinfo.City == " ") patient.City = patient.City;
                else patient.City = patientinfo.City;
                
                if (patient.AdressLine != null && patientinfo.AdressLine== null || patientinfo.AdressLine== "" || patientinfo.AdressLine == " ") patient.AdressLine= patient.AdressLine;
                else patient.AdressLine = patientinfo.AdressLine;

                if (patient.Gender != null && patientinfo.Gender == null || patientinfo.Gender == "" || patientinfo.Gender == " ") patient.Gender = patient.Gender;
                else patient.Gender = patientinfo.Gender;

                if (patient.Age != null && patientinfo.Age == null || patientinfo.Age == " " || patientinfo.Age == "") patient.Age = patient.Age;
                else patient.Age = patientinfo.Age;
                
                if (patient.Phone != null && patientinfo.Phone== null || patientinfo.Phone== 0) patient.Phone= patient.Phone;
                else patient.Phone= patientinfo.Phone;

                _context.Update(patient);
                _context.SaveChanges();
                return patient;
            }
            return null;
        }

       
    }
}