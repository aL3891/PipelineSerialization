using System;
using System.IO.Pipelines;
using System.Text.Formatting;
using System.Text;

public class GeneratedSerializer
{
    static Span<byte> span = new Span<byte>(Encoding.UTF8.GetBytes("{\"Id\" : ,\"EnrollmentServiceId\" : ,\"EnrollmentId\" : ,\"ServiceId\" : ,\"ProviderId\" : ,\"Enrollment\" : {\"Id\" : ,\"ClientId\" : ,\"PrimaryCaseManager\" : {\"Id\" : ,\"UserId\" : ,\"CreatedDate\" : '',\"UpdatedDate\" : '',\"UpdateBy\" : ''},\"SecondaryCaseManager\" : {\"Id\" : '},\"ProgramId\" : ,\"Program\" : {\"Id\" : ,\"ProgramId\" : ,\"Name\" : '',\"Enrollments\" : {\"Count\" : truefalse,\"IsReadOnly\" : },\"Services\" : {\"Count\" : ,\"IsReadOnly\" : },\"CreatedDate\" : ''},\"Client\" : {\"Id\" : ,\"HomeAddress\" : {\"Street1\" : '',\"Street2\" : '',\"Zip\" : ,\"City\" : '',\"State\" : ''},\"Docs\" : {\"Count\" : ,\"IsReadOnly\" : },\"Notes\" : {\"Count\" : ,\"IsReadOnly\" : },\"Enrollments\" : {\"Count\" : ,\"IsReadOnly\" : },\"Contacts\" : {\"Count\" : ,\"IsReadOnly\" : },\"CareSettings\" : {\"Count\" : '},\"EnrollmentServices\" : {\"Count\" : ,\"IsReadOnly\" : },\"Documents\" : {\"Count\" : '},\"Service\" : {\"Id\" : ,\"Code\" : '',\"Name\" : '',\"SubName\" : '',\"Providers\" : {\"Count\" : ,\"IsReadOnly\" : },\"Program\" : {\"Id\" : '},\"CreatedDate\" : ''},\"Provider\" : {\"Id\" : ',\"Services\" : {\"Count\" : '}"));
    static Span<byte> slice0 = span.Slice(0, 8);
    static Span<byte> slice8 = span.Slice(8, 25);
    static Span<byte> slice33 = span.Slice(33, 18);
    static Span<byte> slice51 = span.Slice(51, 15);
    static Span<byte> slice66 = span.Slice(66, 16);
    static Span<byte> slice82 = span.Slice(82, 24);
    static Span<byte> slice106 = span.Slice(106, 14);
    static Span<byte> slice120 = span.Slice(120, 32);
    static Span<byte> slice152 = span.Slice(152, 12);
    static Span<byte> slice164 = span.Slice(164, 18);
    static Span<byte> slice182 = span.Slice(182, 19);
    static Span<byte> slice201 = span.Slice(201, 16);
    static Span<byte> slice217 = span.Slice(217, 36);
    static Span<byte> slice253 = span.Slice(253, 17);
    static Span<byte> slice270 = span.Slice(270, 21);
    static Span<byte> slice291 = span.Slice(291, 15);
    static Span<byte> slice306 = span.Slice(306, 11);
    static Span<byte> slice317 = span.Slice(317, 29);
    static Span<byte> slice346 = span.Slice(346, 4);
    static Span<byte> slice350 = span.Slice(350, 5);
    static Span<byte> slice355 = span.Slice(355, 42);
    static Span<byte> slice397 = span.Slice(397, 35);
    static Span<byte> slice432 = span.Slice(432, 22);
    static Span<byte> slice454 = span.Slice(454, 31);
    static Span<byte> slice485 = span.Slice(485, 15);
    static Span<byte> slice500 = span.Slice(500, 10);
    static Span<byte> slice510 = span.Slice(510, 11);
    static Span<byte> slice521 = span.Slice(521, 13);
    static Span<byte> slice534 = span.Slice(534, 23);
    static Span<byte> slice557 = span.Slice(557, 39);
    static Span<byte> slice596 = span.Slice(596, 45);
    static Span<byte> slice641 = span.Slice(641, 42);
    static Span<byte> slice683 = span.Slice(683, 46);
    static Span<byte> slice729 = span.Slice(729, 37);
    static Span<byte> slice766 = span.Slice(766, 43);
    static Span<byte> slice809 = span.Slice(809, 23);
    static Span<byte> slice832 = span.Slice(832, 11);
    static Span<byte> slice843 = span.Slice(843, 12);
    static Span<byte> slice855 = span.Slice(855, 15);
    static Span<byte> slice870 = span.Slice(870, 27);
    static Span<byte> slice897 = span.Slice(897, 38);
    static Span<byte> slice935 = span.Slice(935, 20);
    static Span<byte> slice955 = span.Slice(955, 24);
    static Span<byte> slice979 = span.Slice(979, 26);
    static Span<byte> slice1005 = span.Slice(1005, 2);
    public void Serializer(WritableBuffer wb, System.IO.Pipelines.Samples.Models.Model t)
    {
        var enc = TextEncoder.Utf8;
        wb.Write(slice0);
        wb.Append(t.Id, enc);
        wb.Write(slice8);
        wb.Append(t.EnrollmentServiceId, enc);
        wb.Write(slice33);
        wb.Append(t.EnrollmentId, enc);
        wb.Write(slice51);
        wb.Append(t.ServiceId, enc);
        wb.Write(slice66);
        wb.Append(t.ProviderId, enc);
        wb.Write(slice82);
        wb.Append(t.Enrollment.Id, enc);
        wb.Write(slice33);
        wb.Append(t.Enrollment.EnrollmentId, enc);
        wb.Write(slice106);
        wb.Append(t.Enrollment.ClientId, enc);
        wb.Write(slice120);
        wb.Append(t.Enrollment.PrimaryCaseManager.Id, enc);
        wb.Write(slice152);
        wb.Append(t.Enrollment.PrimaryCaseManager.UserId, enc);
        wb.Write(slice164);
        wb.Append(t.Enrollment.PrimaryCaseManager.CreatedDate.ToString(), enc);
        wb.Write(slice182);
        wb.Append(t.Enrollment.PrimaryCaseManager.UpdatedDate.ToString(), enc);
        wb.Write(slice201);
        wb.Append(t.Enrollment.PrimaryCaseManager.UpdateBy, enc);
        wb.Write(slice217);
        wb.Append(t.Enrollment.SecondaryCaseManager.Id, enc);
        wb.Write(slice152);
        wb.Append(t.Enrollment.SecondaryCaseManager.UserId, enc);
        wb.Write(slice164);
        wb.Append(t.Enrollment.SecondaryCaseManager.CreatedDate.ToString(), enc);
        wb.Write(slice182);
        wb.Append(t.Enrollment.SecondaryCaseManager.UpdatedDate.ToString(), enc);
        wb.Write(slice201);
        wb.Append(t.Enrollment.SecondaryCaseManager.UpdateBy, enc);
        wb.Write(slice253);
        wb.Append(t.Enrollment.ProgramId, enc);
        wb.Write(slice270);
        wb.Append(t.Enrollment.Program.Id, enc);
        wb.Write(slice291);
        wb.Append(t.Enrollment.Program.ProgramId, enc);
        wb.Write(slice306);
        wb.Append(t.Enrollment.Program.Name, enc);
        wb.Write(slice317);
        wb.Append(t.Enrollment.Program.Enrollments.Count, enc);
        if (t.Enrollment.Program.Enrollments.IsReadOnly)
        {
            wb.Write(slice346);
        }
        else
        {
            wb.Write(slice350);
        }

        wb.Write(slice355);
        wb.Append(t.Enrollment.Program.Services.Count, enc);
        if (t.Enrollment.Program.Services.IsReadOnly)
        {
            wb.Write(slice346);
        }
        else
        {
            wb.Write(slice350);
        }

        wb.Write(slice397);
        wb.Append(t.Enrollment.Program.CreatedDate.ToString(), enc);
        wb.Write(slice182);
        wb.Append(t.Enrollment.Program.UpdatedDate.ToString(), enc);
        wb.Write(slice201);
        wb.Append(t.Enrollment.Program.UpdateBy, enc);
        wb.Write(slice432);
        wb.Append(t.Enrollment.Client.Id, enc);
        wb.Write(slice106);
        wb.Append(t.Enrollment.Client.ClientId, enc);
        wb.Write(slice454);
        wb.Append(t.Enrollment.Client.HomeAddress.Street1, enc);
        wb.Write(slice485);
        wb.Append(t.Enrollment.Client.HomeAddress.Street2, enc);
        wb.Write(slice500);
        wb.Append(t.Enrollment.Client.HomeAddress.Zip, enc);
        wb.Write(slice510);
        wb.Append(t.Enrollment.Client.HomeAddress.City, enc);
        wb.Write(slice521);
        wb.Append(t.Enrollment.Client.HomeAddress.State, enc);
        wb.Write(slice534);
        wb.Append(t.Enrollment.Client.Docs.Count, enc);
        if (t.Enrollment.Client.Docs.IsReadOnly)
        {
            wb.Write(slice346);
        }
        else
        {
            wb.Write(slice350);
        }

        wb.Write(slice557);
        wb.Append(t.Enrollment.Client.Notes.Count, enc);
        if (t.Enrollment.Client.Notes.IsReadOnly)
        {
            wb.Write(slice346);
        }
        else
        {
            wb.Write(slice350);
        }

        wb.Write(slice596);
        wb.Append(t.Enrollment.Client.Enrollments.Count, enc);
        if (t.Enrollment.Client.Enrollments.IsReadOnly)
        {
            wb.Write(slice346);
        }
        else
        {
            wb.Write(slice350);
        }

        wb.Write(slice641);
        wb.Append(t.Enrollment.Client.Contacts.Count, enc);
        if (t.Enrollment.Client.Contacts.IsReadOnly)
        {
            wb.Write(slice346);
        }
        else
        {
            wb.Write(slice350);
        }

        wb.Write(slice683);
        wb.Append(t.Enrollment.Client.CareSettings.Count, enc);
        if (t.Enrollment.Client.CareSettings.IsReadOnly)
        {
            wb.Write(slice346);
        }
        else
        {
            wb.Write(slice350);
        }

        wb.Write(slice397);
        wb.Append(t.Enrollment.Client.CreatedDate.ToString(), enc);
        wb.Write(slice182);
        wb.Append(t.Enrollment.Client.UpdatedDate.ToString(), enc);
        wb.Write(slice201);
        wb.Append(t.Enrollment.Client.UpdateBy, enc);
        wb.Write(slice729);
        wb.Append(t.Enrollment.EnrollmentServices.Count, enc);
        if (t.Enrollment.EnrollmentServices.IsReadOnly)
        {
            wb.Write(slice346);
        }
        else
        {
            wb.Write(slice350);
        }

        wb.Write(slice766);
        wb.Append(t.Enrollment.Documents.Count, enc);
        if (t.Enrollment.Documents.IsReadOnly)
        {
            wb.Write(slice346);
        }
        else
        {
            wb.Write(slice350);
        }

        wb.Write(slice557);
        wb.Append(t.Enrollment.Notes.Count, enc);
        if (t.Enrollment.Notes.IsReadOnly)
        {
            wb.Write(slice346);
        }
        else
        {
            wb.Write(slice350);
        }

        wb.Write(slice397);
        wb.Append(t.Enrollment.CreatedDate.ToString(), enc);
        wb.Write(slice182);
        wb.Append(t.Enrollment.UpdatedDate.ToString(), enc);
        wb.Write(slice201);
        wb.Append(t.Enrollment.UpdateBy, enc);
        wb.Write(slice809);
        wb.Append(t.Service.Id, enc);
        wb.Write(slice51);
        wb.Append(t.Service.ServiceId, enc);
        wb.Write(slice291);
        wb.Append(t.Service.ProgramId, enc);
        wb.Write(slice832);
        wb.Append(t.Service.Code, enc);
        wb.Write(slice843);
        wb.Append(t.Service.Name, enc);
        wb.Write(slice855);
        wb.Append(t.Service.SubName, enc);
        wb.Write(slice870);
        wb.Append(t.Service.Providers.Count, enc);
        if (t.Service.Providers.IsReadOnly)
        {
            wb.Write(slice346);
        }
        else
        {
            wb.Write(slice350);
        }

        wb.Write(slice897);
        wb.Append(t.Service.Program.Id, enc);
        wb.Write(slice291);
        wb.Append(t.Service.Program.ProgramId, enc);
        wb.Write(slice306);
        wb.Append(t.Service.Program.Name, enc);
        wb.Write(slice317);
        wb.Append(t.Service.Program.Enrollments.Count, enc);
        if (t.Service.Program.Enrollments.IsReadOnly)
        {
            wb.Write(slice346);
        }
        else
        {
            wb.Write(slice350);
        }

        wb.Write(slice355);
        wb.Append(t.Service.Program.Services.Count, enc);
        if (t.Service.Program.Services.IsReadOnly)
        {
            wb.Write(slice346);
        }
        else
        {
            wb.Write(slice350);
        }

        wb.Write(slice397);
        wb.Append(t.Service.Program.CreatedDate.ToString(), enc);
        wb.Write(slice182);
        wb.Append(t.Service.Program.UpdatedDate.ToString(), enc);
        wb.Write(slice201);
        wb.Append(t.Service.Program.UpdateBy, enc);
        wb.Write(slice935);
        wb.Append(t.Service.CreatedDate.ToString(), enc);
        wb.Write(slice182);
        wb.Append(t.Service.UpdatedDate.ToString(), enc);
        wb.Write(slice201);
        wb.Append(t.Service.UpdateBy, enc);
        wb.Write(slice955);
        wb.Append(t.Provider.Id, enc);
        wb.Write(slice66);
        wb.Append(t.Provider.ProviderId, enc);
        wb.Write(slice306);
        wb.Append(t.Provider.Name, enc);
        wb.Write(slice979);
        wb.Append(t.Provider.Services.Count, enc);
        if (t.Provider.Services.IsReadOnly)
        {
            wb.Write(slice346);
        }
        else
        {
            wb.Write(slice350);
        }

        wb.Write(slice397);
        wb.Append(t.Provider.CreatedDate.ToString(), enc);
        wb.Write(slice182);
        wb.Append(t.Provider.UpdatedDate.ToString(), enc);
        wb.Write(slice201);
        wb.Append(t.Provider.UpdateBy, enc);
        wb.Write(slice935);
        wb.Append(t.CreatedDate.ToString(), enc);
        wb.Write(slice182);
        wb.Append(t.UpdatedDate.ToString(), enc);
        wb.Write(slice201);
        wb.Append(t.UpdateBy, enc);
        wb.Write(slice1005);
    }
}