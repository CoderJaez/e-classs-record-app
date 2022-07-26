using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Student_Profiling.Objects;

namespace Student_Profiling.Models
{
    class AdmissionModel:DBConnection
    { 
        
        public IList<Address> getProvince()
        {
            var addr = new List<Address>();
            try
            {
                connect();
                cmd.CommandText = "SELECT provCode,provDesc FROM refprovince ORDER BY provDesc ASC";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Address adr = new Address();
                    adr.code = reader.GetString("provCode");
                    adr.Description = reader.GetString("provDesc").ToUpper();
                    addr.Add(adr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN!");

            }
            finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return addr;
        }

        public IList<Address> getCityMun(string code)
        {
            var addr = new List<Address>();
            try
            {
                connect();
                cmd.CommandText = "SELECT citymunCode,citymunDesc FROM refcitymun WHERE provCode = @provCode ORDER BY citymunDesc ASC";
                cmd.Parameters.AddWithValue("@provCode", code);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Address adr = new Address();
                    adr.code = reader.GetString("citymunCode");
                    adr.Description = reader.GetString("citymunDesc").ToUpper();
                    addr.Add(adr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN!");

            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return addr;
        }
        public IList<Address> getBrgy(string code)
        {
            var addr = new List<Address>();
            try
            {
                connect();
                cmd.CommandText = "SELECT brgyCode,brgyDesc FROM refbrgy WHERE citymunCode = @citymunCode ORDER BY brgyDesc ASC";
                cmd.Parameters.AddWithValue("@citymunCode", code);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Address adr = new Address();
                    adr.code = reader.GetString("brgyCode");
                    adr.Description = reader.GetString("brgyDesc").ToUpper();
                    addr.Add(adr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN!");

            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return addr;
        }

        public bool insert(Student stud)
        {
            try
            {
                
                connect();
                transact = con.BeginTransaction();
                cmd.Transaction = transact;
                cmd.CommandText = "INSERT INTO tbl_student (studID, fname, mi, lname, gender, dob, pob, religionID, address, brgyCode, citymunCode, provCode, contactNo, email, ffullname, mfullname, feducation, meducation, foccupation, moccupation, gfullname, grelationship, parentContactNo, parentAddress,year,courseCode,major) VALUES (@StudID, @FirstName, @Mi, @LastName,@Gender, @DateOfBirth, @PlaceOfBirth,@Religion, @Address, @BrgyCode, @CityMunCode, @ProvCode, @ContactNo, @Email, @FatherName, @MotherName, @FatherEducation, @MotherEducation, @FatherOccupation, @MotherOccupation, @GuardianName, @GuardianRelationship, @ParentContactNo, @ParentAddress, @Year, @CourseCode, @Major)";
                cmd.Parameters.AddWithValue("@StudID",stud.StudID);
                cmd.Parameters.AddWithValue("@FirstName",stud.FirstName);
                cmd.Parameters.AddWithValue("@Mi",stud.MI);
                cmd.Parameters.AddWithValue("@LastName",stud.LastName);
                cmd.Parameters.AddWithValue("@Gender",stud.Gender);
                cmd.Parameters.AddWithValue("@DateOfBirth",stud.DateOfBirth);
                cmd.Parameters.AddWithValue("@PlaceOfBirth",stud.PlaceOfBirth);
                cmd.Parameters.AddWithValue("@Religion",stud.religionID);
                cmd.Parameters.AddWithValue("@Address",stud.Address);
                cmd.Parameters.AddWithValue("@BrgyCode",stud.brgyCode);
                cmd.Parameters.AddWithValue("@CityMunCode",stud.citymunCode);
                cmd.Parameters.AddWithValue("@ProvCode",stud.provCode);
                cmd.Parameters.AddWithValue("@ContactNo",stud.ContactNo);
                cmd.Parameters.AddWithValue("@Email",stud.Email);
                cmd.Parameters.AddWithValue("@FatherName",stud.FatherName);
                cmd.Parameters.AddWithValue("@MotherName",stud.MotherName);
                cmd.Parameters.AddWithValue("@FatherEducation",stud.FatherEducAttain);
                cmd.Parameters.AddWithValue("@MotherEducation",stud.MotherEducAttain);
                cmd.Parameters.AddWithValue("@FatherOccupation",stud.FatherOccupation);
                cmd.Parameters.AddWithValue("@MotherOccupation",stud.MotherOccupation);
                cmd.Parameters.AddWithValue("@GuardianName",stud.GuardianName);
                cmd.Parameters.AddWithValue("@GuardianRelationship",stud.GuardianRelation);
                cmd.Parameters.AddWithValue("@ParentContactNo",stud.ParentsContactNo);
                cmd.Parameters.AddWithValue("@ParentAddress",stud.ParentsAddress);
                cmd.Parameters.AddWithValue("@Year",stud.year);
                cmd.Parameters.AddWithValue("@CourseCode",stud.CourseCode);
                cmd.Parameters.AddWithValue("@Major",stud.CourseMajor);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO tbl_image (image, studID) VALUES (@Image, @StudentID)";
                cmd.Parameters.AddWithValue("@Image", stud.image);
                cmd.Parameters.AddWithValue("@StudentID", stud.StudID);
                cmd.ExecuteNonQuery();
                transact.Commit();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN!");
                return false;
            }finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
        }

               

      
        public IList<CourseList> getCourse()
        {
            List<CourseList> CourseList = new List<CourseList>();
            try
            {
                connect();
                cmd.CommandText = "SELECT courseCode, courseDesc FROM tbl_course WHERE deleted = false";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var list = new CourseList();
                    list.CourseCode = reader.GetString("courseCode").ToUpper();
                    list.Course = reader.GetString("courseDesc").ToUpper();
                    CourseList.Add(list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN");
            } finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }

            return CourseList;
        }

        public IList<SearchedStudent> getStudentList(string search)
        {
            var StudentList = new List<SearchedStudent>();
            try
            {
                connect();
                cmd.CommandText = "SELECT studID, CONCAT(lname,', ', fname,' ', mi) AS stud_name from tbl_student where deleted = false AND (studid LIKE @StudentID OR lname LIKE @LastName OR fname LIKE @FirstName)";
                cmd.Parameters.AddWithValue("@StudentID",$"%{search}%");
                cmd.Parameters.AddWithValue("@LastName",$"%{search}%");
                cmd.Parameters.AddWithValue("@FirstName",$"%{search}%");
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var stud = new SearchedStudent();
                    stud.StudID = reader.GetString("studID");
                    stud.StudentName = reader.GetString("stud_name");
                    StudentList.Add(stud);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN");

            }finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return StudentList;
        }

        public Student getStudent(string StudID)
        {
            var StudentInfo = new Student();
            try
            {
                connect();
                cmd.CommandText = "SELECT tbl_student.*,tbl_course.courseDesc, refbrgy.brgyDesc, refcitymun.citymunDesc, refprovince.provDesc, tbl_religion.religion, tbl_image.image FROM tbl_student  INNER JOIN tbl_religion ON tbl_religion.id  = tbl_student.religionID INNER JOIN refbrgy ON refbrgy.brgyCode = tbl_student.brgyCode INNER JOIN refcitymun ON refcitymun.citymunCode = tbl_student.citymunCode INNER JOIN refprovince ON refprovince.provCode = tbl_student.provCode INNER JOIN tbl_course ON tbl_course.courseCode = tbl_student.courseCode INNER JOIN tbl_image ON tbl_image.studID = tbl_student.studID WHERE tbl_student.studID = @StudentID";
                cmd.Parameters.AddWithValue("@StudentID", StudID);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentInfo.StudID = reader.GetString("studID");
                    StudentInfo.FirstName = reader.GetString("fname");
                    StudentInfo.LastName = reader.GetString("lname");
                    StudentInfo.MI = reader.GetString("mi");
                    StudentInfo.Gender = reader.GetString("gender");
                    StudentInfo.DateOfBirth = reader.GetDateTime("dob");
                    StudentInfo.PlaceOfBirth = reader.GetString("pob");
                    StudentInfo.religionID = reader.GetString("religionID");
                    StudentInfo.Religion = reader.GetString("religion");
                    StudentInfo.ContactNo = reader.GetString("contactNo");
                    StudentInfo.Email = reader.GetString("email");
                    StudentInfo.Address = reader.GetString("address");
                    StudentInfo.brgyCode = reader.GetString("brgyCode");
                    StudentInfo.Barangay = reader.GetString("brgyDesc");
                    StudentInfo.citymunCode = reader.GetString("citymunCode");
                    StudentInfo.CityMunicipality = reader.GetString("citymunDesc");
                    StudentInfo.provCode = reader.GetString("provCode");
                    StudentInfo.Province = reader.GetString("provDesc");
                    StudentInfo.year = reader.GetString("year");
                    StudentInfo.Course = reader.GetString("courseDesc");
                    StudentInfo.CourseCode = reader.GetString("courseCode");
                    StudentInfo.CourseMajor = reader.GetString("major");
                    StudentInfo.FatherName = reader.GetString("ffullname");
                    StudentInfo.FatherEducAttain = reader.GetString("feducation");
                    StudentInfo.FatherOccupation = reader.GetString("foccupation");
                    StudentInfo.MotherName = reader.GetString("mfullname");
                    StudentInfo.MotherEducAttain = reader.GetString("meducation");
                    StudentInfo.MotherOccupation = reader.GetString("moccupation");
                    StudentInfo.GuardianName = reader.GetString("gfullname");
                    StudentInfo.GuardianRelation = reader.GetString("grelationship");
                    StudentInfo.ParentsContactNo = reader.GetString("parentContactNo");
                    StudentInfo.ParentsAddress = reader.GetString("parentAddress");
                    StudentInfo.image = (byte[])reader["image"];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN");   
            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }

            return StudentInfo;
        }

        public bool update(Student stud)
        {
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_student INNER JOIN tbl_image ON tbl_image.studID = tbl_student.studID SET  fname = @FirstName, mi = @Mi, lname = @LastName, gender =  @Gender, dob =  @DateOfBirth, pob = @PlaceOfBirth, religionID = @Religion, address = @Address, brgyCode = @BrgyCode, citymunCode = @CityMunCode, provCode =  @ProvCode, contactNo =  @ContactNo,  email =  @Email, ffullname = @FatherName, mfullname =  @MotherName,  feducation = @FatherEducation,  meducation = @MotherEducation, foccupation =  @FatherOccupation, moccupation = @MotherOccupation, gfullname =@GuardianName, grelationship = @GuardianRelationship, parentContactNo = @ParentContactNo, parentAddress = @ParentAddress, year = @Year, courseCode =  @CourseCode, major =  @Major,image = @Image  WHERE tbl_student.studID = @StudID";
                cmd.Parameters.AddWithValue("@StudID", stud.StudID);
                cmd.Parameters.AddWithValue("@FirstName", stud.FirstName);
                cmd.Parameters.AddWithValue("@Mi", stud.MI);
                cmd.Parameters.AddWithValue("@LastName", stud.LastName);
                cmd.Parameters.AddWithValue("@Gender", stud.Gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", stud.DateOfBirth);
                cmd.Parameters.AddWithValue("@PlaceOfBirth", stud.PlaceOfBirth);
                cmd.Parameters.AddWithValue("@Religion", stud.religionID);
                cmd.Parameters.AddWithValue("@Address", stud.Address);
                cmd.Parameters.AddWithValue("@BrgyCode", stud.brgyCode);
                cmd.Parameters.AddWithValue("@CityMunCode", stud.citymunCode);
                cmd.Parameters.AddWithValue("@ProvCode", stud.provCode);
                cmd.Parameters.AddWithValue("@ContactNo", stud.ContactNo);
                cmd.Parameters.AddWithValue("@Email", stud.Email);
                cmd.Parameters.AddWithValue("@FatherName", stud.FatherName);
                cmd.Parameters.AddWithValue("@MotherName", stud.MotherName);
                cmd.Parameters.AddWithValue("@FatherEducation", stud.FatherEducAttain);
                cmd.Parameters.AddWithValue("@MotherEducation", stud.MotherEducAttain);
                cmd.Parameters.AddWithValue("@FatherOccupation", stud.FatherOccupation);
                cmd.Parameters.AddWithValue("@MotherOccupation", stud.MotherOccupation);
                cmd.Parameters.AddWithValue("@GuardianName", stud.GuardianName);
                cmd.Parameters.AddWithValue("@GuardianRelationship", stud.GuardianRelation);
                cmd.Parameters.AddWithValue("@ParentContactNo", stud.ParentsContactNo);
                cmd.Parameters.AddWithValue("@ParentAddress", stud.ParentsAddress);
                cmd.Parameters.AddWithValue("@Year", stud.year);
                cmd.Parameters.AddWithValue("@CourseCode", stud.CourseCode);
                cmd.Parameters.AddWithValue("@Major", stud.CourseMajor);
                cmd.Parameters.AddWithValue("@Image", stud.image);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN!");
                return false;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
        }
        public IList<ReligionList> getReligion(string _search)
        {
           List<ReligionList> ReligionList = new List<ReligionList>();
            try
            {
                connect();
                cmd.CommandText = "SELECT * FROM tbl_religion WHERE religion LIKE @Religion";
                cmd.Parameters.AddWithValue("@Religion", $"%{_search}%");
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var religion = new ReligionList();
                    religion.id = reader.GetString("id");
                    religion.Religion = reader.GetString("religion").ToUpper();
                    ReligionList.Add(religion);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN");
            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }

            return ReligionList;
        }

        public string getStudID()
        {
            string studid = null;
            try
            {
                connect();
                cmd.CommandText = "SELECT studID from tbl_student ORDER BY studID DESC LIMIT 1";
                reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    studid = reader.GetString("studID");
                    studid = Regex.Replace(studid,@"([A-Z,-])","");
                    studid = $"ESU-PAGA-{(Convert.ToInt32(studid) + 1).ToString("D8")}";
                }
                else
                    studid =  "ESU-PAGA-00001";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +$"\n {reader.GetString("studID")}" , "WMSU-ESU");
            }
            finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
                return studid;
        }
    }

    
   


}
