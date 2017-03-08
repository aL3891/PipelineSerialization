using System;
using System.IO.Pipelines;
using System.Text.Formatting;
using System.Text;

public static partial class ModelSerializer
{
    static Span<byte> span = new Span<byte>(Encoding.UTF8.GetBytes("{\"Id\" : ,\"EnrollmentServiceId\" : ,\"EnrollmentId\" : ,\"ServiceId\" : ,\"ProviderId\" : ,\"ClientId\" : ,\"UserId\" : ,\"CreatedDate\" : '',\"UpdatedDate\" : ''',\"UpdateBy\" : },\"PrimaryCaseManager\" : ,\"SecondaryCaseManager\" : ,\"ProgramId\" : ,\"ProgramId\" : {\"Count\" : truefalse,\"IsReadOnly\" : },\"Name\" : ,\"Enrollments\" : ,\"Services\" : ,\"CreatedDate\" : '{\"Street1\" : ,\"Street2\" : ,\"Zip\" : ,\"City\" : ,\"State\" : },\"HomeAddress\" : ,\"Docs\" : ,\"Notes\" : ,\"Enrollments\" : ,\"Contacts\" : ,\"CareSettings\" : ,\"CreatedDate\" : ',\"Program\" : ,\"Client\" : ,\"EnrollmentServices\" : ,\"Documents\" : ,\"Notes\" : ,\"CreatedDate\" : ',\"Code\" : ,\"Name\" : ,\"SubName\" : ,\"Providers\" : ,\"Program\" : ,\"CreatedDate\" : ',\"Name\" : ,\"Services\" : ,\"CreatedDate\" : ',\"Enrollment\" : ,\"Service\" : ,\"Provider\" : ,\"CreatedDate\" : '"));
    static Span<byte> slice0 = span.Slice(0, 8);
    static Span<byte> slice8 = span.Slice(8, 25);
    static Span<byte> slice33 = span.Slice(33, 18);
    static Span<byte> slice51 = span.Slice(51, 15);
    static Span<byte> slice66 = span.Slice(66, 16);
    static Span<byte> slice82 = span.Slice(82, 14);
    static Span<byte> slice96 = span.Slice(96, 12);
    static Span<byte> slice108 = span.Slice(108, 18);
    static Span<byte> slice126 = span.Slice(126, 19);
    static Span<byte> slice145 = span.Slice(145, 1);
    static Span<byte> slice146 = span.Slice(146, 16);
    static Span<byte> slice162 = span.Slice(162, 65);
    static Span<byte> slice227 = span.Slice(227, 15);
    static Span<byte> slice242 = span.Slice(242, 11);
    static Span<byte> slice253 = span.Slice(253, 4);
    static Span<byte> slice257 = span.Slice(257, 5);
    static Span<byte> slice262 = span.Slice(262, 17);
    static Span<byte> slice279 = span.Slice(279, 59);
    static Span<byte> slice338 = span.Slice(338, 35);
    static Span<byte> slice373 = span.Slice(373, 22);
    static Span<byte> slice395 = span.Slice(395, 105);
    static Span<byte> slice500 = span.Slice(500, 93);
    static Span<byte> slice593 = span.Slice(593, 79);
    static Span<byte> slice672 = span.Slice(672, 42);
    static Span<byte> slice714 = span.Slice(714, 61);
    public static void Serialize(WritableBuffer wb, System.IO.Pipelines.Samples.Models.Model t)
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
        if (t.Enrollment != null)
        {
            wb.Write(slice0);
            wb.Append(t.Enrollment.Id, enc);
            wb.Write(slice33);
            wb.Append(t.Enrollment.EnrollmentId, enc);
            wb.Write(slice82);
            wb.Append(t.Enrollment.ClientId, enc);
            if (t.Enrollment.PrimaryCaseManager != null)
            {
                wb.Write(slice0);
                wb.Append(t.Enrollment.PrimaryCaseManager.Id, enc);
                wb.Write(slice96);
                wb.Append(t.Enrollment.PrimaryCaseManager.UserId, enc);
                wb.Write(slice108);
                wb.Append(t.Enrollment.PrimaryCaseManager.CreatedDate.ToString(), enc);
                wb.Write(slice126);
                wb.Append(t.Enrollment.PrimaryCaseManager.UpdatedDate.ToString(), enc);
                if (t.Enrollment.PrimaryCaseManager.UpdateBy != null)
                {
                    wb.Write(slice145);
                    wb.Append(t.Enrollment.PrimaryCaseManager.UpdateBy, enc);
                    wb.Write(slice145);
                }

                wb.Write(slice146);
            }

            if (t.Enrollment.SecondaryCaseManager != null)
            {
                wb.Write(slice0);
                wb.Append(t.Enrollment.SecondaryCaseManager.Id, enc);
                wb.Write(slice96);
                wb.Append(t.Enrollment.SecondaryCaseManager.UserId, enc);
                wb.Write(slice108);
                wb.Append(t.Enrollment.SecondaryCaseManager.CreatedDate.ToString(), enc);
                wb.Write(slice126);
                wb.Append(t.Enrollment.SecondaryCaseManager.UpdatedDate.ToString(), enc);
                if (t.Enrollment.SecondaryCaseManager.UpdateBy != null)
                {
                    wb.Write(slice145);
                    wb.Append(t.Enrollment.SecondaryCaseManager.UpdateBy, enc);
                    wb.Write(slice145);
                }

                wb.Write(slice146);
            }

            wb.Write(slice162);
            wb.Append(t.Enrollment.ProgramId, enc);
            if (t.Enrollment.Program != null)
            {
                wb.Write(slice0);
                wb.Append(t.Enrollment.Program.Id, enc);
                wb.Write(slice227);
                wb.Append(t.Enrollment.Program.ProgramId, enc);
                if (t.Enrollment.Program.Name != null)
                {
                    wb.Write(slice145);
                    wb.Append(t.Enrollment.Program.Name, enc);
                    wb.Write(slice145);
                }

                if (t.Enrollment.Program.Enrollments != null)
                {
                    wb.Write(slice242);
                    wb.Append(t.Enrollment.Program.Enrollments.Count, enc);
                    if (t.Enrollment.Program.Enrollments.IsReadOnly)
                    {
                        wb.Write(slice253);
                    }
                    else
                    {
                        wb.Write(slice257);
                    }

                    wb.Write(slice262);
                }

                if (t.Enrollment.Program.Services != null)
                {
                    wb.Write(slice242);
                    wb.Append(t.Enrollment.Program.Services.Count, enc);
                    if (t.Enrollment.Program.Services.IsReadOnly)
                    {
                        wb.Write(slice253);
                    }
                    else
                    {
                        wb.Write(slice257);
                    }

                    wb.Write(slice262);
                }

                wb.Write(slice279);
                wb.Append(t.Enrollment.Program.CreatedDate.ToString(), enc);
                wb.Write(slice126);
                wb.Append(t.Enrollment.Program.UpdatedDate.ToString(), enc);
                if (t.Enrollment.Program.UpdateBy != null)
                {
                    wb.Write(slice145);
                    wb.Append(t.Enrollment.Program.UpdateBy, enc);
                    wb.Write(slice145);
                }

                wb.Write(slice146);
            }

            if (t.Enrollment.Client != null)
            {
                wb.Write(slice0);
                wb.Append(t.Enrollment.Client.Id, enc);
                wb.Write(slice82);
                wb.Append(t.Enrollment.Client.ClientId, enc);
                if (t.Enrollment.Client.HomeAddress != null)
                {
                    if (t.Enrollment.Client.HomeAddress.Street1 != null)
                    {
                        wb.Write(slice145);
                        wb.Append(t.Enrollment.Client.HomeAddress.Street1, enc);
                        wb.Write(slice145);
                    }

                    if (t.Enrollment.Client.HomeAddress.Street2 != null)
                    {
                        wb.Write(slice145);
                        wb.Append(t.Enrollment.Client.HomeAddress.Street2, enc);
                        wb.Write(slice145);
                    }

                    wb.Write(slice338);
                    wb.Append(t.Enrollment.Client.HomeAddress.Zip, enc);
                    if (t.Enrollment.Client.HomeAddress.City != null)
                    {
                        wb.Write(slice145);
                        wb.Append(t.Enrollment.Client.HomeAddress.City, enc);
                        wb.Write(slice145);
                    }

                    if (t.Enrollment.Client.HomeAddress.State != null)
                    {
                        wb.Write(slice145);
                        wb.Append(t.Enrollment.Client.HomeAddress.State, enc);
                        wb.Write(slice145);
                    }

                    wb.Write(slice373);
                }

                if (t.Enrollment.Client.Docs != null)
                {
                    wb.Write(slice242);
                    wb.Append(t.Enrollment.Client.Docs.Count, enc);
                    if (t.Enrollment.Client.Docs.IsReadOnly)
                    {
                        wb.Write(slice253);
                    }
                    else
                    {
                        wb.Write(slice257);
                    }

                    wb.Write(slice262);
                }

                if (t.Enrollment.Client.Notes != null)
                {
                    wb.Write(slice242);
                    wb.Append(t.Enrollment.Client.Notes.Count, enc);
                    if (t.Enrollment.Client.Notes.IsReadOnly)
                    {
                        wb.Write(slice253);
                    }
                    else
                    {
                        wb.Write(slice257);
                    }

                    wb.Write(slice262);
                }

                if (t.Enrollment.Client.Enrollments != null)
                {
                    wb.Write(slice242);
                    wb.Append(t.Enrollment.Client.Enrollments.Count, enc);
                    if (t.Enrollment.Client.Enrollments.IsReadOnly)
                    {
                        wb.Write(slice253);
                    }
                    else
                    {
                        wb.Write(slice257);
                    }

                    wb.Write(slice262);
                }

                if (t.Enrollment.Client.Contacts != null)
                {
                    wb.Write(slice242);
                    wb.Append(t.Enrollment.Client.Contacts.Count, enc);
                    if (t.Enrollment.Client.Contacts.IsReadOnly)
                    {
                        wb.Write(slice253);
                    }
                    else
                    {
                        wb.Write(slice257);
                    }

                    wb.Write(slice262);
                }

                if (t.Enrollment.Client.CareSettings != null)
                {
                    wb.Write(slice242);
                    wb.Append(t.Enrollment.Client.CareSettings.Count, enc);
                    if (t.Enrollment.Client.CareSettings.IsReadOnly)
                    {
                        wb.Write(slice253);
                    }
                    else
                    {
                        wb.Write(slice257);
                    }

                    wb.Write(slice262);
                }

                wb.Write(slice395);
                wb.Append(t.Enrollment.Client.CreatedDate.ToString(), enc);
                wb.Write(slice126);
                wb.Append(t.Enrollment.Client.UpdatedDate.ToString(), enc);
                if (t.Enrollment.Client.UpdateBy != null)
                {
                    wb.Write(slice145);
                    wb.Append(t.Enrollment.Client.UpdateBy, enc);
                    wb.Write(slice145);
                }

                wb.Write(slice146);
            }

            if (t.Enrollment.EnrollmentServices != null)
            {
                wb.Write(slice242);
                wb.Append(t.Enrollment.EnrollmentServices.Count, enc);
                if (t.Enrollment.EnrollmentServices.IsReadOnly)
                {
                    wb.Write(slice253);
                }
                else
                {
                    wb.Write(slice257);
                }

                wb.Write(slice262);
            }

            if (t.Enrollment.Documents != null)
            {
                wb.Write(slice242);
                wb.Append(t.Enrollment.Documents.Count, enc);
                if (t.Enrollment.Documents.IsReadOnly)
                {
                    wb.Write(slice253);
                }
                else
                {
                    wb.Write(slice257);
                }

                wb.Write(slice262);
            }

            if (t.Enrollment.Notes != null)
            {
                wb.Write(slice242);
                wb.Append(t.Enrollment.Notes.Count, enc);
                if (t.Enrollment.Notes.IsReadOnly)
                {
                    wb.Write(slice253);
                }
                else
                {
                    wb.Write(slice257);
                }

                wb.Write(slice262);
            }

            wb.Write(slice500);
            wb.Append(t.Enrollment.CreatedDate.ToString(), enc);
            wb.Write(slice126);
            wb.Append(t.Enrollment.UpdatedDate.ToString(), enc);
            if (t.Enrollment.UpdateBy != null)
            {
                wb.Write(slice145);
                wb.Append(t.Enrollment.UpdateBy, enc);
                wb.Write(slice145);
            }

            wb.Write(slice146);
        }

        if (t.Service != null)
        {
            wb.Write(slice0);
            wb.Append(t.Service.Id, enc);
            wb.Write(slice51);
            wb.Append(t.Service.ServiceId, enc);
            wb.Write(slice227);
            wb.Append(t.Service.ProgramId, enc);
            if (t.Service.Code != null)
            {
                wb.Write(slice145);
                wb.Append(t.Service.Code, enc);
                wb.Write(slice145);
            }

            if (t.Service.Name != null)
            {
                wb.Write(slice145);
                wb.Append(t.Service.Name, enc);
                wb.Write(slice145);
            }

            if (t.Service.SubName != null)
            {
                wb.Write(slice145);
                wb.Append(t.Service.SubName, enc);
                wb.Write(slice145);
            }

            if (t.Service.Providers != null)
            {
                wb.Write(slice242);
                wb.Append(t.Service.Providers.Count, enc);
                if (t.Service.Providers.IsReadOnly)
                {
                    wb.Write(slice253);
                }
                else
                {
                    wb.Write(slice257);
                }

                wb.Write(slice262);
            }

            if (t.Service.Program != null)
            {
                wb.Write(slice0);
                wb.Append(t.Service.Program.Id, enc);
                wb.Write(slice227);
                wb.Append(t.Service.Program.ProgramId, enc);
                if (t.Service.Program.Name != null)
                {
                    wb.Write(slice145);
                    wb.Append(t.Service.Program.Name, enc);
                    wb.Write(slice145);
                }

                if (t.Service.Program.Enrollments != null)
                {
                    wb.Write(slice242);
                    wb.Append(t.Service.Program.Enrollments.Count, enc);
                    if (t.Service.Program.Enrollments.IsReadOnly)
                    {
                        wb.Write(slice253);
                    }
                    else
                    {
                        wb.Write(slice257);
                    }

                    wb.Write(slice262);
                }

                if (t.Service.Program.Services != null)
                {
                    wb.Write(slice242);
                    wb.Append(t.Service.Program.Services.Count, enc);
                    if (t.Service.Program.Services.IsReadOnly)
                    {
                        wb.Write(slice253);
                    }
                    else
                    {
                        wb.Write(slice257);
                    }

                    wb.Write(slice262);
                }

                wb.Write(slice279);
                wb.Append(t.Service.Program.CreatedDate.ToString(), enc);
                wb.Write(slice126);
                wb.Append(t.Service.Program.UpdatedDate.ToString(), enc);
                if (t.Service.Program.UpdateBy != null)
                {
                    wb.Write(slice145);
                    wb.Append(t.Service.Program.UpdateBy, enc);
                    wb.Write(slice145);
                }

                wb.Write(slice146);
            }

            wb.Write(slice593);
            wb.Append(t.Service.CreatedDate.ToString(), enc);
            wb.Write(slice126);
            wb.Append(t.Service.UpdatedDate.ToString(), enc);
            if (t.Service.UpdateBy != null)
            {
                wb.Write(slice145);
                wb.Append(t.Service.UpdateBy, enc);
                wb.Write(slice145);
            }

            wb.Write(slice146);
        }

        if (t.Provider != null)
        {
            wb.Write(slice0);
            wb.Append(t.Provider.Id, enc);
            wb.Write(slice66);
            wb.Append(t.Provider.ProviderId, enc);
            if (t.Provider.Name != null)
            {
                wb.Write(slice145);
                wb.Append(t.Provider.Name, enc);
                wb.Write(slice145);
            }

            if (t.Provider.Services != null)
            {
                wb.Write(slice242);
                wb.Append(t.Provider.Services.Count, enc);
                if (t.Provider.Services.IsReadOnly)
                {
                    wb.Write(slice253);
                }
                else
                {
                    wb.Write(slice257);
                }

                wb.Write(slice262);
            }

            wb.Write(slice672);
            wb.Append(t.Provider.CreatedDate.ToString(), enc);
            wb.Write(slice126);
            wb.Append(t.Provider.UpdatedDate.ToString(), enc);
            if (t.Provider.UpdateBy != null)
            {
                wb.Write(slice145);
                wb.Append(t.Provider.UpdateBy, enc);
                wb.Write(slice145);
            }

            wb.Write(slice146);
        }

        wb.Write(slice714);
        wb.Append(t.CreatedDate.ToString(), enc);
        wb.Write(slice126);
        wb.Append(t.UpdatedDate.ToString(), enc);
        if (t.UpdateBy != null)
        {
            wb.Write(slice145);
            wb.Append(t.UpdateBy, enc);
            wb.Write(slice145);
        }

        wb.Write(slice146);
    }
}