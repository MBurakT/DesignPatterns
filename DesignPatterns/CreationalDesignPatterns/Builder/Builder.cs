using System;

namespace DesignPatterns.CreationalDesignPatterns.Builder;

public class BuilderProgram
{
    public static void Client(string[] args)
    {
        PdfReportBuilder pdfReportBuilder = new();
        ReportDirector reportDirector = new();
        Report report = reportDirector.MakeReport(pdfReportBuilder);

        report.DisplayReport();

        Console.WriteLine("-------------------");

        ExcelReportBuilder excelReportBuilder = new();
        report = reportDirector.MakeReport(excelReportBuilder);

        report.DisplayReport();
    }
}

public class Report
{
    public string? ReportType { get; set; }
    public string? ReportHeader { get; set; }
    public string? ReportContent { get; set; }
    public string? ReportFooter { get; set; }

    public void DisplayReport()
    {
        Console.WriteLine($"{ReportType}\n{ReportHeader}\n{ReportContent}\n{ReportFooter}");
    }
}

public abstract class ReportBuilder
{
    protected Report reportObject;

    public abstract void SetReportType();
    public abstract void SetReportHeader();
    public abstract void SetReportContent();
    public abstract void SetReportFooter();

    public void CreateNewReport()
    {
        reportObject = new Report();
    }
    public Report GetReport()
    {
        return reportObject;
    }
}

public class ExcelReportBuilder : ReportBuilder
{
    public override void SetReportType()
    {
        reportObject.ReportType = "Excel";
    }

    public override void SetReportHeader()
    {
        reportObject.ReportHeader = "Excel Header";
    }

    public override void SetReportContent()
    {
        reportObject.ReportContent = "Excel Content";
    }

    public override void SetReportFooter()
    {
        reportObject.ReportFooter = "Excel Footer";
    }
}

public class PdfReportBuilder : ReportBuilder
{
    public override void SetReportType()
    {
        reportObject.ReportType = "Pdf";
    }

    public override void SetReportHeader()
    {
        reportObject.ReportHeader = "Pdf Header";
    }

    public override void SetReportContent()
    {
        reportObject.ReportContent = "Pdf Content";
    }

    public override void SetReportFooter()
    {
        reportObject.ReportFooter = "Pdf Footer";
    }
}

public class ReportDirector
{
    public Report MakeReport(ReportBuilder reportBuilder)
    {
        reportBuilder.CreateNewReport();
        reportBuilder.SetReportType();
        reportBuilder.SetReportHeader();
        reportBuilder.SetReportContent();
        reportBuilder.SetReportFooter();
        return reportBuilder.GetReport();
    }
}