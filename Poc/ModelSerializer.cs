using System;
using System.IO.Pipelines;
using System.Text.Formatting;
using System.Text;

public static partial class ModelSerializer
{
    static Span<byte> span = new Span<byte>(Encoding.UTF8.GetBytes("{\"Id\" : ,\"EnrollmentServiceId\" : ,\"EnrollmentId\" : ,\"ServiceId\" : ,\"ProviderId\" : ,\"ClientId\" : ,\"UserId\" : ,\"CreatedDate\" : '',\"UpdatedDate\" : '',\"UpdateBy\" : ''},\"PrimaryCaseManager\" : ,\"SecondaryCaseManager\" : ,\"ProgramId\" : ,\"ProgramId\" : ,\"Name\" : '{\"Count\" : truefalse,\"IsReadOnly\" : }',\"Enrollments\" : ,\"Services\" : ,\"CreatedDate\" : '{\"Street1\" : '',\"Street2\" : '',\"Zip\" : ,\"City\" : '',\"State\" : ',\"HomeAddress\" : ,\"Docs\" : ,\"Notes\" : ,\"Enrollments\" : ,\"Contacts\" : ,\"CareSettings\" : ,\"CreatedDate\" : ',\"Program\" : ,\"Client\" : ,\"EnrollmentServices\" : ,\"Documents\" : ,\"Notes\" : ,\"CreatedDate\" : ',\"Code\" : '',\"Name\" : '',\"SubName\" : '',\"Providers\" : ,\"Program\" : ,\"CreatedDate\" : '',\"Services\" : ,\"CreatedDate\" : ',\"Enrollment\" : ,\"Service\" : ,\"Provider\" : ,\"CreatedDate\" : '"));
    static Span<byte> slice0 = span.Slice(0, 8);
    static Span<byte> slice8 = span.Slice(8, 25);
    static Span<byte> slice33 = span.Slice(33, 18);
    static Span<byte> slice51 = span.Slice(51, 15);
    static Span<byte> slice66 = span.Slice(66, 16);
    static Span<byte> slice82 = span.Slice(82, 14);
    static Span<byte> slice96 = span.Slice(96, 12);
    static Span<byte> slice108 = span.Slice(108, 18);
    static Span<byte> slice126 = span.Slice(126, 19);
    static Span<byte> slice145 = span.Slice(145, 16);
    static Span<byte> slice161 = span.Slice(161, 2);
    static Span<byte> slice163 = span.Slice(163, 65);
    static Span<byte> slice228 = span.Slice(228, 15);
    static Span<byte> slice243 = span.Slice(243, 11);
    static Span<byte> slice254 = span.Slice(254, 11);
    static Span<byte> slice265 = span.Slice(265, 4);
    static Span<byte> slice269 = span.Slice(269, 5);
    static Span<byte> slice274 = span.Slice(274, 17);
    static Span<byte> slice291 = span.Slice(291, 50);
    static Span<byte> slice341 = span.Slice(341, 14);
    static Span<byte> slice355 = span.Slice(355, 15);
    static Span<byte> slice370 = span.Slice(370, 10);
    static Span<byte> slice380 = span.Slice(380, 11);
    static Span<byte> slice391 = span.Slice(391, 13);
    static Span<byte> slice404 = span.Slice(404, 105);
    static Span<byte> slice509 = span.Slice(509, 93);
    static Span<byte> slice602 = span.Slice(602, 11);
    static Span<byte> slice613 = span.Slice(613, 12);
    static Span<byte> slice625 = span.Slice(625, 15);
    static Span<byte> slice640 = span.Slice(640, 47);
    static Span<byte> slice687 = span.Slice(687, 33);
    static Span<byte> slice720 = span.Slice(720, 61);
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
                wb.Write(slice145);
                wb.Append(t.Enrollment.PrimaryCaseManager.UpdateBy, enc);
                wb.Write(slice161);
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
                wb.Write(slice145);
                wb.Append(t.Enrollment.SecondaryCaseManager.UpdateBy, enc);
                wb.Write(slice161);
            }

            wb.Write(slice163);
            wb.Append(t.Enrollment.ProgramId, enc);
            if (t.Enrollment.Program != null)
            {
                wb.Write(slice0);
                wb.Append(t.Enrollment.Program.Id, enc);
                wb.Write(slice228);
                wb.Append(t.Enrollment.Program.ProgramId, enc);
                wb.Write(slice243);
                wb.Append(t.Enrollment.Program.Name, enc);
                if (t.Enrollment.Program.Enrollments != null)
                {
                    wb.Write(slice254);
                    wb.Append(t.Enrollment.Program.Enrollments.Count, enc);
                    if (t.Enrollment.Program.Enrollments.IsReadOnly)
                    {
                        wb.Write(slice265);
                    }
                    else
                    {
                        wb.Write(slice269);
                    }

                    wb.Write(slice274);
                }

                if (t.Enrollment.Program.Services != null)
                {
                    wb.Write(slice254);
                    wb.Append(t.Enrollment.Program.Services.Count, enc);
                    if (t.Enrollment.Program.Services.IsReadOnly)
                    {
                        wb.Write(slice265);
                    }
                    else
                    {
                        wb.Write(slice269);
                    }

                    wb.Write(slice274);
                }

                wb.Write(slice291);
                wb.Append(t.Enrollment.Program.CreatedDate.ToString(), enc);
                wb.Write(slice126);
                wb.Append(t.Enrollment.Program.UpdatedDate.ToString(), enc);
                wb.Write(slice145);
                wb.Append(t.Enrollment.Program.UpdateBy, enc);
                wb.Write(slice161);
            }

            if (t.Enrollment.Client != null)
            {
                wb.Write(slice0);
                wb.Append(t.Enrollment.Client.Id, enc);
                wb.Write(slice82);
                wb.Append(t.Enrollment.Client.ClientId, enc);
                if (t.Enrollment.Client.HomeAddress != null)
                {
                    wb.Write(slice341);
                    wb.Append(t.Enrollment.Client.HomeAddress.Street1, enc);
                    wb.Write(slice355);
                    wb.Append(t.Enrollment.Client.HomeAddress.Street2, enc);
                    wb.Write(slice370);
                    wb.Append(t.Enrollment.Client.HomeAddress.Zip, enc);
                    wb.Write(slice380);
                    wb.Append(t.Enrollment.Client.HomeAddress.City, enc);
                    wb.Write(slice391);
                    wb.Append(t.Enrollment.Client.HomeAddress.State, enc);
                    wb.Write(slice161);
                }

                if (t.Enrollment.Client.Docs != null)
                {
                    wb.Write(slice254);
                    wb.Append(t.Enrollment.Client.Docs.Count, enc);
                    if (t.Enrollment.Client.Docs.IsReadOnly)
                    {
                        wb.Write(slice265);
                    }
                    else
                    {
                        wb.Write(slice269);
                    }

                    wb.Write(slice274);
                }

                if (t.Enrollment.Client.Notes != null)
                {
                    wb.Write(slice254);
                    wb.Append(t.Enrollment.Client.Notes.Count, enc);
                    if (t.Enrollment.Client.Notes.IsReadOnly)
                    {
                        wb.Write(slice265);
                    }
                    else
                    {
                        wb.Write(slice269);
                    }

                    wb.Write(slice274);
                }

                if (t.Enrollment.Client.Enrollments != null)
                {
                    wb.Write(slice254);
                    wb.Append(t.Enrollment.Client.Enrollments.Count, enc);
                    if (t.Enrollment.Client.Enrollments.IsReadOnly)
                    {
                        wb.Write(slice265);
                    }
                    else
                    {
                        wb.Write(slice269);
                    }

                    wb.Write(slice274);
                }

                if (t.Enrollment.Client.Contacts != null)
                {
                    wb.Write(slice254);
                    wb.Append(t.Enrollment.Client.Contacts.Count, enc);
                    if (t.Enrollment.Client.Contacts.IsReadOnly)
                    {
                        wb.Write(slice265);
                    }
                    else
                    {
                        wb.Write(slice269);
                    }

                    wb.Write(slice274);
                }

                if (t.Enrollment.Client.CareSettings != null)
                {
                    wb.Write(slice254);
                    wb.Append(t.Enrollment.Client.CareSettings.Count, enc);
                    if (t.Enrollment.Client.CareSettings.IsReadOnly)
                    {
                        wb.Write(slice265);
                    }
                    else
                    {
                        wb.Write(slice269);
                    }

                    wb.Write(slice274);
                }

                wb.Write(slice404);
                wb.Append(t.Enrollment.Client.CreatedDate.ToString(), enc);
                wb.Write(slice126);
                wb.Append(t.Enrollment.Client.UpdatedDate.ToString(), enc);
                wb.Write(slice145);
                wb.Append(t.Enrollment.Client.UpdateBy, enc);
                wb.Write(slice161);
            }

            if (t.Enrollment.EnrollmentServices != null)
            {
                wb.Write(slice254);
                wb.Append(t.Enrollment.EnrollmentServices.Count, enc);
                if (t.Enrollment.EnrollmentServices.IsReadOnly)
                {
                    wb.Write(slice265);
                }
                else
                {
                    wb.Write(slice269);
                }

                wb.Write(slice274);
            }

            if (t.Enrollment.Documents != null)
            {
                wb.Write(slice254);
                wb.Append(t.Enrollment.Documents.Count, enc);
                if (t.Enrollment.Documents.IsReadOnly)
                {
                    wb.Write(slice265);
                }
                else
                {
                    wb.Write(slice269);
                }

                wb.Write(slice274);
            }

            if (t.Enrollment.Notes != null)
            {
                wb.Write(slice254);
                wb.Append(t.Enrollment.Notes.Count, enc);
                if (t.Enrollment.Notes.IsReadOnly)
                {
                    wb.Write(slice265);
                }
                else
                {
                    wb.Write(slice269);
                }

                wb.Write(slice274);
            }

            wb.Write(slice509);
            wb.Append(t.Enrollment.CreatedDate.ToString(), enc);
            wb.Write(slice126);
            wb.Append(t.Enrollment.UpdatedDate.ToString(), enc);
            wb.Write(slice145);
            wb.Append(t.Enrollment.UpdateBy, enc);
            wb.Write(slice161);
        }

        if (t.Service != null)
        {
            wb.Write(slice0);
            wb.Append(t.Service.Id, enc);
            wb.Write(slice51);
            wb.Append(t.Service.ServiceId, enc);
            wb.Write(slice228);
            wb.Append(t.Service.ProgramId, enc);
            wb.Write(slice602);
            wb.Append(t.Service.Code, enc);
            wb.Write(slice613);
            wb.Append(t.Service.Name, enc);
            wb.Write(slice625);
            wb.Append(t.Service.SubName, enc);
            if (t.Service.Providers != null)
            {
                wb.Write(slice254);
                wb.Append(t.Service.Providers.Count, enc);
                if (t.Service.Providers.IsReadOnly)
                {
                    wb.Write(slice265);
                }
                else
                {
                    wb.Write(slice269);
                }

                wb.Write(slice274);
            }

            if (t.Service.Program != null)
            {
                wb.Write(slice0);
                wb.Append(t.Service.Program.Id, enc);
                wb.Write(slice228);
                wb.Append(t.Service.Program.ProgramId, enc);
                wb.Write(slice243);
                wb.Append(t.Service.Program.Name, enc);
                if (t.Service.Program.Enrollments != null)
                {
                    wb.Write(slice254);
                    wb.Append(t.Service.Program.Enrollments.Count, enc);
                    if (t.Service.Program.Enrollments.IsReadOnly)
                    {
                        wb.Write(slice265);
                    }
                    else
                    {
                        wb.Write(slice269);
                    }

                    wb.Write(slice274);
                }

                if (t.Service.Program.Services != null)
                {
                    wb.Write(slice254);
                    wb.Append(t.Service.Program.Services.Count, enc);
                    if (t.Service.Program.Services.IsReadOnly)
                    {
                        wb.Write(slice265);
                    }
                    else
                    {
                        wb.Write(slice269);
                    }

                    wb.Write(slice274);
                }

                wb.Write(slice291);
                wb.Append(t.Service.Program.CreatedDate.ToString(), enc);
                wb.Write(slice126);
                wb.Append(t.Service.Program.UpdatedDate.ToString(), enc);
                wb.Write(slice145);
                wb.Append(t.Service.Program.UpdateBy, enc);
                wb.Write(slice161);
            }

            wb.Write(slice640);
            wb.Append(t.Service.CreatedDate.ToString(), enc);
            wb.Write(slice126);
            wb.Append(t.Service.UpdatedDate.ToString(), enc);
            wb.Write(slice145);
            wb.Append(t.Service.UpdateBy, enc);
            wb.Write(slice161);
        }

        if (t.Provider != null)
        {
            wb.Write(slice0);
            wb.Append(t.Provider.Id, enc);
            wb.Write(slice66);
            wb.Append(t.Provider.ProviderId, enc);
            wb.Write(slice243);
            wb.Append(t.Provider.Name, enc);
            if (t.Provider.Services != null)
            {
                wb.Write(slice254);
                wb.Append(t.Provider.Services.Count, enc);
                if (t.Provider.Services.IsReadOnly)
                {
                    wb.Write(slice265);
                }
                else
                {
                    wb.Write(slice269);
                }

                wb.Write(slice274);
            }

            wb.Write(slice687);
            wb.Append(t.Provider.CreatedDate.ToString(), enc);
            wb.Write(slice126);
            wb.Append(t.Provider.UpdatedDate.ToString(), enc);
            wb.Write(slice145);
            wb.Append(t.Provider.UpdateBy, enc);
            wb.Write(slice161);
        }

        wb.Write(slice720);
        wb.Append(t.CreatedDate.ToString(), enc);
        wb.Write(slice126);
        wb.Append(t.UpdatedDate.ToString(), enc);
        wb.Write(slice145);
        wb.Append(t.UpdateBy, enc);
        wb.Write(slice161);
    }
}