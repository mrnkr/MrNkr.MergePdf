using iText.Kernel.Pdf;
using iText.Kernel.Utils;

namespace MrNkr.MergePdf.Core;

public class MergedPdfBuilder
{
    private readonly IList<string> _files = new List<string>();
    private string? _dest;

    public MergedPdfBuilder AddFile(string file)
    {
        _files.Add(file);
        return this;
    }

    public MergedPdfBuilder SaveAs(string path)
    {
        _dest = path;
        return this;
    }

    public void Build()
    {
        if (_dest is null)
        {
            throw new InvalidOperationException($"Call {nameof(SaveAs)} before calling {nameof(Build)}");
        }

        PdfDocument pdf = new(new PdfWriter(_dest));
        PdfMerger merger = new(pdf);

        foreach (string file in _files)
        {
            PdfDocument sourcePdf = new(new PdfReader(file));
            merger.Merge(sourcePdf, 1, sourcePdf.GetNumberOfPages());
            sourcePdf.Close();
        }

        pdf.Close();
    }
}