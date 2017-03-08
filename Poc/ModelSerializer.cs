using System;
using System.IO.Pipelines;
using System.Text.Formatting;
using System.Text;

public class ModelSerializer
{
    static Span<byte> span = new Span<byte>(Encoding.UTF8.GetBytes("{\"Id\" : ,\"EnrollmentServiceId\" : ,\"EnrollmentId\" : ,\"ServiceId\" : ,\"ProviderId\" : ,\"Enrollment\" : {\"Id\" : ,\"ClientId\" : ,\"PrimaryCaseManager\" : {\"Id\" : ,\"UserId\" : ,\"CreatedDate\" : '',\"UpdatedDate\" : '',\"UpdateBy\" : ''},\"SecondaryCaseManager\" : {\"Id\" : '},\"ProgramId\" : ,\"Program\" : {\"Id\" : ,\"ProgramId\" : ,\"Name\" : '',\"Enrollments\" : {\"Count\" : ,\"IsReadOnly\" : },\"Services\" : {\"Count\" : },\"CreatedDate\" : ''},\"Client\" : {\"Id\" : ,\"HomeAddress\" : {\"Street1\" : '',\"Street2\" : '',\"Zip\" : ,\"City\" : '',\"State\" : ''},\"Docs\" : {\"Count\" : },\"Notes\" : {\"Count\" : },\"Enrollments\" : {\"Count\" : },\"Contacts\" : {\"Count\" : },\"CareSettings\" : {\"Count\" : '},\"EnrollmentServices\" : {\"Count\" : },\"Documents\" : {\"Count\" : '},\"Service\" : {\"Id\" : ,\"Code\" : '',\"Name\" : '',\"SubName\" : '',\"Providers\" : {\"Count\" : },\"Program\" : {\"Id\" : '},\"CreatedDate\" : ''},\"Provider\" : {\"Id\" : ',\"Services\" : {\"Count\" : '}"));
    public static void Serializer(WritableBuffer wb, System.IO.Pipelines.Samples.Models.Model t)
    {
        var enc = TextEncoder.Utf8;
        wb.Write(span.Slice(0, 8));
        wb.Append(t.Id, enc);
        wb.Write(span.Slice(8, 25));
        wb.Append(t.EnrollmentServiceId, enc);
        wb.Write(span.Slice(33, 18));
        wb.Append(t.EnrollmentId, enc);
        wb.Write(span.Slice(51, 15));
        wb.Append(t.ServiceId, enc);
        wb.Write(span.Slice(66, 16));
        wb.Append(t.ProviderId, enc);
        wb.Write(span.Slice(82, 24));
        wb.Append(t.Enrollment.Id, enc);
        wb.Write(span.Slice(33, 18));
        wb.Append(t.Enrollment.EnrollmentId, enc);
        wb.Write(span.Slice(106, 14));
        wb.Append(t.Enrollment.ClientId, enc);
        wb.Write(span.Slice(120, 32));
        wb.Append(t.Enrollment.PrimaryCaseManager.Id, enc);
        wb.Write(span.Slice(152, 12));
        wb.Append(t.Enrollment.PrimaryCaseManager.UserId, enc);
        wb.Write(span.Slice(164, 18));
        wb.Append(t.Enrollment.PrimaryCaseManager.CreatedDate.ToString(), enc);
        wb.Write(span.Slice(182, 19));
        wb.Append(t.Enrollment.PrimaryCaseManager.UpdatedDate.ToString(), enc);
        wb.Write(span.Slice(201, 16));
        wb.Append(t.Enrollment.PrimaryCaseManager.UpdateBy, enc);
        wb.Write(span.Slice(217, 36));
        wb.Append(t.Enrollment.SecondaryCaseManager.Id, enc);
        wb.Write(span.Slice(152, 12));
        wb.Append(t.Enrollment.SecondaryCaseManager.UserId, enc);
        wb.Write(span.Slice(164, 18));
        wb.Append(t.Enrollment.SecondaryCaseManager.CreatedDate.ToString(), enc);
        wb.Write(span.Slice(182, 19));
        wb.Append(t.Enrollment.SecondaryCaseManager.UpdatedDate.ToString(), enc);
        wb.Write(span.Slice(201, 16));
        wb.Append(t.Enrollment.SecondaryCaseManager.UpdateBy, enc);
        wb.Write(span.Slice(253, 17));
        wb.Append(t.Enrollment.ProgramId, enc);
        wb.Write(span.Slice(270, 21));
        wb.Append(t.Enrollment.Program.Id, enc);
        wb.Write(span.Slice(291, 15));
        wb.Append(t.Enrollment.Program.ProgramId, enc);
        wb.Write(span.Slice(306, 11));
        wb.Append(t.Enrollment.Program.Name, enc);
        wb.Write(span.Slice(317, 29));
        wb.Append(t.Enrollment.Program.Enrollments.Count, enc);
        wb.Write(span.Slice(346, 16));
        if (t.Enrollment.Program.Enrollments.IsReadOnly)
            wb.Append("true", enc);
        else
            wb.Append("false", enc);
        wb.Write(span.Slice(362, 26));
        wb.Append(t.Enrollment.Program.Services.Count, enc);
        wb.Write(span.Slice(346, 16));
        if (t.Enrollment.Program.Services.IsReadOnly)
            wb.Append("true", enc);
        else
            wb.Append("false", enc);
        wb.Write(span.Slice(388, 19));
        wb.Append(t.Enrollment.Program.CreatedDate.ToString(), enc);
        wb.Write(span.Slice(182, 19));
        wb.Append(t.Enrollment.Program.UpdatedDate.ToString(), enc);
        wb.Write(span.Slice(201, 16));
        wb.Append(t.Enrollment.Program.UpdateBy, enc);
        wb.Write(span.Slice(407, 22));
        wb.Append(t.Enrollment.Client.Id, enc);
        wb.Write(span.Slice(106, 14));
        wb.Append(t.Enrollment.Client.ClientId, enc);
        wb.Write(span.Slice(429, 31));
        wb.Append(t.Enrollment.Client.HomeAddress.Street1, enc);
        wb.Write(span.Slice(460, 15));
        wb.Append(t.Enrollment.Client.HomeAddress.Street2, enc);
        wb.Write(span.Slice(475, 10));
        wb.Append(t.Enrollment.Client.HomeAddress.Zip, enc);
        wb.Write(span.Slice(485, 11));
        wb.Append(t.Enrollment.Client.HomeAddress.City, enc);
        wb.Write(span.Slice(496, 13));
        wb.Append(t.Enrollment.Client.HomeAddress.State, enc);
        wb.Write(span.Slice(509, 23));
        wb.Append(t.Enrollment.Client.Docs.Count, enc);
        wb.Write(span.Slice(346, 16));
        if (t.Enrollment.Client.Docs.IsReadOnly)
            wb.Append("true", enc);
        else
            wb.Append("false", enc);
        wb.Write(span.Slice(532, 23));
        wb.Append(t.Enrollment.Client.Notes.Count, enc);
        wb.Write(span.Slice(346, 16));
        if (t.Enrollment.Client.Notes.IsReadOnly)
            wb.Append("true", enc);
        else
            wb.Append("false", enc);
        wb.Write(span.Slice(555, 29));
        wb.Append(t.Enrollment.Client.Enrollments.Count, enc);
        wb.Write(span.Slice(346, 16));
        if (t.Enrollment.Client.Enrollments.IsReadOnly)
            wb.Append("true", enc);
        else
            wb.Append("false", enc);
        wb.Write(span.Slice(584, 26));
        wb.Append(t.Enrollment.Client.Contacts.Count, enc);
        wb.Write(span.Slice(346, 16));
        if (t.Enrollment.Client.Contacts.IsReadOnly)
            wb.Append("true", enc);
        else
            wb.Append("false", enc);
        wb.Write(span.Slice(610, 30));
        wb.Append(t.Enrollment.Client.CareSettings.Count, enc);
        wb.Write(span.Slice(346, 16));
        if (t.Enrollment.Client.CareSettings.IsReadOnly)
            wb.Append("true", enc);
        else
            wb.Append("false", enc);
        wb.Write(span.Slice(388, 19));
        wb.Append(t.Enrollment.Client.CreatedDate.ToString(), enc);
        wb.Write(span.Slice(182, 19));
        wb.Append(t.Enrollment.Client.UpdatedDate.ToString(), enc);
        wb.Write(span.Slice(201, 16));
        wb.Append(t.Enrollment.Client.UpdateBy, enc);
        wb.Write(span.Slice(640, 37));
        wb.Append(t.Enrollment.EnrollmentServices.Count, enc);
        wb.Write(span.Slice(346, 16));
        if (t.Enrollment.EnrollmentServices.IsReadOnly)
            wb.Append("true", enc);
        else
            wb.Append("false", enc);
        wb.Write(span.Slice(677, 27));
        wb.Append(t.Enrollment.Documents.Count, enc);
        wb.Write(span.Slice(346, 16));
        if (t.Enrollment.Documents.IsReadOnly)
            wb.Append("true", enc);
        else
            wb.Append("false", enc);
        wb.Write(span.Slice(532, 23));
        wb.Append(t.Enrollment.Notes.Count, enc);
        wb.Write(span.Slice(346, 16));
        if (t.Enrollment.Notes.IsReadOnly)
            wb.Append("true", enc);
        else
            wb.Append("false", enc);
        wb.Write(span.Slice(388, 19));
        wb.Append(t.Enrollment.CreatedDate.ToString(), enc);
        wb.Write(span.Slice(182, 19));
        wb.Append(t.Enrollment.UpdatedDate.ToString(), enc);
        wb.Write(span.Slice(201, 16));
        wb.Append(t.Enrollment.UpdateBy, enc);
        wb.Write(span.Slice(704, 23));
        wb.Append(t.Service.Id, enc);
        wb.Write(span.Slice(51, 15));
        wb.Append(t.Service.ServiceId, enc);
        wb.Write(span.Slice(291, 15));
        wb.Append(t.Service.ProgramId, enc);
        wb.Write(span.Slice(727, 11));
        wb.Append(t.Service.Code, enc);
        wb.Write(span.Slice(738, 12));
        wb.Append(t.Service.Name, enc);
        wb.Write(span.Slice(750, 15));
        wb.Append(t.Service.SubName, enc);
        wb.Write(span.Slice(765, 27));
        wb.Append(t.Service.Providers.Count, enc);
        wb.Write(span.Slice(346, 16));
        if (t.Service.Providers.IsReadOnly)
            wb.Append("true", enc);
        else
            wb.Append("false", enc);
        wb.Write(span.Slice(792, 22));
        wb.Append(t.Service.Program.Id, enc);
        wb.Write(span.Slice(291, 15));
        wb.Append(t.Service.Program.ProgramId, enc);
        wb.Write(span.Slice(306, 11));
        wb.Append(t.Service.Program.Name, enc);
        wb.Write(span.Slice(317, 29));
        wb.Append(t.Service.Program.Enrollments.Count, enc);
        wb.Write(span.Slice(346, 16));
        if (t.Service.Program.Enrollments.IsReadOnly)
            wb.Append("true", enc);
        else
            wb.Append("false", enc);
        wb.Write(span.Slice(362, 26));
        wb.Append(t.Service.Program.Services.Count, enc);
        wb.Write(span.Slice(346, 16));
        if (t.Service.Program.Services.IsReadOnly)
            wb.Append("true", enc);
        else
            wb.Append("false", enc);
        wb.Write(span.Slice(388, 19));
        wb.Append(t.Service.Program.CreatedDate.ToString(), enc);
        wb.Write(span.Slice(182, 19));
        wb.Append(t.Service.Program.UpdatedDate.ToString(), enc);
        wb.Write(span.Slice(201, 16));
        wb.Append(t.Service.Program.UpdateBy, enc);
        wb.Write(span.Slice(814, 20));
        wb.Append(t.Service.CreatedDate.ToString(), enc);
        wb.Write(span.Slice(182, 19));
        wb.Append(t.Service.UpdatedDate.ToString(), enc);
        wb.Write(span.Slice(201, 16));
        wb.Append(t.Service.UpdateBy, enc);
        wb.Write(span.Slice(834, 24));
        wb.Append(t.Provider.Id, enc);
        wb.Write(span.Slice(66, 16));
        wb.Append(t.Provider.ProviderId, enc);
        wb.Write(span.Slice(306, 11));
        wb.Append(t.Provider.Name, enc);
        wb.Write(span.Slice(858, 26));
        wb.Append(t.Provider.Services.Count, enc);
        wb.Write(span.Slice(346, 16));
        if (t.Provider.Services.IsReadOnly)
            wb.Append("true", enc);
        else
            wb.Append("false", enc);
        wb.Write(span.Slice(388, 19));
        wb.Append(t.Provider.CreatedDate.ToString(), enc);
        wb.Write(span.Slice(182, 19));
        wb.Append(t.Provider.UpdatedDate.ToString(), enc);
        wb.Write(span.Slice(201, 16));
        wb.Append(t.Provider.UpdateBy, enc);
        wb.Write(span.Slice(814, 20));
        wb.Append(t.CreatedDate.ToString(), enc);
        wb.Write(span.Slice(182, 19));
        wb.Append(t.UpdatedDate.ToString(), enc);
        wb.Write(span.Slice(201, 16));
        wb.Append(t.UpdateBy, enc);
        wb.Write(span.Slice(884, 2));
    }
}